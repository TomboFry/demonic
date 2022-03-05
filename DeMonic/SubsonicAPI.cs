using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Xml;
using System.Xml.Serialization;

namespace DeMonic
{
	public class SubsonicAPI
	{
		private HttpClient client;
		public bool Connected { get; private set; }
		public Dictionary<string, List<AlbumID3>> artistsAlbums = new Dictionary<string, List<AlbumID3>>();

		public async Task SetupClient ()
		{

			if (DataServerList.ActiveServer == null)
			{
				Console.WriteLine("No active server, closing");
				return;
			}

			var activeServer = DataServerList.ActiveServer.Value;

			var http = activeServer.useHTTPS ? "https" : "http";
			var baseUrl = new Uri($"{http}://{activeServer.host}");

			client = new HttpClient
			{
				BaseAddress = baseUrl,
				Timeout = new TimeSpan(0, 0, 30),
			};

			Connected = await Ping();
		}

		private string GetBaseQuery()
		{
			var activeServer = DataServerList.ActiveServer;
			var query = "?c=DeMonic"
				+  "&v=1.15.0"
				+  "&f=xml"
				+ $"&u={activeServer?.username}"
				+ $"&t={activeServer?.password}"
				+ $"&s={activeServer?.salt}";

			return query;
		}

		public Uri GetFullUri(string path, string query)
		{
			return new Uri($"{client.BaseAddress}/rest/{path}{GetBaseQuery()}&{query}");
		}

		private async Task<Stream> MakeBinaryRequest(string path, string query)
		{
			var response = await client.GetAsync(GetFullUri(path, query));
			return await response.Content.ReadAsStreamAsync();
		}

		private async Task<SubsonicResponse> MakeRequest(string path, string query)
		{
			var content = await MakeBinaryRequest(path, query);

			XmlSerializer serializer = new XmlSerializer(typeof(SubsonicResponse));
			var xml = (SubsonicResponse)serializer.Deserialize(content);

			return xml;
		}

		public async Task<bool> Ping()
		{
			var response = await MakeRequest("ping", "");
			return response.status == ResponseStatus.ok;
		}

		public async Task GetAlbums()
		{
			var done = false;
			var offset = 0;
			var pageSize = 250;
			var results = new List<AlbumID3>();
			
			while(done == false)
			{
				var query = "type=newest"
					+ $"&size={pageSize}"
					+ $"&offset={offset}";

				var response = await MakeRequest("getAlbumList2", query);
				var albums = (AlbumList2)response.Item;

				if (albums.album == null || albums.album.Length == 0)
				{
					done = true;
				}
				else
				{
					results.AddRange(albums.album);
					offset += pageSize;
				}
			}

			// Sort by artist, then album year, then album name
			results.Sort((a, b) => string.Compare(
				$"{a.artist}-{a.year}-{a.name}",
				$"{b.artist}-{b.year}-{b.name}",
				true
			));

			var sorted = new Dictionary<string, List<AlbumID3>>();

			foreach (var result in results)
			{
				if (!sorted.ContainsKey(result.artist))
				{
					sorted.Add(result.artist, new List<AlbumID3>());
				}

				sorted[result.artist].Add(result);
			}

			artistsAlbums = sorted;
		}

		public async Task<Image> GetCoverArt(string id)
		{
			return Image.FromStream(await MakeBinaryRequest("getCoverArt", $"id={id}&size=224"));
		}

		public static string PadNumber(int number)
		{
			var pad = "";
			if (number < 10)
			{
				pad = "0";
			}
			return $"{pad}{number}";
		}

		public static string HumanDuration (int duration)
		{
			var minutes = (int)Math.Floor((float)duration / 60);
			var seconds = duration % 60;
			return $"{PadNumber(minutes)}:{PadNumber(seconds)}";
		}

		public async Task<AlbumWithSongsID3> GetTrackList(string albumId)
		{
			var response = await MakeRequest("getAlbum", $"id={albumId}");
			return (AlbumWithSongsID3)response.Item;
		}

		public async void Scrobble(Child song)
		{
			var currentTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - (song.duration * 1000);
			await MakeRequest("scrobble", $"id={song.id}&time={currentTime}");
		}
	}
}
