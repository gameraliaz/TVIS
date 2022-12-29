using System.Windows;
using TVIS.MVVM.Models;
using TVIS.MVVM.ViewModels;
using TVIS.Services;
using TVIS.Stores;
using System.Configuration;
using System.Collections.Specialized;

namespace TVIS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly TVISModel tvis;
        private readonly NavigationStore _NavigationStore;
        private readonly Database _Database;
        public App()
        {
            _Database = new(ConfigurationManager.AppSettings.Get("Data Source"), ConfigurationManager.AppSettings.Get("User ID"), ConfigurationManager.AppSettings.Get("Password"));
            tvis = new(_Database);
            _NavigationStore = new();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _NavigationStore.CurrentViewModel = new DashboardViewModel(tvis);

            MainWindow = new MainWindow(_NavigationStore,tvis)
            {
                DataContext = new MainViewModel(_NavigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
