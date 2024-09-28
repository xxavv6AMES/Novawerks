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
using Auth0.OidcClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Threading.Tasks;
using System.Net;
using Microsoft.IdentityModel.Logging;
using System.Net.Http;

namespace NovawerksApp
{
    public partial class SettingsPage : Page
    {
        private const string SettingsFilePath = "settings.json";
        private const string CurrentVersion = "0.8.0-EA"; // Current version of the app
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
        private void Logout_Click(object sender, RoutedEventArgs e) => MessageBox.Show("Logout Clicked!");
        

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
        Console.WriteLine("Checking for the latest release version from GitHub...");
        var (latestVersion, downloadUrl) = await GetLatestReleaseVersionFromGitHub();

        if (string.IsNullOrEmpty(latestVersion) || latestVersion == CurrentVersion || string.IsNullOrEmpty(downloadUrl))
        {
            Console.WriteLine("No update available.");
            MessageBox.Show("No update available.");
            return;
        }

        Console.WriteLine($"Update available. Latest version: {latestVersion}");

        // Download the update to a file with a proper .exe extension
        string tempFilePath = Path.Combine(Path.GetTempPath(), "NDE.Setup.exe");
        Console.WriteLine($"Downloading update to: {tempFilePath}");
        await DownloadFileAsync(downloadUrl, tempFilePath);

        // Verify that the file is downloaded successfully
        if (File.Exists(tempFilePath))
        {
            Console.WriteLine($"File downloaded successfully: {tempFilePath}");
            MessageBox.Show("File downloaded successfully.");
        }
        else
        {
            Console.WriteLine("Failed to download the update.");
            MessageBox.Show("Failed to download the update.");
            return;
        }

        // Install the update
        Console.WriteLine("Starting the update installation...");
        InstallUpdate(tempFilePath);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error downloading or installing update: {ex.Message}");
        MessageBox.Show($"Error downloading or installing update: {ex.Message}");
    }
}

private async Task<(string, string)> GetLatestReleaseVersionFromGitHub()
{
    using (HttpClient client = new HttpClient())
    {
        client.DefaultRequestHeaders.Add("User-Agent", "NovawerksApp");

        Console.WriteLine("Fetching release data from GitHub...");
        HttpResponseMessage response = await client.GetAsync(GitHubReleasesApiUrl);
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Successfully fetched release data.");
            string jsonResponse = await response.Content.ReadAsStringAsync();
            JObject releaseData = JObject.Parse(jsonResponse);

            // Extract the latest version tag name and download URL
            string latestVersionTag = releaseData["tag_name"]?.ToString();
            string latestVersion = latestVersionTag?.TrimStart('v');

            var assets = releaseData["assets"] as JArray;
            string downloadUrl = assets?
                .FirstOrDefault(asset => asset["name"]?.ToString() == "NDE.Setup.exe")?
                ["browser_download_url"]?.ToString();

            Console.WriteLine($"Latest version: {latestVersion}, Download URL: {downloadUrl}");
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
            Console.WriteLine("Downloading file...");
            using (Stream contentStream = await response.Content.ReadAsStreamAsync(),
                   fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
            {
                await contentStream.CopyToAsync(fileStream);
            }
            Console.WriteLine("Download completed.");
        }
    }
}

private void InstallUpdate(string filePath)
{
    try
    {
        // Ensure that the file exists and is an executable
        if (File.Exists(filePath))
        {
            if (Path.GetExtension(filePath).Equals(".exe", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("File is a valid executable. Starting installer...");

                // Start the installer process
                var processStartInfo = new ProcessStartInfo
                {
                    FileName = filePath,
                    Arguments = "/silent", // Use silent or any other arguments if needed
                    UseShellExecute = true, // Ensures the file is executed with the default application
                    Verb = "runas" // Optional: Run as administrator
                };

                Process.Start(processStartInfo);
                Console.WriteLine("Installer launched successfully. Shutting down application.");
                Application.Current.Shutdown(); // Close the current application
            }
            else
            {
                Console.WriteLine("Downloaded file is not a valid executable.");
                MessageBox.Show("Downloaded file is not a valid executable.");
            }
        }
        else
        {
            Console.WriteLine("Update file not found.");
            MessageBox.Show("Update file not found.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error during update process: {ex.Message}");
        MessageBox.Show($"Error during update process: {ex.Message}");
    }
}


        private void OpenChangelog_Click(object sender, RoutedEventArgs e)
        {
            string changelogUrl = "https://github.com/xxavv6AMES/Novawerks/releases/tag/v0.8.0-EA"; // Replace with actual URL

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

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = e.Uri.ToString(),
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open link: {ex.Message}");
            }
            e.Handled = true;
        }
        public class UserSettings
        {
            public string Username { get; set; }
            public string Email { get; set; }
            public string Theme { get; set; }
        }
    }
}
