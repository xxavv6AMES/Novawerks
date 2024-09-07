using System.Windows;

namespace NovawerksApp
{
    public partial class TutorialOverlay : Window
    {
        public TutorialOverlay()
        {
            InitializeComponent();
        }

        private void GotItButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the tutorial overlay
            this.Close();

            // Open the main window
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
