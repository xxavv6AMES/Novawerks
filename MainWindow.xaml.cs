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
using System.Windows.Interop; // Added this using directive

namespace NovawerksApp
{
    public partial class MainWindow : Window
    {
        private bool isMaximized = false;

        public MainWindow()
        {
            InitializeComponent(); // Ensure components are fully initialized
            this.Loaded += MainWindow_Loaded; // Attach the Loaded event
            this.SourceInitialized += Window_SourceInitialized;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Navigate to MainPage after the window is fully loaded
            MainFrame.Navigate(new MainPage());
        }

        private void Window_SourceInitialized(object sender, EventArgs e)
        {
            IntPtr handle = new WindowInteropHelper(this).Handle;
            HwndSource.FromHwnd(handle)?.AddHook(WndProc);
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var auth0Client = ((App)Application.Current).Auth0Client;
                var loginResult = await auth0Client.LoginAsync();

                if (loginResult.IsError)
                {
                    MessageBox.Show($"Error: {loginResult.Error}");
                    return;
                }

                var userInfo = loginResult.User;
                MessageBox.Show($"Welcome, {userInfo.FindFirst(c => c.Type == "name")?.Value}!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == 0x0084) // WM_NCHITTEST
            {
                // Get the point coordinates for the hit test
                Point point = PointFromScreen(new Point(
                    (double)((int)(short)((uint)lParam & 0xFFFF)),
                    (double)((int)(short)((uint)lParam >> 16))
                ));

                // Define resize areas (8px border)
                var resizeBorderWidth = 8;
                
                if (point.Y <= resizeBorderWidth)
                {
                    if (point.X <= resizeBorderWidth) { handled = true; return new IntPtr(13); } // TOPLEFT
                    if (point.X >= ActualWidth - resizeBorderWidth) { handled = true; return new IntPtr(14); } // TOPRIGHT
                    handled = true; return new IntPtr(12); // TOP
                }
                if (point.Y >= ActualHeight - resizeBorderWidth)
                {
                    if (point.X <= resizeBorderWidth) { handled = true; return new IntPtr(16); } // BOTTOMLEFT
                    if (point.X >= ActualWidth - resizeBorderWidth) { handled = true; return new IntPtr(17); } // BOTTOMRIGHT
                    handled = true; return new IntPtr(15); // BOTTOM
                }
                if (point.X <= resizeBorderWidth) { handled = true; return new IntPtr(10); } // LEFT
                if (point.X >= ActualWidth - resizeBorderWidth) { handled = true; return new IntPtr(11); } // RIGHT
            }

            return IntPtr.Zero;
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

        private void TitleBar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MaximizeRestoreButton_Click(sender, e);
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