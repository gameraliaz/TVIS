using System.Windows;
using TVIS.MVVM.Models;
using TVIS.MVVM.ViewModels;
using TVIS.Stores;

namespace TVIS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly TVISModel tvis;
        private readonly NavigationStore _NavigationStore;
        public App()
        {
            tvis = new();
            _NavigationStore = new NavigationStore();
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
