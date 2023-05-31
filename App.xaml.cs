using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;

namespace Navigation.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var container = new UnityContainer();
            container.RegisterSingleton<MainWindow>();
            container.RegisterSingleton<MainViewModel>();
            container.RegisterSingleton<FirstViewModel>();
            container.RegisterSingleton<FirstView>();
            container.RegisterSingleton<FirstViewModel>();
            container.RegisterSingleton<SecondView>();
            container.RegisterSingleton<SecondViewModel>();
            container.RegisterSingleton<ThirdView>();
            container.RegisterSingleton<ThirdViewModel>();

            RegisterRoutes(container);

            var view = container.Resolve<MainWindow>();
            view.DataContext = container.Resolve<MainViewModel>();
            view.Show();
        }

        private void RegisterRoutes(UnityContainer container)
        {
            container.RegisterSingleton<INavigationService, NavigationService>();

            var navigator = container.Resolve<INavigationService>();
            navigator.RegisterRoute(nameof(FirstView), container.Resolve<FirstViewModel>());
            navigator.RegisterRoute(nameof(SecondView), container.Resolve<SecondViewModel>());
            navigator.RegisterRoute(nameof(ThirdView), container.Resolve<ThirdViewModel>());
        }
    }
}
