using Auth0.OidcClient;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Microsoft.IdentityModel.Logging;
using System.Windows.Navigation;
using System.Windows.Documents;
using System.Windows.Controls;

namespace NovawerksApp
{
    public partial class MainWindow : Window
    {

public MainWindow()
{
    InitializeComponent(); // Ensure components are fully initialized
    this.Loaded += MainWindow_Loaded; // Attach the Loaded event
}

private void MainWindow_Loaded(object sender, RoutedEventArgs e)
{
    // Navigate to MainPage after the window is fully loaded
    MainFrame.Navigate(new MainPage());
}

        // Minimize the window
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        // Maximize or restore the window
        private void MaximizeRestoreButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        // Close the window
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Handle mouse drag to move the window
        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

            }
        }
