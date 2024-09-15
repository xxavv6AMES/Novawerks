using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Supabase;

namespace NovawerksApp
{
    public partial class SettingsPage : Page
    {
        private const string SettingsFilePath = "settings.json";
        private const string CurrentVersion = "0.7.0-EA"; // Current version of the app
        private const string GitHubReleasesApiUrl = "https://api.github.com/repos/xxavv6AMES/Novawerks/releases/latest"; // Replace with your actual repository URL

        // Define colors for highlighting
        private const string InactiveTextColor = "#FFFFFF"; // Example: white for inactive
        private const string ActiveTextColor = "#FF5722"; // Example: orange for active

        public SettingsPage()
        {
            InitializeComponent();
        }

        private void ApplySettings_Click(object sender, RoutedEventArgs e)
        {
            string selectedTheme = (ThemeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (selectedTheme == "Light")
            {
                // Apply light theme logic
                MessageBox.Show("Light theme applied!");
            }
            else if (selectedTheme == "Dark")
            {
                // Apply dark theme logic
                MessageBox.Show("Dark theme applied!");
            }
        }

        private async void CheckForUpdates_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var (latestVersion, downloadUrl) = await GetLatestReleaseVersionFromGitHub();

                if (!string.IsNullOrEmpty(latestVersion) && latestVersion != CurrentVersion)
                {
                    MessageBox.Show($"A new version is available! Current: {CurrentVersion}, Latest: {latestVersion}.\nPlease update to the latest version.");
                }
                else
                {
                    MessageBox.Show("You are up to date!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking for updates: {ex.Message}");
            }
        }

        private async void DownloadAndInstallUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var (latestVersion, downloadUrl) = await GetLatestReleaseVersionFromGitHub();

                if (string.IsNullOrEmpty(latestVersion) || latestVersion == CurrentVersion || string.IsNullOrEmpty(downloadUrl))
                {
                    MessageBox.Show("No update available.");
                    return;
                }

                // Download the update
                string tempFilePath = Path.GetTempFileName();
                await DownloadFileAsync(downloadUrl, tempFilePath);

                // Install the update
                InstallUpdate(tempFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error downloading or installing update: {ex.Message}");
            }
        }

        private async Task<(string, string)> GetLatestReleaseVersionFromGitHub()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "NovawerksApp");

                HttpResponseMessage response = await client.GetAsync(GitHubReleasesApiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    JObject releaseData = JObject.Parse(jsonResponse);

                    // Extract the latest version tag name and download URL
                    string latestVersionTag = releaseData["tag_name"]?.ToString();
                    string latestVersion = latestVersionTag?.TrimStart('v');

                    var assets = releaseData["assets"] as JArray;
                    string downloadUrl = assets?
                        .FirstOrDefault(asset => asset["name"]?.ToString() == "NDE.Setup.exe")?
                        ["browser_download_url"]?.ToString();

                    return (latestVersion, downloadUrl);
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
            try
            {
                // Ensure that the file exists
                if (File.Exists(filePath))
                {
                    // Start the installer process
                    var processStartInfo = new ProcessStartInfo
                    {
                        FileName = filePath,
                        Arguments = "/silent", // Use silent or any other arguments if needed
                        UseShellExecute = true, // Ensures the file is executed with the default application
                        Verb = "runas" // Optional: Run as administrator
                    };

                    Process.Start(processStartInfo);
                    Application.Current.Shutdown(); // Close the current application
                }
                else
                {
                    MessageBox.Show("Update file not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during update process: {ex.Message}");
            }
        }

        private void OpenChangelog_Click(object sender, RoutedEventArgs e)
        {
            string changelogUrl = "https://github.com/xxavv6AMES/Novawerks/releases/tag/v0.7.0-EA"; // Replace with actual URL

            Process.Start(new ProcessStartInfo
            {
                FileName = changelogUrl,
                UseShellExecute = true
            });
        }

        // Sidebar Button Click Event Handlers
        private void MainPageButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
            HighlightCurrentPage("MainPageMenuItem");
        }

        private void ForumPageButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ForumPage());
            HighlightCurrentPage("ForumPageMenuItem");
        }

        private void NWASPageButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NWAS());
            HighlightCurrentPage("NWASPageMenuItem");
        }

        // Highlight the current page in the menu
        private void HighlightCurrentPage(string activePageName = "MainPageMenuItem")
        {
            // Reset all menu items to inactive color
            MainPageMenuItem.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(InactiveTextColor));
            ForumPageMenuItem.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(InactiveTextColor));
            NWASPageMenuItem.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(InactiveTextColor));

            // Highlight the current page
            var activeTextBlock = FindName(activePageName) as TextBlock;
            if (activeTextBlock != null)
            {
                activeTextBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(ActiveTextColor));
            }
        }

        public class UserSettings
        {
            public string Username { get; set; }
            public string Email { get; set; }
            public string Theme { get; set; }
        }
    }
}
