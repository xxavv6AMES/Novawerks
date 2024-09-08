using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json.Linq;

namespace NovawerksApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string TutorialShownFile = "tutorial_shown.txt";
        private const string CurrentVersion = "0.6.0-EA"; // Current version of the app
        private const string GitHubReleasesApiUrl = "https://api.github.com/repos/xxavv6AMES/Novawerks/releases/latest"; // Replace with your actual repository URL
        private const string DownloadUrlBase = "https://github.com/xxavv6AMES/Novawerks/releases/download/";

        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            // Check if the tutorial has been shown before
            if (!File.Exists(TutorialShownFile))
            {
                // Show tutorial overlay
                var tutorialOverlay = new TutorialOverlay();
                tutorialOverlay.ShowDialog();

                // Create file to mark tutorial as shown
                File.Create(TutorialShownFile).Dispose();
            }

            try
            {
                // Check for updates
                string latestVersion = await GetLatestReleaseVersionFromGitHub();

                if (!string.IsNullOrEmpty(latestVersion) && latestVersion != CurrentVersion)
                {
                    // Show the progress window and start the update process
                    UpdateProgressWindow updateProgressWindow = new UpdateProgressWindow(latestVersion);
                    updateProgressWindow.Show();

                    // Download and install the update
                    string updateUrl = $"{DownloadUrlBase}v{latestVersion}/NDE.Setup.exe";
                    string tempFilePath = Path.GetTempFileName();

                    // Close the main window and update
                    Application.Current.MainWindow?.Close();
                    InstallUpdate(tempFilePath);
                    
                    await DownloadFileAsync(updateUrl, tempFilePath);

                    // Relaunch the application
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = Process.GetCurrentProcess().MainModule.FileName,
                        UseShellExecute = true
                    });

                    Application.Current.Shutdown();
                }
                else
                {
                    // Proceed with normal startup
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during update process: {ex.Message}");
                // Proceed with normal startup in case of an error
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
        }

        private async Task<string> GetLatestReleaseVersionFromGitHub()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "NovawerksApp");

                HttpResponseMessage response = await client.GetAsync(GitHubReleasesApiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    JObject releaseData = JObject.Parse(jsonResponse);
                    string latestVersionTag = releaseData["tag_name"]?.ToString();
                    return latestVersionTag?.TrimStart('v');
                }
                else
                {
                    throw new Exception("Failed to fetch latest release data from GitHub.");
                }
            }
        }

        private async Task DownloadFileAsync(string url, string outputPath)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "NovawerksApp");
                using (HttpResponseMessage response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
                {
                    response.EnsureSuccessStatusCode();
                    using (Stream contentStream = await response.Content.ReadAsStreamAsync(), 
                           fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
                    {
                        await contentStream.CopyToAsync(fileStream);
                    }
                }
            }
        }

        private void InstallUpdate(string filePath)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = filePath,
                Arguments = "/silent",
                UseShellExecute = true,
                Verb = "runas"
            });
        }
    }
}
