using System.Windows;
using MatrixIO.IO;

namespace BmffViewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private PortabilityFactory _pf = new BmffPortabilityFactory();

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            BmffViewer.Properties.Settings.Default.Save();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow main = new MainWindow();
            foreach (string arg in e.Args)
            {
                main.Files.Add(new BaseMediaFile(arg));
            }
            main.ShowDialog();

            this.Shutdown();
        }

    }
}
