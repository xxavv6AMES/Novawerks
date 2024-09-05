using System.Windows;
using System.Windows.Controls;

namespace NovawerksApp
{
    public partial class NWAS : Page
    {
        public NWAS()
        {
            InitializeComponent();
        }

        // Back Button Click Event Handler
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the current window
            var currentWindow = Application.Current.MainWindow;
            if (currentWindow != null)
            {
                currentWindow.Close();
            }

            // Create and show a new instance of MainWindow
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }

        // Implement search functionality or other logic
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Implement search functionality based on the input
        }
    }
}
