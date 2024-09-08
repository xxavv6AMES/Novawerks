using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

namespace NovawerksApp
{
    public partial class MainPage : Page
    {
        private const double HoverAreaWidth = 10; // Width of the hover area
        private const string ActiveTextColor = "#8C52FF"; // Color for active page
        private const string InactiveTextColor = "#CCCCCC"; // Color for inactive pages

        public MainPage()
        {
            InitializeComponent();
            RegisterCommandBindings();
            SetupHoverArea();
            HighlightCurrentPage();
        }

        private void RegisterCommandBindings()
        {
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Open, OpenCommand_Executed));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Save, SaveCommand_Executed));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Close, ExitCommand_Executed));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Undo, UndoCommand_Executed));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Redo, RedoCommand_Executed));
            CommandBindings.Add(new CommandBinding(NavigationCommands.Refresh, RefreshCommand_Executed));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Help, HelpCommand_Executed));
        }

        // Command Handlers
        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenMenuItem_Click(sender, e);
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveMenuItem_Click(sender, e);
        }

        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ExitMenuItem_Click(sender, e);
        }

        private void UndoCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UndoMenuItem_Click(sender, e);
        }

        private void RedoCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            RedoMenuItem_Click(sender, e);
        }

        private void RefreshCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            RefreshMenuItem_Click(sender, e);
        }

        private void HelpCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // Toggle visibility of the Help Sidebar
            ToggleHelpSidebar();
        }

        // Menu Item Event Handlers
        private void OpenMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Open clicked!");
        }

        private void SaveMenuItem_Click(object sender, RoutedEventArgs e)
        {
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

        private void RefreshMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Refresh clicked!");
        }

        private void HelpMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Toggle visibility of the Help Sidebar
            ToggleHelpSidebar();
        }

        // Navigation to NWAS Addon Store Page
        private void AddonStoreMenuItem_Click(object sender, RoutedEventArgs e)
        {
            NWAS addonStorePage = new NWAS();
            NavigationService.Navigate(addonStorePage);
            HighlightCurrentPage("NWASPageMenuItem");
        }

        private void ForumMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ForumPage forumPage = new ForumPage();
            NavigationService.Navigate(forumPage);
            HighlightCurrentPage("ForumPageMenuItem");
        }

        // Sidebar Button Click Event Handlers
        private void MainPageButton_Click(object sender, RoutedEventArgs e)
        {
            // No navigation needed, as this is already the main page
            HighlightCurrentPage("MainPageMenuItem");
        }

        private void ForumPageButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ForumPage());
            HighlightCurrentPage("ForumPageMenuItem");
        }

        private void NWASPageButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NWAS());
            HighlightCurrentPage("NWASPageMenuItem");
        }
        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SettingsPage());
            HighlightCurrentPage("SettingsPageMenuItem");
        }

        // Highlight the current page in the menu
        private void HighlightCurrentPage(string activePageName = "MainPageMenuItem")
        {
            // Reset all menu items to inactive color
            MainPageMenuItem.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(InactiveTextColor));
            ForumPageMenuItem.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(InactiveTextColor));
            NWASPageMenuItem.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(InactiveTextColor));

            // Highlight the current page
            var activeTextBlock = FindName(activePageName) as TextBlock;
            if (activeTextBlock != null)
            {
                activeTextBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(ActiveTextColor));
            }
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

        // Toggle Help Sidebar and adjust MainFrame margin
        private void ToggleHelpSidebar()
        {
            if (HelpSidebar.Visibility == Visibility.Collapsed)
            {
                HelpSidebar.Visibility = Visibility.Visible;
                var slideInAnimation = new ThicknessAnimation
                {
                    From = new Thickness(MainFrame.Margin.Right, 0, -300, 0),
                    To = new Thickness(MainFrame.Margin.Right + 300, 0, 0, 0),
                    Duration = new Duration(TimeSpan.FromSeconds(0.5))
                };
                MainFrame.BeginAnimation(MarginProperty, slideInAnimation);
            }
            else
            {
                var slideOutAnimation = new ThicknessAnimation
                {
                    From = MainFrame.Margin,
                    To = new Thickness(MainFrame.Margin.Right - 300, 0, 0, 0),
                    Duration = new Duration(TimeSpan.FromSeconds(0.5))
                };
                slideOutAnimation.Completed += (s, e) => HelpSidebar.Visibility = Visibility.Collapsed;
                MainFrame.BeginAnimation(MarginProperty, slideOutAnimation);
            }
        }

        // Close Help Sidebar Button Click Event Handler
        private void CloseHelpSidebar_Click(object sender, RoutedEventArgs e)
        {
            ToggleHelpSidebar();
        }

        // Setup hover area for detecting mouse movement
        private void SetupHoverArea()
        {
            // Add MouseEnter event to the hover area
            HoverArea.MouseEnter += (s, e) => ToggleLeftMenu();
            
            // Ensure the HoverArea is positioned correctly
            HoverArea.Width = HoverAreaWidth;
            HoverArea.HorizontalAlignment = HorizontalAlignment.Left;
            HoverArea.VerticalAlignment = VerticalAlignment.Stretch;
            HoverArea.Margin = new Thickness(0, 0, 0, 0);
        }

        // Handle hyperlink navigation
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            // Open the link in the default web browser
            Process.Start(new ProcessStartInfo
            {
                FileName = e.Uri.ToString(),
                UseShellExecute = true
            });

            // Mark the event as handled
            e.Handled = true;
        }
    }
}
