using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Collections.Generic;

namespace NovawerksApp
{
    public partial class MainPage : Page
    {
        private const double HoverAreaWidth = 10; // Width of the hover area
        private const string ActiveTextColor = "#FFA500"; // Color for active page
        private const string InactiveTextColor = "#CCCCCC"; // Color for inactive pages

        public MainPage()
        {
            InitializeComponent();
            RegisterCommandBindings();
            HighlightCurrentPage();
        }

        private async Task<string> FetchConfigurationAsync(string configUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(10); // Increase timeout if necessary
                try
                {
                    var response = await client.GetStringAsync(configUrl);
                    return response;
                }
                catch (HttpRequestException ex)
                {
                    Debug.WriteLine($"Request failed: {ex.Message}");
                    return null;
                }
            }
        }
// Login logic
        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Access the Auth0 instance from App.xaml.cs
                var auth0Client = ((App)Application.Current).Auth0Client;

                // Perform authentication
                var loginResult = await auth0Client.LoginAsync();

                if (loginResult.IsError)
                {
                    MessageBox.Show($"Error: {loginResult.Error}");
                    return;
                }

                // Success: Display user info
                var userInfo = loginResult.User;
                MessageBox.Show($"Welcome, {userInfo.FindFirst(c => c.Type == "name")?.Value}!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        // Logout logic
        private async void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Access the Auth0 instance from App.xaml.cs
                var auth0Client = ((App)Application.Current).Auth0Client;

                // Perform logout
                await auth0Client.LogoutAsync();
                MessageBox.Show("Logged out successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private void RegisterCommandBindings()
        {
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Open, OpenCommand_Executed));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Save, SaveCommand_Executed));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Close, ExitCommand_Executed));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Undo, UndoCommand_Executed));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Redo, RedoCommand_Executed));
            CommandBindings.Add(new CommandBinding(NavigationCommands.Refresh, RefreshCommand_Executed));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Help, HelpCommand_Executed));
        }

        #region Command Handlers
        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e) => OpenMenuItem_Click(sender, e);
        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e) => SaveMenuItem_Click(sender, e);
        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e) => Application.Current.Shutdown();
        private void UndoCommand_Executed(object sender, ExecutedRoutedEventArgs e) => UndoMenuItem_Click(sender, e);
        private void RedoCommand_Executed(object sender, ExecutedRoutedEventArgs e) => RedoMenuItem_Click(sender, e);
        private void RefreshCommand_Executed(object sender, ExecutedRoutedEventArgs e) => RefreshMenuItem_Click(sender, e);
        private void HelpCommand_Executed(object sender, ExecutedRoutedEventArgs e) => ToggleHelpSidebar();
        #endregion

        #region Menu Event Handlers
        private void OpenMenuItem_Click(object sender, RoutedEventArgs e) => MessageBox.Show("Open clicked!");
        private void SaveMenuItem_Click(object sender, RoutedEventArgs e) => MessageBox.Show("Save clicked!");
        private void ExitMenuItem_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();
        private void UndoMenuItem_Click(object sender, RoutedEventArgs e) => MessageBox.Show("Undo clicked!");
        private void RedoMenuItem_Click(object sender, RoutedEventArgs e) => MessageBox.Show("Redo clicked!");
        private void RefreshMenuItem_Click(object sender, RoutedEventArgs e) => MessageBox.Show("Refresh clicked!");
        private void HelpMenuItem_Click(object sender, RoutedEventArgs e)
{
    // Define the URL you want to navigate to
    string url = "https://werks.nova.xxavvgroup.com/helpcenter";

    // Use System.Diagnostics.Process to open the URL in the default web browser
    try
    {
        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
        {
            FileName = url,
            UseShellExecute = true // Necessary for opening URLs on modern systems
        });
    }
    catch (Exception ex)
    {
        // Handle any exceptions, such as if the URL fails to open
        MessageBox.Show($"Unable to open the URL: {ex.Message}");
    }
}
        #endregion

        private void MainPageButton_Click(object sender, RoutedEventArgs e) => HighlightCurrentPage("MainPageMenuItem");
        private void ForumPageButton_Click(object sender, RoutedEventArgs e) => NavigationService?.Navigate(new ForumPage());
        private void NWASPageButton_Click(object sender, RoutedEventArgs e) => NavigationService?.Navigate(new NWAS());
        private void SettingsButton_Click(object sender, RoutedEventArgs e) => NavigationService?.Navigate(new SettingsPage());

        #region UI Helpers
        private void HighlightCurrentPage(string activePageName = "MainPageMenuItem")
        {
            // Reset all menu items to inactive color
            if (MainPageMenuItem != null) MainPageMenuItem.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(InactiveTextColor));
            if (ForumPageMenuItem != null) ForumPageMenuItem.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(InactiveTextColor));
            if (NWASPageMenuItem != null) NWASPageMenuItem.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(InactiveTextColor));

            // Highlight the current page
            if (FindName(activePageName) is TextBlock activeTextBlock)
            {
                activeTextBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(ActiveTextColor));
            }
        }

        private void ToggleHelpSidebar()
        {
            if (HelpSidebar != null && ContentFrame != null)
            {
                if (HelpSidebar.Visibility == Visibility.Collapsed)
                {
                    HelpSidebar.Visibility = Visibility.Visible;
                    ContentFrame.BeginAnimation(MarginProperty, new ThicknessAnimation
                    {
                        From = new Thickness(ContentFrame.Margin.Left, 0, -300, 0),
                        To = new Thickness(ContentFrame.Margin.Left + 300, 0, 0, 0),
                        Duration = TimeSpan.FromSeconds(0.5)
                    });
                }
                else
                {
                    var slideOutAnimation = new ThicknessAnimation
                    {
                        From = ContentFrame.Margin,
                        To = new Thickness(ContentFrame.Margin.Left - 300, 0, 0, 0),
                        Duration = TimeSpan.FromSeconds(0.5)
                    };
                    slideOutAnimation.Completed += (s, e) => HelpSidebar.Visibility = Visibility.Collapsed;
                    ContentFrame.BeginAnimation(MarginProperty, slideOutAnimation);
                }
            }
        }

        private void CloseHelpSidebar_Click(object sender, RoutedEventArgs e) => ToggleHelpSidebar();
        #endregion

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
    }
}
