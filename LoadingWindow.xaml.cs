using System;
using System.Windows;
using System.Windows.Threading;

namespace NovawerksApp
{
    public partial class LoadingWindow : Window
    {
        private DispatcherTimer _autoCloseTimer;

        public LoadingWindow()
        {
            InitializeComponent();
            StartAutoCloseTimer();
        }

        private void StartAutoCloseTimer()
        {
            _autoCloseTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(7) // Set the timer to 3 seconds
            };
            _autoCloseTimer.Tick += AutoCloseTimer_Tick;
            _autoCloseTimer.Start();
        }

        private void AutoCloseTimer_Tick(object sender, EventArgs e)
        {
            _autoCloseTimer.Stop();
            Close();
        }
    }
}
