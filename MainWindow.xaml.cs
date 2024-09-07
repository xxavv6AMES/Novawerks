using System.Windows;
namespace NovawerksApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Navigate to MainPage.xaml
            MainFrame.Navigate(new MainPage());
        }
    }
}
