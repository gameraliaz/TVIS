using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace TVIS.MVVM.Views
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        public MainMenu()
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
