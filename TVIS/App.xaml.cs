using System.Windows;
using TVIS.MVVM.Models;
using TVIS.MVVM.ViewModels;

namespace TVIS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly TVISModel tvis;

        public App()
        {
            tvis = new();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel()
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
