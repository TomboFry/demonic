using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Windows.Media;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Storage;
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

		// Queue Management
		private List<Child> songs = new List<Child>();
		private int currentSong = -1;
		private MediaPlaybackState previousState;
		private Timer trackBarScrollTimer;
		private bool playerHasDisposed = false;

		private bool IsPlaying
		{
			get
			{
				if (playerHasDisposed) return false;
				return player.PlaybackSession.PlaybackState == MediaPlaybackState.Playing;
			}
		}

		public FormMusicBrowser()
		{
			InitializeComponent();
			SetupAPI();
			TimerDiscord.Start();
			TimerTrackbar.Start();

			ScrobbleToolStripMenuItem.Checked = DataServerList.ShouldScrobble;
			DiscordRichPresenceToolStripMenuItem.Checked = DataServerList.UseDiscordRichPresence;

			if (DataServerList.UseDiscordRichPresence)
			{
				GetNewDiscordClient();
				discord.Initialize();
			}

			panelNoServers.parent = this;
			Controls.Add(panelNoServers);
			ShowPanel();

			player.MediaEnded += Player_MediaEnded;
			player.PlaybackSession.PlaybackStateChanged += PlaybackSession_PlaybackStateChanged;

			// Meta
			VersionToolStripMenuItem.Text = $"Version {Application.ProductVersion}";
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
				sender.PlaybackState == previousState ||
				playerHasDisposed == true
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
				var playerEnabled = currentSong >= 0;

				Text = text;
				TrackBarSeek.Enabled = playerEnabled;
				ButtonPlayPause.Image = IsPlaying ? Properties.Resources.pause : Properties.Resources.play;

				if (playerEnabled)
				{
					ListSongQueue.Items[currentSong].ImageIndex = IsPlaying ? 0 : 1;
				}
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
				TrackBarSeek.Value = 0;
				currentSong = -1;
				RefreshQueueList();
				player.Source = null;
				PictureBoxCoverArt.Image = null;
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
				panelNoServers.Size = new Size(DisplayRectangle.Width, DisplayRectangle.Height - MenuStripMain.Height);
				panelNoServers.Location = new Point(0, MenuStripMain.Height);
				panelNoServers.Dock = DockStyle.Fill;
				panelNoServers.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
				panelNoServers.BringToFront();
			}
			else if (Controls.Contains(panelNoServers))
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
				text = $"Connected to {DataServerList.ActiveServer?.Host}";
			}
			ToolStripConnectionLabel.Text = text;

			DisplayArtists();
		}

		public async void DisplayArtists()
		{
			if (!api.Connected) return;

			await api.GetAlbums();

			ArtistAlbumTree.Nodes.Clear();

			foreach (var album in api.Albums)
			{
				var node = new TreeNode($"{album.artist} - {album.name} [{album.year}]")
				{
					Tag = new { id = album.id }
				};
				ArtistAlbumTree.Nodes.Add(node);
			}
		}

		public void ShowServerList()
		{
			var dlg = new FormServerList();
			dlg.ShowDialog();
			ShowPanel();
			SetupAPI();
		}

		private void PreferencesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowServerList();
		}

		private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void ToolStripConnectionLabel_Click(object sender, EventArgs e)
		{
			ShowServerList();
		}

		private void FormMusicBrowser_FormClosing(object sender, FormClosingEventArgs e)
		{
			TimerTrackbar.Stop();
			TimerDiscord.Stop();

			player.Pause();
			player.Dispose();
			playerHasDisposed = true;

			if (discord != null && discord?.IsInitialized == true)
			{
				discord.ClearPresence();
				discord.Invoke();
				discord.Dispose();
			}
		}

		private void TimerTrackbar_Tick(object sender, EventArgs e)
		{
			if (currentSong == -1)
			{
				ToolStripSongInfo.Text = "Not Playing";
				return;
			};

			if (!IsPlaying) return;

			// Update status bar
			var posHuman = SubsonicAPI.HumanDuration((int)player.PlaybackSession.Position.TotalSeconds);
			var durHuman = SubsonicAPI.HumanDuration(songs[currentSong].duration);
			ToolStripSongInfo.Text = $"{posHuman} / {durHuman}";

			// Update trackbar
			var pos = player.PlaybackSession.Position.TotalMilliseconds;
			var len = (double)songs[currentSong].duration * 1000;
			if (pos > 0.0 && len > 0.0)
			{
				var pct = Math.Min(pos / len * 1000, 1000);
				TrackBarSeek.Value = (int)pct;
			}
		}

		private void SongSeek()
		{
			var pct = (double)TrackBarSeek.Value / 1000;
			var ticks = (int)(songs[currentSong].duration * pct);
			player.PlaybackSession.Position = new TimeSpan(0, 0, ticks);

			SetDiscordRichPresence(songs[currentSong], IsPlaying);
		}

		private void TrackBarSeek_Scroll(object sender, EventArgs e)
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
					if (TrackBarSeek.Value == (int)trackBarScrollTimer.Tag)
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
						trackBarScrollTimer.Tag = TrackBarSeek.Value;
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

		private async void PlaySong(Child song)
		{
			TimerTrackbar.Stop();
			TrackBarSeek.Value = 0;

			var uri = await api.StreamTrack(song.id);
			var src = MediaSource.CreateFromUri(uri);
			var pb = new MediaPlaybackItem(src);

			var props = pb.GetDisplayProperties();
			props.Type = MediaPlaybackType.Music;
			props.MusicProperties.AlbumArtist = song.artist;
			props.MusicProperties.AlbumTitle = song.album;
			props.MusicProperties.Title = song.title;
			props.MusicProperties.TrackNumber = (uint)song.track;
			pb.ApplyDisplayProperties(props);

			player.Source = pb;
			player.Play();

			TimerTrackbar.Start();
			RefreshQueueList();

			DisplayCoverArt(song.coverArt);

			// Download next song, if possible
			if (currentSong + 1 < songs.Count)
			{
				await api.StreamTrack(songs[currentSong + 1].id);
				RefreshQueueList();
			}
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
			ListSongQueue.Items.Clear();

			var index = 0;
			var totalDuration = 0;
			foreach (var song in songs)
			{
				var item = new ListViewItem();
				if (index == currentSong)
				{
					item.ImageIndex = IsPlaying ? 0 : 1;
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

				var hasCached = File.Exists($"{DataServerList.AudioCacheDir}\\{song.id}");
				var trackCachedItem = new ListViewItem.ListViewSubItem
				{ Text = hasCached ? "✔" : "" };
				item.SubItems.Add(trackCachedItem);

				ListSongQueue.Items.Add(item);
				index++;
			}

			var statusBarText = $"Total: {SubsonicAPI.HumanDuration(totalDuration)} ({songs.Count} songs in queue)";
			ToolStripQueueInfo.Text = statusBarText;
		}

		private void ButtonPlayPause_Click(object sender, EventArgs e)
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
			var source = player.Source as MediaPlaybackItem;
			var pb = source.GetDisplayProperties();
			try
			{
				if (coverArt == null) return;
				var artPath = await api.GetCoverArt(coverArt);
				PictureBoxCoverArt.Image = Image.FromFile(artPath);

				// Set notification image
				var f = await StorageFile.GetFileFromPathAsync(artPath);
				pb.Thumbnail = RandomAccessStreamReference.CreateFromFile(f);
			}
			catch (Exception)
			{
				// Ignore error and clear image
				PictureBoxCoverArt.Image = null;
				pb.Thumbnail = null;
			}

			source.ApplyDisplayProperties(pb);
			player.Source = source;
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

		private void ArtistAlbumTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Node.Level != 0) return;

			dynamic tag = e.Node.Tag;
			string id = tag.id;
			var playNow = currentSong == -1;

			PlayAlbum(id, playNow);
		}

		private void ListSongQueue_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			var items = ListSongQueue.SelectedIndices;
			if (items.Count == 0) return;

			currentSong = items[0];
			PlaySong(songs[currentSong]);
		}

		private void ArtistAlbumTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			ArtistAlbumTree.SelectedNode = e.Node;

			if (e.Button != MouseButtons.Right) return;
			if (e.Node.Level != 0) return;

			ContextMenuArtistsAlbums.Show(Cursor.Position);
		}

		private void PlayNowToolStripMenuItem_Click(object sender, EventArgs e)
		{
			dynamic tag = ArtistAlbumTree.SelectedNode.Tag;
			string id = tag.id;

			PlayAlbum(id, true);
		}

		private void AddToQueueToolStripMenuItem_Click(object sender, EventArgs e)
		{
			dynamic tag = ArtistAlbumTree.SelectedNode.Tag;
			string id = tag.id;

			PlayAlbum(id, false);
		}

		private void ButtonSkipForwards_Click(object sender, EventArgs e)
		{
			SkipSong(1);
		}

		private void ButtonSkipBackwards_Click(object sender, EventArgs e)
		{
			SkipSong(-1);
		}

		private void ListSongQueue_KeyUp(object sender, KeyEventArgs e)
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
				foreach (int index in ListSongQueue.SelectedIndices)
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
				if (ListSongQueue.SelectedIndices.Count == 0) return;

				currentSong = ListSongQueue.SelectedIndices[0];
				PlaySong(songs[currentSong]);
			}
		}

		private void TimerDiscord_Tick(object sender, EventArgs e)
		{
			if (discord == null || discord.IsDisposed || !discord.IsInitialized) return;

			discord.Invoke();
		}

		private void ServerListToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowServerList();
		}

		private void ScrobbleToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			DataServerList.ShouldScrobble = ScrobbleToolStripMenuItem.Checked;
			DataServerList.SaveConfig();
		}

		private void DiscordRichPresenceToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			DataServerList.UseDiscordRichPresence = DiscordRichPresenceToolStripMenuItem.Checked;
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

		private void SourceCodeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("https://git.tombo.sh/tom/dotnet-demonic");
		}

		private void clearCacheToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Try to delete all files in both Audio and Art directories,
			// but fail silently if, for example, the file is in use.
			foreach (var file in System.IO.Directory.EnumerateFiles(DataServerList.AudioCacheDir))
			{
				try { File.Delete(file); } catch (Exception) { }
			}

			foreach (var file in System.IO.Directory.EnumerateFiles(DataServerList.ArtCacheDir))
			{
				try { File.Delete(file); } catch (Exception) { }
			}

			RefreshQueueList();
		}
	}
}
