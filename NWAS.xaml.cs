using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace NovawerksApp
{
    public partial class NWAS : Page
    {
        public NWAS()
        {
            InitializeComponent();
            SetupHoverArea();
        }

        // Back Button Click Event Handler
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back to the previous page
            NavigationService.GoBack();
        }

        // Handle the Sidebar Button Clicks
        private void MainPageButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the Main Page
            NavigationService.Navigate(new MainPage());
        }

        private void ForumPageButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the Forum Page
            NavigationService.Navigate(new ForumPage());
        }

        private void NWASPageButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the NWAS Page (current page)
            // No action needed if on the current page
        }

        // Setup hover area for detecting mouse movement
        private void SetupHoverArea()
        {
            // Add MouseEnter event to the hover area
            HoverArea.MouseEnter += (s, e) => ToggleLeftMenu();
            
            // Ensure the HoverArea is positioned correctly
            HoverArea.Width = 10;
            HoverArea.HorizontalAlignment = HorizontalAlignment.Left;
            HoverArea.VerticalAlignment = VerticalAlignment.Stretch;
            HoverArea.Margin = new Thickness(0, 0, 0, 0);
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
    }
}
