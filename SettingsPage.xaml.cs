using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows;
using System.Windows.Controls;

namespace NovawerksApp
{
    public partial class SettingsPage : Page
    {
        private const string SettingsFilePath = "settings.json";
        private const string CurrentVersion = "0.6.0-EA"; // Current version of the app
        private const string GitHubReleasesApiUrl = "https://api.github.com/repos/xxavv6AMES/Novawerks/releases/latest"; // Replace with your actual repository URL
        private const string GitHubDownloadUrlBase = "https://github.com/xxavv6AMES/Novawerks/releases/download/"; // Base URL for download links

        public SettingsPage()
        {
            InitializeComponent();
            LoadUserSettings();
        }

        private void LoadUserSettings()
        {
            if (File.Exists(SettingsFilePath))
            {
                var jsonData = File.ReadAllText(SettingsFilePath);
                var userSettings = JsonConvert.DeserializeObject<UserSettings>(jsonData);

                if (userSettings != null)
                {
                    UsernameTextBox.Text = userSettings.Username ?? string.Empty;
                    EmailTextBox.Text = userSettings.Email ?? string.Empty;
                    ThemeComboBox.SelectedIndex = userSettings.Theme == "Dark" ? 1 : 0;
                }
            }
        }

        private void UpdateAccount_Click(object sender, RoutedEventArgs e)
        {
            var userSettings = new UserSettings
            {
                Username = UsernameTextBox.Text,
                Email = EmailTextBox.Text,
                Theme = (ThemeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString()
            };

            var jsonData = JsonConvert.SerializeObject(userSettings, Formatting.Indented);
            File.WriteAllText(SettingsFilePath, jsonData);

            MessageBox.Show("Account settings updated successfully.");
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
                string latestVersion = await GetLatestReleaseVersionFromGitHub();

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
                string latestVersion = await GetLatestReleaseVersionFromGitHub();

                if (string.IsNullOrEmpty(latestVersion) || latestVersion == CurrentVersion)
                {
                    MessageBox.Show("No update available.");
                    return;
                }

                string downloadUrl = $"{GitHubDownloadUrlBase}v{latestVersion}/NDE.Setup.exe"; // Adjust the URL if needed
                string tempFilePath = Path.GetTempFileName();

                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.GetAsync(downloadUrl))
                    {
                        response.EnsureSuccessStatusCode();
                        byte[] fileBytes = await response.Content.ReadAsByteArrayAsync();
                        await File.WriteAllBytesAsync(tempFilePath, fileBytes);
                    }
                }

                Process.Start(new ProcessStartInfo
                {
                    FileName = tempFilePath,
                    UseShellExecute = true
                });

                Application.Current.Shutdown(); // Optionally shut down the app after starting the installer
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error downloading or installing update: {ex.Message}");
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

        private void OpenChangelog_Click(object sender, RoutedEventArgs e)
        {
            string changelogUrl = "https://github.com/xxavv6AMES/Novawerks/releases/tag/v0.6.0"; // Replace with actual URL

            Process.Start(new ProcessStartInfo
            {
                FileName = changelogUrl,
                UseShellExecute = true
            });
        }
    }

    public class UserSettings
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Theme { get; set; }
    }
}
