using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace lis2_save_editor
{
    public class UpdateCheckingResult
    {
        public Version ServerVersion { get; set; }

        public Version LocalVersion { get; set; }

        public bool CanBeUpdated { get; set; }
    }

    public static class UpdateChecker
    {
        private const string GetVersionUrl = "https://api.github.com/repos/ladosha/lis2-save-editor/tags";
        private const string DownloadUpdateUrl = "https://github.com/ladosha/lis2-save-editor/releases";

        public static void VisitDownloadPage()
        {
            Process.Start(DownloadUpdateUrl);
        }

        public static async Task<UpdateCheckingResult> CheckForUpdates()
        {
            var client = new WebClient();
            try
            {
                client.Headers.Add("User-Agent", "lis2-save-editor");
                var latestVersionStr = await client.DownloadStringTaskAsync(GetVersionUrl);
                var latestVersionObj = (JsonConvert.DeserializeObject<JArray>(latestVersionStr))[0]["name"].ToString().Remove(0, 1);
                Version latestVersion;
                if (!Version.TryParse(latestVersionObj, out latestVersion))
                {
                    return null;
                }

                var currentVersion = Program.GetApplicationVersion();

                return new UpdateCheckingResult
                {
                    ServerVersion = latestVersion,
                    LocalVersion = currentVersion,
                    CanBeUpdated = latestVersion.CompareTo(currentVersion) == 1
                };
            }
            // Unable to retrieve latest version from server
            catch (WebException)
            {
                return null;
            }
        }
    }
}
