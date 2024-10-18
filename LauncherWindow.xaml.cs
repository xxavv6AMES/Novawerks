using System.Windows;

namespace NovawerksApp
{
    public partial class LauncherWindow : Window
    {
        public LauncherWindow()
        {
            InitializeComponent();
        }

        // Event handler for launching the selected addon
        private void LaunchButton_Click(object sender, RoutedEventArgs e)
        {
            if (AddonListBox.SelectedItem != null)
            {
                string selectedAddon = AddonListBox.SelectedItem.ToString();
                MessageBox.Show($"Launching {selectedAddon}", "Addon Launcher", MessageBoxButton.OK, MessageBoxImage.Information);

                // Insert logic here to launch the selected addon

                // For demonstration, we'll just close the launcher window after launching
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select an addon to launch.", "No Addon Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
