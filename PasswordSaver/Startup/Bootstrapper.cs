using Autofac;
using PasswordSaver.Services.CredentialsManager;
using PasswordSaver.View;
using PasswordSaver.ViewModel;
using Prism.Events;

namespace PasswordSaver.Startup
{
    public class Bootstrapper
    {
        public static IContainer Initialize()
        {
            var containerBuilder = new ContainerBuilder();

            //User controls
            containerBuilder.RegisterType<NavigationViewModel>().AsSelf();
            containerBuilder.RegisterType<AddCredentialsViewModel>().AsSelf();
            containerBuilder.RegisterType<ListCredentialsViewModel>().AsSelf();

            //Windows
            containerBuilder.RegisterType<MainWindowViewModel>().AsSelf();
            containerBuilder.RegisterType<MainWindow>().AsSelf();

            //Services
            containerBuilder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();
            containerBuilder.RegisterType<JsonCredentialsManager>().As<ICredentialsManager<RawCredentials>>().SingleInstance();

            return containerBuilder.Build();
        }
    }
}
