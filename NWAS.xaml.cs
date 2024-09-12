using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
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
            SetupHoverArea();
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

                        // Add release info to UI (you can customize this part)
                        var releaseButton = new Button
                        {
                            Content = $"{releaseName} ({releaseTag})",
                            Tag = releaseUrl,
                            Margin = new Thickness(5),
                            Background = new SolidColorBrush(System.Windows.Media.Colors.Orange)
                        };

                        releaseButton.Click += (s, e) => System.Diagnostics.Process.Start(releaseUrl);
                        ReleasesPanel.Children.Add(releaseButton);
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

        // Handle the Sidebar Button Clicks
        private void MainPageButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }

        private void ForumPageButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ForumPage());
        }

        private void NWASPageButton_Click(object sender, RoutedEventArgs e)
        {
            // No action needed if on the current page
        }

        // Setup hover area for detecting mouse movement
        private void SetupHoverArea()
        {
            HoverArea.MouseEnter += (s, e) => ToggleLeftMenu();
            HoverArea.Width = 10;
            HoverArea.HorizontalAlignment = HorizontalAlignment.Left;
            HoverArea.VerticalAlignment = VerticalAlignment.Stretch;
            HoverArea.Margin = new Thickness(0, 0, 0, 0);
        }

        // Toggle Left Menu with Animation
        private void ToggleLeftMenu()
        {
            if (LeftMenu.Visibility == Visibility.Collapsed)
            {
                LeftMenu.Visibility = Visibility.Visible;
                var slideInAnimation = new ThicknessAnimation
                {
                    From = new Thickness(-250, 0, 0, 0),
                    To = new Thickness(0, 0, 0, 0),
                    Duration = new Duration(TimeSpan.FromSeconds(0.5))
                };
                LeftMenu.BeginAnimation(Border.MarginProperty, slideInAnimation);
            }
            else
            {
                var slideOutAnimation = new ThicknessAnimation
                {
                    From = LeftMenu.Margin,
                    To = new Thickness(-250, 0, 0, 0),
                    Duration = new Duration(TimeSpan.FromSeconds(0.5))
                };
                slideOutAnimation.Completed += (s, e) => LeftMenu.Visibility = Visibility.Collapsed;
                LeftMenu.BeginAnimation(Border.MarginProperty, slideOutAnimation);
            }
        }
    }
}
