using System;
using System.Windows.Forms;

namespace DeMonic
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// Step 1: Create AppData directory and subfolders
			System.IO.Directory.CreateDirectory(DataServerList.AudioCacheDir);
			System.IO.Directory.CreateDirectory(DataServerList.ArtCacheDir);

			// Step 2: Load saved servers
			DataServerList.LoadConfig();

			// Step 3: Show main browser
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FormMusicBrowser());
		}
	}
}
