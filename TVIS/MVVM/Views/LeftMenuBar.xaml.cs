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
    /// Interaction logic for LeftMenuBar.xaml
    /// </summary>
    public partial class LeftMenuBar : UserControl
    {
        public LeftMenuBar()
        {
            InitializeComponent();
        }
        public event RoutedEventHandler MouseDownMenuColapsing
        {
            add { AddHandler(MouseDownMenuColapsingEvent, value); }
            remove { RemoveHandler(MouseDownMenuColapsingEvent, value); }
        }
        public event RoutedEventHandler MouseDownMenuExpanding
        {
            add { AddHandler(MouseDownMenuExpandingEvent, value); }
            remove { RemoveHandler(MouseDownMenuExpandingEvent, value); }
        }

        public static readonly RoutedEvent MouseDownMenuColapsingEvent = EventManager.RegisterRoutedEvent(
"MouseDownMenuColapsing", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(LeftMenuBar));

        public static readonly RoutedEvent MouseDownMenuExpandingEvent = EventManager.RegisterRoutedEvent(
"MouseDownMenuExpanding", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(LeftMenuBar));


        private void Logo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (textBlock4.Visibility==Visibility.Visible)
            {
                RaiseEvent(new RoutedEventArgs(MouseDownMenuColapsingEvent));
                Storyboard? sb = (Resources["StoryboardClosingmenu"] as Storyboard);
                sb?.Begin();
            }else
            {
                RaiseEvent(new RoutedEventArgs(MouseDownMenuExpandingEvent));
                Storyboard? sb = (Resources["StoryboardOpeningmenu"] as Storyboard);
                sb?.Begin();
            }
        }

        private void MouseEnterBorder(object sender, MouseEventArgs e)
        {
            if(((Border)sender).Name==Dashboard.Name)
            {
                DashBack.Background = new SolidColorBrush(Color.FromRgb(19,31,58));
            }
            else if (((Border)sender).Name == Insertion.Name)
            {
                InsBack.Background = new SolidColorBrush(Color.FromRgb(19, 31, 58));
            }
            else if (((Border)sender).Name == Modify.Name)
            {
                ModBack.Background = new SolidColorBrush(Color.FromRgb(19, 31, 58));
            }
            else if (((Border)sender).Name == Deletetion.Name)
            {
                DelBack.Background = new SolidColorBrush(Color.FromRgb(19, 31, 58));
            }
        }

        private void MouseLeaveBorder(object sender, MouseEventArgs e)
        {
            if (((Border)sender).Name == Dashboard.Name)
            {
                DashBack.Background = new SolidColorBrush(Colors.Transparent);
            }
            else if (((Border)sender).Name == Insertion.Name)
            {
                InsBack.Background = new SolidColorBrush(Colors.Transparent);
            }
            else if (((Border)sender).Name == Modify.Name)
            {
                ModBack.Background = new SolidColorBrush(Colors.Transparent);
            }
            else if (((Border)sender).Name == Deletetion.Name)
            {
                DelBack.Background = new SolidColorBrush(Colors.Transparent);
            }
        }
    }
}
