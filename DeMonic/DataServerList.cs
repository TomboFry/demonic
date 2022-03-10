using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace DeMonic
{
	[XmlRoot("Config")]
	public class DataServerListXML
	{
		public List<Server> Servers;
		public bool ShouldScrobble;
		public bool UseDiscordRichPresence;
	}

	public class DataServerList
	{
		public static List<Server> serverList;
		public static bool ShouldScrobble = true;
		public static bool UseDiscordRichPresence = true;

		private readonly static string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\DeMonic";
		private readonly static string configPath = $"{AppData}\\config.xml";
		public readonly static string AudioCacheDir = $"{AppData}\\cache\\audio";
		public readonly static string ArtCacheDir = $"{AppData}\\cache\\art";

		public static Server? ActiveServer
		{
			get
			{
				var server = serverList.Find(srv => srv.Active);
				if (server.Username == null && server.Host == null)
				{
					return null;
				}
				return server;
			}
		}

		public static void AddServer(Server server)
		{
			serverList.Add(server);
			SaveConfig();
		}

		public static void UseServer(int index)
		{
			for (int i = serverList.Count - 1; i >= 0; i--)
			{
				var srv = serverList[i];
				var active = i == index;
				serverList[i] = new Server(srv.Host, srv.Username, srv.Password, srv.UseHTTPS, active, srv.Salt);
			}
			SaveConfig();
		}

		public static void RemoveServer(int index)
		{
			serverList.RemoveAt(index);
			SaveConfig();
		}

		public static void LoadConfig()
		{
			if (!File.Exists(configPath)) return;

			XmlReader reader = XmlReader.Create(configPath);
			XmlSerializer serializer = new XmlSerializer(typeof(DataServerListXML));
			var config = (DataServerListXML)serializer.Deserialize(reader);
			reader.Close();

			serverList = config.Servers;
			ShouldScrobble = config.ShouldScrobble;
			UseDiscordRichPresence = config.UseDiscordRichPresence;
		}

		public static void SaveConfig()
		{
			var settings = new XmlWriterSettings()
			{
				Indent = true,
				CloseOutput = true,
			};

			var fs = XmlWriter.Create(configPath, settings);
			var tool = new XmlSerializer(typeof(DataServerListXML));
			var config = new DataServerListXML()
			{
				Servers = serverList,
				ShouldScrobble = ShouldScrobble,
				UseDiscordRichPresence = UseDiscordRichPresence,
			};

			tool.Serialize(fs, config);
			fs.Flush();
			fs.Close();
		}

		static DataServerList()
		{
			serverList = new List<Server>();
		}
	}
}
