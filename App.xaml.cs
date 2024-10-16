using System;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using Auth0.OidcClient;

namespace NovawerksApp
{
    public partial class App : Application
    {
        private LoadingWindow _loadingWindow;
        private Auth0Client _auth0Client; // Declare the Auth0 client

        // Entry point for application startup
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                // Set the security protocol to TLS 1.2
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                Console.WriteLine("TLS 1.2 is set.");

                // Initialize Auth0 client
                InitializeAuth0Client();

                // Initialize the loading window and show it
                _loadingWindow = new LoadingWindow();
                _loadingWindow.Show();

                // Check internet connectivity and proceed
                Task.Run(async () =>
                {
                    try
                    {
                        if (!await CheckInternetConnectivity())
                        {
                            Application.Current.Dispatcher.Invoke(() =>
                            {
                                MessageBox.Show("No internet connection detected. The application requires an internet connection to function properly.");
                                Shutdown(); // Exit the application
                            });
                        }
                        else
                        {
                            Application.Current.Dispatcher.Invoke(() =>
                            {
                                MainWindow mainWindow = new MainWindow();
                                mainWindow.Loaded += MainWindow_Loaded;
                                mainWindow.Show();
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            MessageBox.Show($"Error during startup: {ex.Message}");
                            Shutdown(); // Exit the application on error
                        });
                    }
                });
            }
            catch (Exception ex)
            {
                // Handle exceptions in startup logic
                MessageBox.Show($"Unhandled error during application startup: {ex.Message}");
                Shutdown(); // Exit the application on startup failure
            }
        }

        // Method to initialize Auth0 Client
        private void InitializeAuth0Client()
        {
            _auth0Client = new Auth0Client(new Auth0ClientOptions
            {
                Domain = "auth.novawerks.xxavvgroup.com",
                ClientId = "aUjxl8FbT9j68N9YTpfLsOwOFV6Vsv1m",
                Scope = "openid profile email",
                RedirectUri = "NDE://callback"
            });
        }

        // Method to check internet connectivity
        private async Task<bool> CheckInternetConnectivity()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(5); // Short timeout
                    HttpResponseMessage response = await client.GetAsync("https://www.google.com");
                    return response.IsSuccessStatusCode;
                }
            }
            catch
            {
                return false;
            }
        }

        // Event handler for when the main window is loaded
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Close the loading window when the main window is fully loaded
            _loadingWindow?.Close();
            _loadingWindow = null; // Clean up
        }

        // Property to access the Auth0 client
        public Auth0Client Auth0Client => _auth0Client;
    }
}
