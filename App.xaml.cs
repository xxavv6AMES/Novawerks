using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace NovawerksApp
{
    public partial class App : Application
    {
        private LoadingWindow _loadingWindow;

        // Entry point for application startup
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
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
    }
}
