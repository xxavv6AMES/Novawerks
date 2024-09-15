using Auth0.OidcClient;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Microsoft.IdentityModel.Logging;
using System.Windows.Navigation;
using System.Windows.Documents;

namespace NovawerksApp
{
    public partial class MainWindow : Window
    {
        private Auth0Client auth0Client; // Auth0 client instance
        private bool isLoggedIn = false; // User login status

        // OpenID configuration details
        private const string Issuer = "https://dev-oex5fnsu3gh2tvi2.us.auth0.com/";
        private const string AuthorizationEndpoint = "https://dev-oex5fnsu3gh2tvi2.us.auth0.com/authorize";
        private const string TokenEndpoint = "https://dev-oex5fnsu3gh2tvi2.us.auth0.com/oauth/token";
        private const string UserinfoEndpoint = "https://dev-oex5fnsu3gh2tvi2.us.auth0.com/userinfo";

        public MainWindow()
        {
            InitializeComponent();
            InitializeAuth0(); // Initialize Auth0 client
            RegisterCommandBindings();
            UpdateLoginUI();

            // Navigate to MainPage.xaml
            MainFrame.Navigate(new MainPage());
        }

        // Minimize the window
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        // Maximize or restore the window
        private void MaximizeRestoreButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        // Close the window
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Handle mouse drag to move the window
        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void InitializeAuth0()
        {
            // Set TLS 1.2 security protocol
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            try
            {
                auth0Client = new Auth0Client(new Auth0ClientOptions
                {
                    Domain = "dev-oex5fnsu3gh2tvi2.us.auth0.com",  // Double check the Auth0 domain
                    ClientId = "jgZVUpNEuYyGGUeDuxEKRqfBHwsYtkOD",
                    Scope = "openid profile email",
                    RedirectUri = "http://localhost:5000/",  // Ensure this matches Auth0 settings
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Auth0 initialization failed: {ex.Message}");
            }
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (auth0Client == null)
                {
                    throw new InvalidOperationException("Auth0 client is not initialized.");
                }

                var loginResult = await auth0Client.LoginAsync();

                if (loginResult.IsError)
                {
                    MessageBox.Show($"Login failed: {loginResult.Error}");
                }
                else
                {
                    isLoggedIn = true;
                    var user = loginResult.User;

                    if (user != null)
                    {
                        // Display user info
                        var email = user.FindFirst(c => c.Type == "email")?.Value;
                        MessageBox.Show($"Welcome {user.Identity.Name}\nEmail: {email}");

                        // Update UI or other elements with user information
                        UserEmailTextBlock.Text = email;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Oops! Something went wrong. {ex.Message}");
            }
            UpdateLoginUI();
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

        private async void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (auth0Client == null)
                {
                    throw new InvalidOperationException("Auth0 client is not initialized.");
                }

                await auth0Client.LogoutAsync();
                isLoggedIn = false;
                MessageBox.Show("You're logged out.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Oops! Something went wrong. {ex.Message}");
            }
            UpdateLoginUI();
        }

        private void UpdateLoginUI()
        {
            if (LoginButton != null && LogoutButton != null)
            {
                LoginButton.Visibility = isLoggedIn ? Visibility.Collapsed : Visibility.Visible;
                LogoutButton.Visibility = isLoggedIn ? Visibility.Visible : Visibility.Collapsed;
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
        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e) => ExitMenuItem_Click(sender, e);
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
        private void HelpMenuItem_Click(object sender, RoutedEventArgs e) => MessageBox.Show("Help clicked!");
        #endregion

        private void MainPageButton_Click(object sender, RoutedEventArgs e) => NavigateToPage(new MainPage());
        private void ForumPageButton_Click(object sender, RoutedEventArgs e) => NavigateToPage(new ForumPage()); // Make sure ForumPage.xaml exists
        private void NWASPageButton_Click(object sender, RoutedEventArgs e) => NavigateToPage(new NWAS()); // Make sure NWASPage.xaml exists
        private void SettingsButton_Click(object sender, RoutedEventArgs e) => NavigateToPage(new SettingsPage()); // Make sure SettingsPage.xaml exists

        private void NavigateToPage(MainPage page)
        {
            MainFrame.Navigate(page);
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
    }
}
