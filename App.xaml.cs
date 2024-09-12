using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using Supabase;

namespace NovawerksApp
{
    public partial class App : Application
    {
        private LoadingWindow _loadingWindow;

        // Supabase client instance
        public static Supabase.Client SupabaseClient { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Initialize Supabase client
            SupabaseClient = new Supabase.Client(
                "https://dzgmlvzoontthmevxxpu.supabase.co",
                "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImR6Z21sdnpvb250dGhtZXZ4eHB1Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3MjYxMDY3MzksImV4cCI6MjA0MTY4MjczOX0.oajSiFAZjly-h8sbEDzOiNkPgmb2XVlpDS9fMUMQXZs"
            );

            // Show loading window
            _loadingWindow = new LoadingWindow();
            _loadingWindow.Show();

            // Check internet connectivity and load main window
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
                        return;
                    }

                    // Run the code on the UI thread to update UI components
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Loaded += MainWindow_Loaded; // Close the loading window when the main window is fully loaded
                        mainWindow.Show();
                    });
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
