using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Media;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Storage.Streams;
using DiscordRPC;

namespace DeMonic
{
	public partial class FormMusicBrowser : Form
	{
		private readonly PanelNoServers panelNoServers = new PanelNoServers();
		private readonly MediaPlayer player = new MediaPlayer();
		private readonly SubsonicAPI api = new SubsonicAPI();
		private DiscordRpcClient discord;

		private bool IsPlaying
		{
			get
			{
				if (player == null) return false;
				return player.PlaybackSession.PlaybackState == MediaPlaybackState.Playing;
			}
		}

		// Queue Management
		private List<Child> songs = new List<Child>();
		private int currentSong = -1;
		private MediaPlaybackState previousState;
		private Timer trackBarScrollTimer;

		public FormMusicBrowser()
		{
			InitializeComponent();
			SetupAPI();
			timerDiscord.Start();
			timerTrackbar.Start();

			scrobbleToolStripMenuItem.Checked = DataServerList.ShouldScrobble;
			discordRichPresenceToolStripMenuItem.Checked = DataServerList.UseDiscordRichPresence;

			if (DataServerList.UseDiscordRichPresence)
			{
				GetNewDiscordClient();
				discord.Initialize();
			}

			panelNoServers.parent = this;
			this.Controls.Add(panelNoServers);
			ShowPanel();

			player.MediaEnded += Player_MediaEnded;
			player.PlaybackSession.PlaybackStateChanged += PlaybackSession_PlaybackStateChanged;

			// Meta
			versionToolStripMenuItem.Text = $"Version {Application.ProductVersion}";
		}

		private void GetNewDiscordClient()
		{
			if (discord != null && discord.IsInitialized)
			{
				discord.ClearPresence();
				discord.Invoke();
				discord.Deinitialize();
				discord.Dispose();
				discord = null;
			}
			discord = new DiscordRpcClient("708992771901489213");
		}

		private void PlaybackSession_PlaybackStateChanged(MediaPlaybackSession sender, object args)
		{
			if (
				sender.PlaybackState == MediaPlaybackState.Buffering ||
				sender.PlaybackState == MediaPlaybackState.Opening ||
				sender.PlaybackState == previousState
			)
			{
				return;
			}

			var text = "DeMonic";
			if (currentSong >= 0)
			{
				var song = songs[currentSong];
				var number = SubsonicAPI.PadNumber(song.track);
				var state = IsPlaying ? "" : "[Paused] ";
				text = $"{state}{song.artist} - {song.album} - {number} {song.title} - DeMonic";

				SetDiscordRichPresence(songs[currentSong], IsPlaying);
			}

			previousState = sender.PlaybackState;

			Invoke(new Action(() =>
			{
				this.Text = text;
				trackBar1.Enabled = currentSong >= 0;
				buttonPlayPause.Image = IsPlaying ? Properties.Resources.pause : Properties.Resources.play;
			}));
		}

		private void Player_MediaEnded(MediaPlayer sender, object args)
		{
			// Call on the UI thread
			Invoke(new Action(() =>
			{
				// Scrobble
				if (DataServerList.ShouldScrobble)
				{
					api.Scrobble(songs[currentSong]);
				}

				// Move to next song
				SkipSong(1);
			}));
		}

		private void SkipSong(int diff)
		{
			if (songs.Count == 0) return;

			// Clamp to 0 or above
			var nextSong = Math.Max(currentSong + diff, 0);

			if (songs.Count <= nextSong)
			{
				trackBar1.Value = 0;
				currentSong = -1;
				RefreshQueueList();
				player.Source = null;
				pictureBox1.Image = null;
				if (discord != null) discord.ClearPresence();
				return;
			}

			currentSong = nextSong;
			PlaySong(songs[currentSong]);
		}

		private void ShowPanel()
		{
			if (DataServerList.serverList.Count == 0)
			{
				panelNoServers.Show();
				panelNoServers.Size = new Size(DisplayRectangle.Width, DisplayRectangle.Height - menuStrip1.Height);
				panelNoServers.Location = new Point(0, menuStrip1.Height);
				panelNoServers.Dock = DockStyle.Fill;
				panelNoServers.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
				panelNoServers.BringToFront();
			}
			else if (this.Controls.Contains(panelNoServers))
			{
				panelNoServers.Hide();
			}
		}

		private async void SetupAPI()
		{
			await api.SetupClient();

			var text = "Not Connected";
			if (api.Connected && DataServerList.ActiveServer != null)
			{
				text = $"Connected to {DataServerList.ActiveServer?.host}";
			}
			toolStripConnectionLabel.Text = text;

			DisplayArtists();
		}

		public async void DisplayArtists()
		{
			if (!api.Connected) return;

			await api.GetAlbums();

			artistAlbumTree.Nodes.Clear();

			foreach (var album in api.artistsAlbums)
			{
				var node = new TreeNode($"{album.artist} - {album.name} [{album.year}]")
				{
					Tag = new { id = album.id }
				};
				artistAlbumTree.Nodes.Add(node);
			}
		}

		public void ShowServerList()
		{
			var dlg = new FormServerList();
			dlg.ShowDialog();
			ShowPanel();
			SetupAPI();
		}

		private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowServerList();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void toolStripConnectionLabel_Click(object sender, EventArgs e)
		{
			ShowServerList();
		}

		private void FormMusicBrowser_FormClosing(object sender, FormClosingEventArgs e)
		{
			timerTrackbar.Stop();
			timerDiscord.Stop();

			player.Pause();
			player.Dispose();

			if (discord != null && discord?.IsInitialized == true)
			{
				discord.ClearPresence();
				discord.Invoke();
				discord.Dispose();
			}
		}

		private void timerTrackbar_Tick(object sender, EventArgs e)
		{
			if (currentSong == -1)
			{
				statusBarSongInfo.Text = "Not Playing";
				return;
			};

			if (!IsPlaying) return;

			// Update status bar
			var posHuman = SubsonicAPI.HumanDuration((int)player.PlaybackSession.Position.TotalSeconds);
			var durHuman = SubsonicAPI.HumanDuration(songs[currentSong].duration);
			statusBarSongInfo.Text = $"{posHuman} / {durHuman}";

			// Update trackbar
			var pos = player.PlaybackSession.Position.TotalMilliseconds;
			var len = (double)songs[currentSong].duration * 1000;
			if (pos > 0.0 && len > 0.0)
			{
				var pct = Math.Min(pos / len * 1000, 1000);
				trackBar1.Value = (int)pct;
			}
		}

		private void SongSeek()
		{
			var pct = (double)trackBar1.Value / 1000;
			var ticks = (int)(songs[currentSong].duration * pct);
			player.PlaybackSession.Position = new TimeSpan(0, 0, ticks);

			SetDiscordRichPresence(songs[currentSong], IsPlaying);
		}

		private void trackBar1_Scroll(object sender, EventArgs e)
		{
			if (trackBarScrollTimer == null)
			{
				// Will tick every 25ms (change as required)
				trackBarScrollTimer = new Timer()
				{
					Enabled = false,
					Interval = 25,
					Tag = (sender as TrackBar).Value
				};

				trackBarScrollTimer.Tick += (s, eventArgs) =>
				{
					// check to see if the value has changed since we last ticked
					if (trackBar1.Value == (int)trackBarScrollTimer.Tag)
					{
						// scrolling has stopped so we are good to go ahead and do stuff
						trackBarScrollTimer.Stop();

						SongSeek();

						trackBarScrollTimer.Dispose();
						trackBarScrollTimer = null;
					}
					else
					{
						// record the last value seen
						trackBarScrollTimer.Tag = trackBar1.Value;
					}
				};
				trackBarScrollTimer.Start();
			}
		}

		private void StartQueue()
		{
			if (songs.Count == 0) return;
			if (currentSong < 0) currentSong = 0;
			PlaySong(songs[currentSong]);
		}

		private void PlaySong(Child song)
		{
			timerTrackbar.Stop();
			trackBar1.Value = 0;

			var uri = api.GetFullUri("stream", $"id={song.id}");
			var src = MediaSource.CreateFromUri(uri);
			var pb = new MediaPlaybackItem(src);

			var props = pb.GetDisplayProperties();
			props.Type = MediaPlaybackType.Music;
			props.MusicProperties.AlbumArtist = song.artist;
			props.MusicProperties.AlbumTitle = song.album;
			props.MusicProperties.Title = song.title;
			props.MusicProperties.TrackNumber = (uint)song.track;
			//props.Thumbnail = RandomAccessStreamReference.CreateFromStream(pictureBox1.Image);
			pb.ApplyDisplayProperties(props);

			player.Source = pb;
			player.Play();

			timerTrackbar.Start();
			RefreshQueueList();

			DisplayCoverArt(song.coverArt);
		}

		private void SetDiscordRichPresence(Child song, bool isPlaying)
		{
			if (!DataServerList.UseDiscordRichPresence) return;

			ulong? StartUnixMilliseconds = null;

			if (isPlaying == true)
			{
				var pos = player.PlaybackSession.Position.TotalMilliseconds;
				StartUnixMilliseconds = (ulong)(DateTimeOffset.Now.ToUnixTimeMilliseconds() - pos);
			}

			string details = $"{song.artist} - {song.album} [{song.year}]";
			string state = song.title;
			string smallImageKey = isPlaying ? "playing" : "paused";

			RichPresence presence = new RichPresence()
			{
				Details = details,
				State = state,
				Timestamps = new Timestamps()
				{
					Start = null,
					StartUnixMilliseconds = StartUnixMilliseconds,
				},
				Assets = new Assets()
				{
					LargeImageKey = "foobar2000",
					SmallImageKey = smallImageKey,
				}
			};

			discord.SetPresence(presence);
		}

		private void RefreshQueueList()
		{
			listSongQueue.Items.Clear();

			var index = 0;
			var totalDuration = 0;
			foreach (var song in songs)
			{
				var item = new ListViewItem();
				if (index == currentSong)
				{
					item.ImageIndex = 0;
				}

				var artistAlbum = new ListViewItem.ListViewSubItem
				{ Text = $"{song.artist} - {song.album} [{song.year}]" };
				item.SubItems.Add(artistAlbum);

				var disc = song.discNumberSpecified ? $"{song.discNumber}." : "";
				var trackNumber = new ListViewItem.ListViewSubItem
				{ Text = disc + SubsonicAPI.PadNumber(song.track) };
				item.SubItems.Add(trackNumber);

				var trackTitle = new ListViewItem.ListViewSubItem
				{ Text = song.title };
				item.SubItems.Add(trackTitle);

				var trackDuration = new ListViewItem.ListViewSubItem
				{ Text = SubsonicAPI.HumanDuration(song.duration) };
				item.SubItems.Add(trackDuration);

				totalDuration += song.duration;

				listSongQueue.Items.Add(item);
				index++;
			}

			var statusBarText = $"Total: {SubsonicAPI.HumanDuration(totalDuration)} ({songs.Count} songs in queue)";
			toolStripQueueInfo.Text = statusBarText;
		}

		private void buttonPlayPause_Click(object sender, EventArgs e)
		{
			if (player.PlaybackSession.PlaybackState == MediaPlaybackState.Playing)
			{
				player.Pause();
				return;
			}

			if (player.PlaybackSession.PlaybackState == MediaPlaybackState.Paused)
			{
				player.Play();
				return;
			}

			if (player.PlaybackSession.PlaybackState == MediaPlaybackState.None)
			{
				StartQueue();
			}
		}

		private async void DisplayCoverArt(string coverArt)
		{
			try
			{
				if (coverArt == null) return;
				pictureBox1.Image = await api.GetCoverArt(coverArt);
			}
			catch (Exception)
			{
				// Ignore error and clear image
				pictureBox1.Image = null;
			}
		}

		private async void PlayAlbum(string id, bool playImmediately)
		{
			var tracklist = await api.GetTrackList(id);
			if (playImmediately == true)
			{
				songs = tracklist.song.ToList();
				currentSong = 0;
				StartQueue();
			}
			else
			{
				songs.AddRange(tracklist.song.ToList());
			}
			RefreshQueueList();
		}

		private void artistAlbumTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Node.Level != 0) return;

			dynamic tag = e.Node.Tag;
			string id = tag.id;
			var playNow = currentSong == -1;

			PlayAlbum(id, playNow);
		}

		private void listSongQueue_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			var items = listSongQueue.SelectedIndices;
			if (items.Count == 0) return;

			currentSong = items[0];
			PlaySong(songs[currentSong]);
		}

		private void artistAlbumTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			artistAlbumTree.SelectedNode = e.Node;

			if (e.Button != MouseButtons.Right) return;
			if (e.Node.Level != 0) return;

			contextMenuStrip1.Show(Cursor.Position);
		}

		private void playNowToolStripMenuItem_Click(object sender, EventArgs e)
		{
			dynamic tag = artistAlbumTree.SelectedNode.Tag;
			string id = tag.id;

			PlayAlbum(id, true);
		}

		private void addToQueueToolStripMenuItem_Click(object sender, EventArgs e)
		{
			dynamic tag = artistAlbumTree.SelectedNode.Tag;
			string id = tag.id;

			PlayAlbum(id, false);
		}

		private void buttonSkipForwards_Click(object sender, EventArgs e)
		{
			SkipSong(1);
		}

		private void buttonSkipBackwards_Click(object sender, EventArgs e)
		{
			SkipSong(-1);
		}

		private void listSongQueue_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
			{
				// Keep track of song playing
				Child currentSongTmp = null;
				if (currentSong >= 0)
				{
					currentSongTmp = songs[currentSong];
				}

				// Keep track of songs to delete
				// Because of the separation from the listview and the song
				// queue, we refer to the selected indices as opposed to the
				// specific songs, as removing by index causes the index of
				// later songs to change. There's gotta be a way to improve this
				// but I'm not quite sure how yet.
				var songsToDelete = new List<Child>();
				foreach (int index in listSongQueue.SelectedIndices)
				{
					var song = songs[index];
					if (song == currentSongTmp) continue;
					songsToDelete.Add(song);
				}

				// Finally, remove songs by specifically targeting them in the array
				foreach (var song in songsToDelete)
				{
					songs.Remove(song);
				}

				// Finally, update the currently playing song based on what has
				// just been deleted (if playing)
				if (currentSongTmp != null)
				{
					currentSong = songs.FindIndex(song => song == currentSongTmp);
				}

				RefreshQueueList();
			}

			if (e.KeyCode == Keys.Enter)
			{
				if (listSongQueue.SelectedIndices.Count == 0) return;

				currentSong = listSongQueue.SelectedIndices[0];
				PlaySong(songs[currentSong]);
			}
		}

		private void timerDiscord_Tick(object sender, EventArgs e)
		{
			if (discord == null || discord.IsDisposed || !discord.IsInitialized) return;

			discord.Invoke();
		}

		private void serverListToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowServerList();
		}

		private void scrobbleToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			DataServerList.ShouldScrobble = scrobbleToolStripMenuItem.Checked;
			DataServerList.SaveConfig();
		}

		private void discordRichPresenceToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			DataServerList.UseDiscordRichPresence = discordRichPresenceToolStripMenuItem.Checked;
			DataServerList.SaveConfig();

			if (DataServerList.UseDiscordRichPresence)
			{
				if (discord == null || !discord.IsInitialized)
				{
					GetNewDiscordClient();
					discord.Initialize();
				}

				if (!IsPlaying) return;
				SetDiscordRichPresence(songs[currentSong], true);
			}
			else
			{
				if (discord != null && discord.IsInitialized)
				{
					discord.ClearPresence();
					discord.Deinitialize();
				}
			}
		}

		private void sourceCodeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("https://git.tombo.sh/tom/dotnet-demonic");
		}
	}
}
