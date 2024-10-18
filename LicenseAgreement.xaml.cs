using System.Windows;
using System.Windows.Controls;

namespace NovawerksApp
{
    public partial class LicenseAgreement : Page
    {
        public LicenseAgreement()
        {
            InitializeComponent();
        }

   private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
