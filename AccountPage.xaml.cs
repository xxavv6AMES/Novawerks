using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Supabase;
using Supabase.Gotrue;

namespace NovawerksApp
{
    public partial class AccountPage : Window
    {
        private readonly Supabase.Client _supabaseClient;

        public AccountPage()
        {
            InitializeComponent();
            // Initialize SupabaseClient with appropriate URL and key
            _supabaseClient = new Supabase.Client("https://dzgmlvzoontthmevxxpu.supabase.co", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImR6Z21sdnpvb250dGhtZXZ4eHB1Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3MjYxMDY3MzksImV4cCI6MjA0MTY4MjczOX0.oajSiFAZjly-h8sbEDzOiNkPgmb2XVlpDS9fMUMQXZs");
            LoadUserDetails();
        }

        private async void LoadUserDetails()
        {
            try
            {
                var user = await _supabaseClient.Auth.GetUserAsync();
                if (user != null)
                {
                    EmailTextBox.Text = user.Email;
                }
                else
                {
                    MessageBox.Show("User is not logged in.");
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user details: {ex.Message}");
            }
        }

        private async void UpdateEmailButton_Click(object sender, RoutedEventArgs e)
        {
            var newEmail = EmailTextBox.Text;
            if (string.IsNullOrWhiteSpace(newEmail))
            {
                MessageBox.Show("Email cannot be empty.");
                return;
            }

            try
            {
                var response = await _supabaseClient.Auth.UpdateUserAsync(newEmail: newEmail);

                if (response.Error != null)
                {
                    MessageBox.Show($"Email update failed: {response.Error.Message}");
                }
                else
                {
                    MessageBox.Show("Email updated successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating email: {ex.Message}");
            }
        }

        private async void ChangePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            var newPassword = NewPasswordBox.Password;
            if (string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("Password cannot be empty.");
                return;
            }

            try
            {
                var response = await _supabaseClient.Auth.UpdateUserAsync(newPassword: newPassword);

                if (response.Error != null)
                {
                    MessageBox.Show($"Password change failed: {response.Error.Message}");
                }
                else
                {
                    MessageBox.Show("Password changed successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error changing password: {ex.Message}");
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            _supabaseClient.Auth.SignOut();
            MessageBox.Show("Logged out successfully!");
            // Optionally navigate back to the login page or close the application
            Close();
        }
    }

    public class EmptyToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.IsNullOrEmpty(value as string) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
