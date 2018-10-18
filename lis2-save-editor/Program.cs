using System;
using System.Windows.Forms;
using System.Reflection;
using System.Text;

namespace lis2_save_editor
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
            Application.Run(new MainForm());
        }

        public static Version GetApplicationVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version;
        }

        public static string GetApplicationVersionStr()
        {
            var version = GetApplicationVersion();
            var sb = new StringBuilder();
            sb.Append($"{version.Major}.{version.Minor}");
            if (version.Build != 0)
            {
                sb.Append($".{version.Build}");
            }
            return sb.ToString();
        }
    }
}
