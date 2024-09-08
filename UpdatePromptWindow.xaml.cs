using System;
using System.Diagnostics;
using System.Windows;

namespace NovawerksApp
{
    public partial class UpdatePromptWindow : Window
    {
        private readonly string _latestVersion;
        private readonly Action<string> _startUpdateProcess;

        public UpdatePromptWindow(string latestVersion, Action<string> startUpdateProcess)
        {
            InitializeComponent();
            _latestVersion = latestVersion;
            _startUpdateProcess = startUpdateProcess;
            VersionTextBlock.Text = $"Current Version: 0.6.0-EA\nLatest Version: {_latestVersion}";
        }

        private void UpdateNow_Click(object sender, RoutedEventArgs e)
        {
            // Create the update URL
            string downloadUrl = $"https://github.com/xxavv6AMES/Novawerks/releases/download/v{_latestVersion}/NDE.Setup.exe";
            
            // Call the delegate to start the update process
            _startUpdateProcess(downloadUrl);
            this.Close();
        }

        private void Later_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
