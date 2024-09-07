using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace NovawerksApp
{
    public partial class ForumPage : Page
    {
        private const double HoverAreaWidth = 15; // Width of the hover area

        public ForumPage()
        {
            InitializeComponent();
            SetupHoverArea();
        }

        // Sidebar Button Click Event Handlers
        private void MainPageButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }

        private void ForumPageButton_Click(object sender, RoutedEventArgs e)
        {
            // No action needed as this is already the forum page
        }

        private void NWASPageButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NWAS());
        }

        // Back Button Click Event Handler
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }

        // Toggle Left Menu with Animation
        private void ToggleLeftMenu()
        {
            if (LeftMenu.Visibility == Visibility.Collapsed)
            {
                LeftMenu.Visibility = Visibility.Visible;
                var slideInAnimation = new ThicknessAnimation
                {
                    From = new Thickness(-250, 0, 0, 0),
                    To = new Thickness(0, 0, 0, 0),
                    Duration = new Duration(TimeSpan.FromSeconds(0.5))
                };
                LeftMenu.BeginAnimation(Border.MarginProperty, slideInAnimation);
            }
            else
            {
                var slideOutAnimation = new ThicknessAnimation
                {
                    From = LeftMenu.Margin,
                    To = new Thickness(-250, 0, 0, 0),
                    Duration = new Duration(TimeSpan.FromSeconds(0.5))
                };
                slideOutAnimation.Completed += (s, e) => LeftMenu.Visibility = Visibility.Collapsed;
                LeftMenu.BeginAnimation(Border.MarginProperty, slideOutAnimation);
            }
        }

        // Setup hover area for detecting mouse movement
        private void SetupHoverArea()
        {
            HoverArea.MouseEnter += (s, e) => ToggleLeftMenu();

            // Ensure the HoverArea is positioned correctly
            HoverArea.Width = HoverAreaWidth;
            HoverArea.HorizontalAlignment = HorizontalAlignment.Left;
            HoverArea.VerticalAlignment = VerticalAlignment.Stretch;
            HoverArea.Margin = new Thickness(0, 0, 0, 0);
        }
    }
}
