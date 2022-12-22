using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
    }
}
