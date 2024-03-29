﻿using System;
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
		private HttpClient Client;
		public bool Connected { get; private set; }
		public List<AlbumID3> Albums = new List<AlbumID3>();

		public async Task SetupClient ()
		{
			if (DataServerList.ActiveServer == null)
			{
				Console.WriteLine("No active server, closing");
				return;
			}

			var activeServer = DataServerList.ActiveServer.Value;

			var http = activeServer.UseHTTPS ? "https" : "http";
			var baseUrl = new Uri($"{http}://{activeServer.Host}");

			Client = new HttpClient
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
				+ $"&u={activeServer?.Username}"
				+ $"&t={activeServer?.Password}"
				+ $"&s={activeServer?.Salt}";

			return query;
		}

		public Uri GetFullUri(string path, string query)
		{
			return new Uri($"{Client.BaseAddress}/rest/{path}{GetBaseQuery()}&{query}");
		}

		private async Task<Stream> MakeBinaryRequest(string path, string query)
		{
			var response = await Client.GetAsync(GetFullUri(path, query));
			return await response.Content.ReadAsStreamAsync();
		}

		private async Task<byte[]> MakeBinaryRequestBytes(string path, string query)
		{
			var response = await Client.GetAsync(GetFullUri(path, query));
			return await response.Content.ReadAsByteArrayAsync();
		}

		private async Task<SubsonicResponse> MakeRequest(string path, string query)
		{
			var content = await MakeBinaryRequest(path, query);

			XmlSerializer serializer = new XmlSerializer(typeof(SubsonicResponse));
			return (SubsonicResponse)serializer.Deserialize(content);
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
			
			// Page through results until we get no more
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

			Albums = results;
		}

		public async Task<string> GetCoverArt(string id)
		{
			var savePath = $"{DataServerList.ArtCacheDir}\\{id}";

			if (File.Exists(savePath)) return savePath;

			var data = await MakeBinaryRequestBytes("getCoverArt", $"id={id}&size=256");
			File.WriteAllBytes(savePath, data);

			return savePath;
		}

		public async Task<Uri> StreamTrack(string trackId)
		{
			var savePath = $"{DataServerList.AudioCacheDir}\\{trackId}";

			if (File.Exists(savePath)) return new Uri(savePath);

			var data = await MakeBinaryRequestBytes("stream", $"id={trackId}");
			File.WriteAllBytes(savePath, data);

			return new Uri(savePath);
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
			var hours = (int)Math.Floor((float) duration / 3600);
			var minutes = (int)Math.Floor((float)duration / 60) % 60;
			var seconds = duration % 60;
			var time = $"{PadNumber(minutes)}:{PadNumber(seconds)}";

			if(hours > 0)
			{
				time = $"{hours}:{time}";
			}

			return time;
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
