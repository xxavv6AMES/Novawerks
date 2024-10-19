using System.Windows;

namespace NovawerksApp
{
    public partial class UpdateProgressWindow : Window
    {
        public UpdateProgressWindow()
        {
            InitializeComponent();
            ProgressBar.IsIndeterminate = true; // Set to indeterminate initially
        }

        // Method to update progress text and details
        public void UpdateProgress(string statusMessage, double progressPercentage = -1)
        {
            UpdateStatusText.Text = statusMessage;

            if (progressPercentage >= 0)
            {
                ProgressBar.IsIndeterminate = false; // If we have a valid percentage, we stop indeterminate mode
                ProgressBar.Value = progressPercentage;
                ProgressDetailText.Text = $"{progressPercentage}% completed";
            }
            else
            {
                ProgressBar.IsIndeterminate = true; // Keep the progress bar in indeterminate mode
                ProgressDetailText.Text = "Please wait...";
            }
        }
    }
}
