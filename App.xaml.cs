using System.Windows;

namespace LiveCounterScreensaver
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            string arg = e.Args.Length > 0 ? e.Args[0].ToLower() : "/s";
            if (arg.StartsWith("/s")) // screensaver mode
            {
                MainWindow window = new MainWindow();
                window.Show();
            }
            else if (arg.StartsWith("/p")) // preview mode
            {
                MainWindow window = new MainWindow();
                window.Show();
            }
            else if (arg.StartsWith("/c")) // config mode (not implemented)
            {
                MessageBox.Show("No settings available.");
                Shutdown();
            }
            else    // Undefined argument
            {
                MessageBox.Show("Invalid argument: '" + arg + "'.");
                Shutdown();
            }
        }
    }
}