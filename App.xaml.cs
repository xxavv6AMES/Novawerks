using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace NovawerksApp
{
    public partial class App : Application
    {
        private LoadingWindow _loadingWindow;

        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            _loadingWindow = new LoadingWindow();
            _loadingWindow.Show();

            try
            {
                if (!await CheckInternetConnectivity())
                {
                    MessageBox.Show("No internet connection detected. The application requires an internet connection to function properly.");
                    Shutdown(); // Exit the application
                    return;
                }

                MainWindow mainWindow = new MainWindow();
                mainWindow.Loaded += MainWindow_Loaded; // Close the loading window when the main window is fully loaded
                mainWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during startup: {ex.Message}");
                Shutdown(); // Exit the application on error
            }
        }

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

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Close the loading window when the main window is fully loaded
            if (_loadingWindow != null)
            {
                _loadingWindow.Close();
            }
        }
    }
}
