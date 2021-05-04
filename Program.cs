using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spotify_Beatmap_Downloader
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(await Form1.Create());
        }
    }
}