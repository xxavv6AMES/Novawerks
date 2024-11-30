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
using System.Windows.Media.Imaging;

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

        // Update Novawerks ID section
        UsernameTextBlock.Text = userInfo.FindFirst(c => c.Type == "name")?.Value ?? "Username not available";
        EmailTextBlock.Text = userInfo.FindFirst(c => c.Type == "email")?.Value ?? "Email not available";

        // Set profile picture (assuming the URL is provided in the user info)
        var profilePictureUrl = userInfo.FindFirst(c => c.Type == "picture")?.Value; // Ensure this claim exists
        if (!string.IsNullOrEmpty(profilePictureUrl))
        {
            UserProfilePicture.Source = new BitmapImage(new Uri(profilePictureUrl));
        }
        else
        {
            // Set a default image if the profile picture is not available
            UserProfilePicture.Source = new BitmapImage(new Uri("Images/novawerks1.png")); // Update the path
        }
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
        }

        #region Command Handlers
        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e) => OpenMenuItem_Click(sender, e);
        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e) => SaveMenuItem_Click(sender, e);
        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e) => Application.Current.Shutdown();
        private void UndoCommand_Executed(object sender, ExecutedRoutedEventArgs e) => UndoMenuItem_Click(sender, e);
        private void RedoCommand_Executed(object sender, ExecutedRoutedEventArgs e) => RedoMenuItem_Click(sender, e);
        private void RefreshCommand_Executed(object sender, ExecutedRoutedEventArgs e) => RefreshMenuItem_Click(sender, e);
        #endregion

        #region Menu Event Handlers
        private void OpenMenuItem_Click(object sender, RoutedEventArgs e) => MessageBox.Show("Open clicked!");
        private void SaveMenuItem_Click(object sender, RoutedEventArgs e) => MessageBox.Show("Save clicked!");
        private void ExitMenuItem_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();
        private void UndoMenuItem_Click(object sender, RoutedEventArgs e) => MessageBox.Show("Undo clicked!");
        private void RedoMenuItem_Click(object sender, RoutedEventArgs e) => MessageBox.Show("Redo clicked!");
        private void RefreshMenuItem_Click(object sender, RoutedEventArgs e) => MessageBox.Show("Refresh clicked!");
        private void HelpMenuItem_Click(object sender, RoutedEventArgs e) => MessageBox.Show("Help clicked!");
        #endregion

        private void MainPageButton_Click(object sender, RoutedEventArgs e) => HighlightCurrentPage("MainPageMenuItem");
        private void ForumPageButton_Click(object sender, RoutedEventArgs e) => NavigationService?.Navigate(new ForumPage());
        private void NWASPageButton_Click(object sender, RoutedEventArgs e) => NavigationService?.Navigate(new NWAS());
        private void SettingsButton_Click(object sender, RoutedEventArgs e) => NavigationService?.Navigate(new SettingsPage());

        #region UI Helpers
        private void HighlightCurrentPage(string activePageName = "MainPageMenuItem")
        {
            }
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
