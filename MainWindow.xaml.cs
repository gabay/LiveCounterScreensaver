using System;
using System.Windows;
using System.Windows.Threading;

namespace LiveCounterScreensaver
{
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer timer;
        private readonly DateTime startDate = new DateTime(2023, 10, 7, 0, 0, 0, DateTimeKind.Utc);
        private DateTime initTime = DateTime.UtcNow;

        public MainWindow()
        {
            InitializeComponent();

            MouseMove += (s, e) => handleEvent();
            MouseDown += (s, e) => handleEvent();
            KeyDown += (s, e) => handleEvent();
            
            UpdateCountdown();
            timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            timer.Tick += (s, e) => UpdateCountdown();
            timer.Start();
        }

        private void handleEvent()
        {
            var elapsed = DateTime.UtcNow - initTime;

            if (elapsed.TotalSeconds > 0.1) {
                Close();
            }
        }

        private void UpdateCountdown()
        {
            var elapsed = DateTime.UtcNow - startDate;

            DaysText.Text = ((int)elapsed.TotalDays).ToString("D3");
            HoursText.Text = elapsed.Hours.ToString("D2");
            MinutesText.Text = elapsed.Minutes.ToString("D2");
            SecondsText.Text = elapsed.Seconds.ToString("D2");
        }
    }
}