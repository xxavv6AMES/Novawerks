using System.Windows;
using Supabase;
using System.Globalization;
using System.Windows.Data;

namespace NovawerksApp
{
    public partial class SignUpPage : Window
    {
        public SignUpPage()
        {
            InitializeComponent();
        }


    public class BooleanToOpacityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isFocused = (bool)value;
            return isFocused ? 0 : 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

        private async void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;
            
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Email and password cannot be empty.");
                return;
            }

            try
            {
                var response = await SupabaseClient.Auth.SignUpAsync(email, password);
                
                if (response.Error != null)
                {
                    MessageBox.Show($"Sign up failed: {response.Error.Message}");
                }
                else
                {
                    MessageBox.Show("Sign up successful!");
                    // Optionally, navigate to a different page or clear fields
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
