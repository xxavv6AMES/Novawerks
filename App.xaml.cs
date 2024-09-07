using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;

namespace NovawerksApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string TutorialShownFile = "tutorial_shown.txt";

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (!File.Exists(TutorialShownFile))
            {
                // Show tutorial overlay
                var tutorialOverlay = new TutorialOverlay();
                tutorialOverlay.ShowDialog();

                // Create file to mark tutorial as shown
                File.Create(TutorialShownFile).Dispose();
            }
        }
    }
}
