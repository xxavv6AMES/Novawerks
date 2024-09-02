using System.Windows;

namespace NovawerksApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Menu Item Event Handlers
        private void NewMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("New clicked!");
        }

        private void OpenMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Add code to handle opening a file
            MessageBox.Show("Open clicked!");
        }

        private void SaveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Add code to handle saving a file
            MessageBox.Show("Save clicked!");
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void UndoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Undo clicked!");
        }

        private void RedoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Redo clicked!");
        }

        private void CutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cut clicked!");
        }

        private void CopyMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Copy clicked!");
        }

        private void PasteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Paste clicked!");
        }

        private void ZoomInMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Zoom In clicked!");
        }

        private void ZoomOutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Zoom Out clicked!");
        }

        private void AboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("About clicked!");
        }

        private void HelpContentsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Help Contents clicked!");
        }
    }
}
