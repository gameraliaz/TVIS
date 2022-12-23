using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using TVIS.MVVM.Models;
using TVIS.MVVM.Views;

namespace TVIS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       

        public MainWindow()
        {
            InitializeComponent();
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
            var myWindow = Window.GetWindow(this);
            myWindow.DragMove();
        }

        private void Lmenu_MouseDownDashboard(object sender, RoutedEventArgs e)
        {

        }

        private void Lmenu_MouseDownInsertion(object sender, RoutedEventArgs e)
        {

        }

        private void Lmenu_MouseDownModify(object sender, RoutedEventArgs e)
        {

        }

        private void Lmenu_MouseDownDeletetion(object sender, RoutedEventArgs e)
        {

        }

        private void Lmenu_MouseDownInfo(object sender, RoutedEventArgs e)
        {

        }

        private void Lmenu_MouseDownExit(object sender, RoutedEventArgs e)
        {
            var myWindow = Window.GetWindow(this);
            myWindow.Close();
        }
    }
}
