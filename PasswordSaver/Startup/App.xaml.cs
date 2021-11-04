using Autofac;
using PasswordSaver.Startup;
using PasswordSaver.View;
using System.Windows;

namespace PasswordSaver
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IContainer container = Bootstrapper.Initialize();
            var mainWindow = container.Resolve<MainWindow>();

            mainWindow.Show();
        }
    }
}
