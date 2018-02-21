using System;//System needed
using System.Windows.Forms;//System.Windows.Forms needed
using AxAXVLC;

namespace RTSP_mosaic_VLC_player
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
