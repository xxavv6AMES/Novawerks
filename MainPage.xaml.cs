using Auth0.OidcClient;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Threading.Tasks;

namespace NovawerksApp
{
    public partial class MainPage : Page
    {
        private const double HoverAreaWidth = 10; // Width of the hover area
        private const string ActiveTextColor = "#8C52FF"; // Color for active page
        private const string InactiveTextColor = "#CCCCCC"; // Color for inactive pages

        private Auth0Client auth0Client; // Auth0 client instance
        private bool isLoggedIn = false; // User login status

        public MainPage()
        {
            InitializeComponent();
            RegisterCommandBindings();
            HighlightCurrentPage();
            InitializeAuth0(); // Initialize Auth0 client
        }

private void InitializeAuth0()
{
auth0Client = new Auth0Client(new Auth0ClientOptions
{
    Domain = "dev-oex5fnsu3gh2tvi2.us.auth0.com", // Ensure this is the correct domain
    ClientId = "jgZVUpNEuYyGGUeDuxEKRqfBHwsYtkOD", // Ensure this is the correct Client ID
    Scope = "openid profile email",
    RedirectUri = "http://localhost:5000/callback" // Ensure this URI is registered in the Auth0 dashboard
    // Enable detailed logging
    Logger = new System.ConsoleLogger(),
});

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
{
    try
    {
        var loginResult = await auth0Client.LoginAsync();

        if (loginResult.IsError)
        {
            MessageBox.Show($"Login failed: {loginResult.Error}");
        }
        else
        {
            isLoggedIn = true;
            MessageBox.Show($"Welcome {loginResult.User.Identity.Name}");

            // You can store other user info like email
            var email = loginResult.User.FindFirst(c => c.Type == "email")?.Value;
            // Other user claims can be accessed similarly
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Oops! Something went wrong. {ex.Message}");
    }
}


        private async void LogoutButton_Click(object sender, RoutedEventArgs e)
{
    try
    {
        await auth0Client.LogoutAsync();
        isLoggedIn = false;
        MessageBox.Show("You're logged out.");
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Oops! Something went wrong. {ex.Message}");
    }
}

private void UpdateLoginUI()
{
    if (isLoggedIn)
    {
        LoginButton.Visibility = Visibility.Collapsed;
        LogoutButton.Visibility = Visibility.Visible;
    }
    else
    {
        LoginButton.Visibility = Visibility.Visible;
        LogoutButton.Visibility = Visibility.Collapsed;
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
        private void HelpMenuItem_Click(object sender, RoutedEventArgs e) => MessageBox.Show("HMIC clicked!");
        #endregion

        private void MainPageButton_Click(object sender, RoutedEventArgs e) => HighlightCurrentPage("MainPageMenuItem");
        private void ForumPageButton_Click(object sender, RoutedEventArgs e) => NavigationService?.Navigate(new ForumPage());
        private void NWASPageButton_Click(object sender, RoutedEventArgs e) => NavigationService?.Navigate(new NWAS());
        private void SettingsButton_Click(object sender, RoutedEventArgs e) => NavigationService?.Navigate(new SettingsPage());

        #region UI Helpers
        private void HighlightCurrentPage(string activePageName = "MainPageMenuItem")
        {
            // Reset all menu items to inactive color
            MainPageMenuItem.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(InactiveTextColor));
            ForumPageMenuItem.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(InactiveTextColor));
            NWASPageMenuItem.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(InactiveTextColor));

            // Highlight the current page
            if (FindName(activePageName) is TextBlock activeTextBlock)
            {
                activeTextBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(ActiveTextColor));
            }
        }

        private void ToggleHelpSidebar()
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

        private void CloseHelpSidebar_Click(object sender, RoutedEventArgs e) => ToggleHelpSidebar();
        #endregion

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = e.Uri.ToString(),
                UseShellExecute = true
            });
            e.Handled = true;
        }
    }
}
