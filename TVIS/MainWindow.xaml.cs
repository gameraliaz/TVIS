using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using TVIS.MVVM.Models;
using TVIS.MVVM.Views;
using TVIS.MVVM.ViewModels;
using TVIS.Stores;

namespace TVIS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly NavigationStore _NavigationStore;
        private readonly TVISModel tvis;
        public MainWindow(NavigationStore NavigationStore, TVISModel tvis) 
        {
            InitializeComponent();
            _NavigationStore = NavigationStore;
            this.tvis = tvis;
        }

        void Colapsingmenu(object sender, RoutedEventArgs e)
        {
            Storyboard? sb = (Resources["Colapsing"] as Storyboard);
            sb?.Begin();
        }
        void Expandingmenu(object sender, RoutedEventArgs e)
        {
            Storyboard? sb = (Resources["Expanding"] as Storyboard);
            sb?.Begin();
        }

        private void border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            { DragMove(); }
            catch { }
        }

        private void Lmenu_MouseDownDashboard(object sender, RoutedEventArgs e)
        {
            _NavigationStore.CurrentViewModel = new DashboardViewModel(tvis);
        }

        private void Lmenu_MouseDownInsertion(object sender, RoutedEventArgs e)
        {
            _NavigationStore.CurrentViewModel = new InsertionViewModel(tvis);
        }

        private void Lmenu_MouseDownModify(object sender, RoutedEventArgs e)
        {
            _NavigationStore.CurrentViewModel = new ModifyViewModel(tvis);
        }

        private void Lmenu_MouseDownDeletetion(object sender, RoutedEventArgs e)
        {
            _NavigationStore.CurrentViewModel = new DeletetionViewModel(tvis);
        }

        private void Lmenu_MouseDownInfo(object sender, RoutedEventArgs e)
        {
            _NavigationStore.CurrentViewModel = new InfoViewModel();
        }

        private void Lmenu_MouseDownExit(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
