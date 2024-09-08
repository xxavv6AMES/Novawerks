using System.Diagnostics;
using System.Windows;

namespace NovawerksApp
{
    public partial class UpdatePromptWindow : Window
    {
        private readonly string _latestVersion;

        public UpdatePromptWindow(string latestVersion)
        {
            InitializeComponent();
            _latestVersion = latestVersion;
            VersionTextBlock.Text = $"Current Version: 0.6.0-EA\nLatest Version: {_latestVersion}";
        }

        private void UpdateNow_Click(object sender, RoutedEventArgs e)
        {
            string downloadUrl = $"https://github.com/xxavv6AMES/Novawerks/releases/download/v{_latestVersion}/NDE.Setup.exe";
            Process.Start(new ProcessStartInfo
            {
                FileName = downloadUrl,
                UseShellExecute = true
            });
            Application.Current.Shutdown();
        }

        private void Later_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
