using System;
using System.Windows.Forms;

namespace TG01U2_Convalidacion_Atencio_Neciosup_A
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new ConsultasyGraficos());
        }
    }
}
