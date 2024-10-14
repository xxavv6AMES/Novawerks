using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace NovawerksApp
{
    public partial class SettingsPage : Page
    {
        private const string SettingsFilePath = "settings.json";
        private const string CurrentVersion = "0.8.0-EA"; 
        private const string GitHubReleasesApiUrl = "https://api.github.com/repos/xxavv6AMES/Novawerks/releases/latest"; 

        // Define colors for highlighting
        private const string InactiveTextColor = "#FFFFFF"; 
        private const string ActiveTextColor = "#FF5722"; 

        public SettingsPage()
        {
            InitializeComponent();
            LoadTheme("Dark"); // Set default theme
        }

        private void LoadTheme(string theme)
        {
            ResourceDictionary resourceDict = new ResourceDictionary();

            switch (theme)
            {
                case "Light":
                    resourceDict.Source = new Uri("Themes/LightTheme.xaml", UriKind.Relative);
                    break;
                case "Dark":
                default:
                    resourceDict.Source = new Uri("Themes/DarkTheme.xaml", UriKind.Relative);
                    break;
            }

            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void ApplySettings_Click(object sender, RoutedEventArgs e)
        {
            string selectedTheme = (ThemeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            LoadTheme(selectedTheme);
            MessageBox.Show($"{selectedTheme} theme applied!");
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Logout Clicked!");
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
            UpdateProgressWindow updateProgressWindow = new UpdateProgressWindow();
            updateProgressWindow.Show();

            try
            {
                var (latestVersion, downloadUrl) = await GetLatestReleaseVersionFromGitHub();

                if (string.IsNullOrEmpty(latestVersion) || latestVersion == CurrentVersion || string.IsNullOrEmpty(downloadUrl))
                {
                    MessageBox.Show("No update available.");
                    updateProgressWindow.Close(); 
                    return;
                }

                CleanOldTempFiles();
                string tempFilePath = Path.Combine(Path.GetTempPath(), "NDESetup.exe");

                updateProgressWindow.UpdateProgress("Downloading update...");

                await DownloadFileAsync(downloadUrl, tempFilePath, updateProgressWindow);

                updateProgressWindow.UpdateProgress("Installing update...");

                InstallUpdate(tempFilePath);
                updateProgressWindow.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error downloading or installing update: {ex.Message}");
                updateProgressWindow.Close();
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

                    string latestVersionTag = releaseData["tag_name"]?.ToString();
                    string latestVersion = latestVersionTag?.TrimStart('v');

                    var assets = releaseData["assets"] as JArray;
                    string downloadUrl = assets?
                        .FirstOrDefault(asset => asset["name"]?.ToString() == "NDESetup.exe")?
                        ["browser_download_url"]?.ToString();

                    return (latestVersion, downloadUrl);
                }
                else
                {
                    throw new Exception("Failed to fetch latest release data from GitHub.");
                }
            }
        }

        private async Task DownloadFileAsync(string url, string outputPath, UpdateProgressWindow progressWindow)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("User-Agent", "NovawerksApp");
                    using (HttpResponseMessage response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
                    {
                        response.EnsureSuccessStatusCode();

                        var totalBytes = response.Content.Headers.ContentLength ?? -1L;
                        var canReportProgress = totalBytes != -1L;

                        using (Stream contentStream = await response.Content.ReadAsStreamAsync(),
                               fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
                        {
                            var totalRead = 0L;
                            var buffer = new byte[8192];
                            int bytesRead;

                            while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                await fileStream.WriteAsync(buffer, 0, bytesRead);
                                totalRead += bytesRead;

                                if (canReportProgress)
                                {
                                    var progress = (totalRead * 100) / totalBytes;
                                    progressWindow.UpdateProgress($"Downloading update...", progress);
                                }
                            }
                        }

                        progressWindow.UpdateProgress("Download complete.", 100);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error downloading update: {ex.Message}");
                progressWindow.UpdateProgress("Error downloading update.");
            }
        }

        private void InstallUpdate(string filePath)
        {
            try
            {
                if (File.Exists(filePath) && Path.GetExtension(filePath).Equals(".exe", StringComparison.OrdinalIgnoreCase))
                {
                    var processStartInfo = new ProcessStartInfo
                    {
                        FileName = filePath,
                        Arguments = "/silent",
                        UseShellExecute = true,
                        Verb = "runas"
                    };

                    Process.Start(processStartInfo);
                    Application.Current.Shutdown();
                }
                else
                {
                    MessageBox.Show("Update file not found or invalid file format.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during update process: {ex.Message}");
            }
        }

        private void CleanOldTempFiles()
        {
            var tempDirectory = Path.GetTempPath();
            var oldTempFiles = Directory.GetFiles(tempDirectory, "NDESetup*.exe");
            foreach (var oldFile in oldTempFiles)
            {
                try
                {
                    File.Delete(oldFile);
                }
                catch (Exception)
                {
                }
            }
        }

        private void OpenChangelog_Click(object sender, RoutedEventArgs e)
        {
            string changelogUrl = "https://github.com/xxavv6AMES/Novawerks/releases/tag/v0.8.0-EA";
            Process.Start(new ProcessStartInfo
            {
                FileName = changelogUrl,
                UseShellExecute = true
            });
        }

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

        private void HighlightCurrentPage(string activePageName = "MainPageMenuItem")
        {
            MainPageMenuItem.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(InactiveTextColor));
            ForumPageMenuItem.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(InactiveTextColor));
            NWASPageMenuItem.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(InactiveTextColor));

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
        }
    }
}
