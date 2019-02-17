namespace lis2_save_editor
{
    public class Settings
    {
        public Settings()
        {
            CheckForUpdatesAtStartup = true;
        }

        public string SavePath { get; set; }

        public bool CheckForUpdatesAtStartup { get; set; }
    }
}
