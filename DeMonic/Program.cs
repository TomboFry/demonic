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
			// Step 1: Load saved servers
			DataServerList.LoadConfig();

			// Step 2: Show main browser
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FormMusicBrowser());
		}
	}
}
