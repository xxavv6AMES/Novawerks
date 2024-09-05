using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Documents;

namespace NovawerksApp
{
    public partial class MainWindow : Window
    {
        // Define a custom RoutedUICommand for Help
        public static readonly RoutedUICommand HelpCommand = new RoutedUICommand(
            "Help Command",
            "HelpCommand",
            typeof(MainWindow)
        );

        public MainWindow()
        {
            InitializeComponent();
            RegisterCommandBindings();
        }

        private void RegisterCommandBindings()
        {
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Open, OpenCommand_Executed));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Save, SaveCommand_Executed));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Close, ExitCommand_Executed));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Undo, UndoCommand_Executed));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Redo, RedoCommand_Executed));
            CommandBindings.Add(new CommandBinding(NavigationCommands.Refresh, RefreshCommand_Executed));
            CommandBindings.Add(new CommandBinding(HelpCommand, HelpCommand_Executed));
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
            HelpMenuItem_Click(sender, e);
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

        // Navigation to NWAS Addon Store Page
        private void AddonStoreMenuItem_Click(object sender, RoutedEventArgs e)
        {
            NWAS addonStorePage = new NWAS();
            MainFrame.Navigate(addonStorePage);  // Use MainFrame for navigation
        }

        private void HelpMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Toggle visibility of the Help Sidebar
            HelpSidebar.Visibility = HelpSidebar.Visibility == Visibility.Collapsed
                ? Visibility.Visible
                : Visibility.Collapsed;
        }
    }
}


