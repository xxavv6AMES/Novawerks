using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json.Linq;
using System.Windows.Media;

namespace NovawerksApp
{
    public partial class NWAS : Page
    {
        private const string GitHubApiUrl = "https://api.github.com/repos/xxavv6AMES/WerksAddons/releases"; // Replace with your repo's URL

        public NWAS()
        {
            InitializeComponent();
            LoadReleasesAsync();
        }

        // Load GitHub releases asynchronously
        private async Task LoadReleasesAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; NovawerksApp/1.0)");
                    var response = await client.GetStringAsync(GitHubApiUrl);
                    var releases = JArray.Parse(response);

                    foreach (var release in releases)
                    {
                        string releaseName = release["name"].ToString();
                        string releaseTag = release["tag_name"].ToString();
                        string releaseUrl = release["html_url"].ToString();

                        // Create product container for each add-on
                        var releaseContainer = new Border
                        {
                            BorderThickness = new Thickness(2),
                            BorderBrush = new SolidColorBrush(Color.FromRgb(255, 189, 6)), // Accent color for border
                            CornerRadius = new CornerRadius(10),
                            Margin = new Thickness(10),
                            Padding = new Thickness(10),
                            Background = new SolidColorBrush(Color.FromRgb(31, 31, 31)),
                            Width = 300,
                            Height = 200,
                        };

                        // StackPanel to hold content
                        var contentPanel = new StackPanel
                        {
                            Orientation = Orientation.Vertical
                        };

                        // Add Release Name as Title
                        var titleTextBlock = new TextBlock
                        {
                            Text = $"{releaseName} ({releaseTag})",
                            Foreground = new SolidColorBrush(Colors.White),
                            FontWeight = FontWeights.Bold,
                            FontSize = 16,
                            Margin = new Thickness(0, 0, 0, 10)
                        };

                        // Add a short description (Placeholder text, replace with actual if available)
                        var descriptionTextBlock = new TextBlock
                        {
                            Text = "This is a cool addon that enhances your workflow.",
                            Foreground = new SolidColorBrush(Colors.LightGray),
                            FontSize = 14,
                            Margin = new Thickness(0, 0, 0, 10)
                        };

                        // Button to download the add-on
                        var downloadButton = new Button
                        {
                            Content = "Download",
                            Tag = releaseUrl,
                            Width = 100,
                            Height = 30,
                            Background = new SolidColorBrush(Colors.Orange),
                            Foreground = new SolidColorBrush(Colors.Black),
                            FontWeight = FontWeights.Bold
                        };

                        downloadButton.Click += (s, e) => System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = releaseUrl,
                            UseShellExecute = true
                        });

                        // Add title, description, and button to contentPanel
                        contentPanel.Children.Add(titleTextBlock);
                        contentPanel.Children.Add(descriptionTextBlock);
                        contentPanel.Children.Add(downloadButton);

                        // Add contentPanel to releaseContainer
                        releaseContainer.Child = contentPanel;

                        // Add releaseContainer to StackPanel (ReleasesPanel in XAML)
                        ReleasesPanel.Children.Add(releaseContainer);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading releases: {ex.Message}");
            }
        }

        // Back Button Click Event Handler
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
