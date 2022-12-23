using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

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
            SelectedMenuIndex = 0;
        }



        public int SelectedMenuIndex
        {
            get { return (int)GetValue(SelectedMenuIndexProperty); }
            set
            {
                SetValue(SelectedMenuIndexProperty, value);
                DashBack.Background = new SolidColorBrush(Colors.Transparent);
                InsBack.Background = new SolidColorBrush(Colors.Transparent);
                ModBack.Background = new SolidColorBrush(Colors.Transparent);
                DelBack.Background = new SolidColorBrush(Colors.Transparent);
                InfBack.Background = new SolidColorBrush(Colors.Transparent);
                ExBack.Background = new SolidColorBrush(Colors.Transparent);
                if (value == 0)
                {
                    DashBack.Background = new SolidColorBrush(Color.FromRgb(19, 31, 58));
                    RaiseEvent(new RoutedEventArgs(MouseDownDashboardEvent));
                }
                else if (value == 1)
                {
                    InsBack.Background = new SolidColorBrush(Color.FromRgb(19, 31, 58));
                    RaiseEvent(new RoutedEventArgs(MouseDownInsertionEvent));
                }
                else if (value == 2)
                {
                    ModBack.Background = new SolidColorBrush(Color.FromRgb(19, 31, 58));
                    RaiseEvent(new RoutedEventArgs(MouseDownModifyEvent));
                }
                else if (value == 3)
                {
                    DelBack.Background = new SolidColorBrush(Color.FromRgb(19, 31, 58));
                    RaiseEvent(new RoutedEventArgs(MouseDownDeletetionEvent));
                }
                else if (value == 4)
                {
                    InfBack.Background = new SolidColorBrush(Color.FromRgb(19, 31, 58));
                    RaiseEvent(new RoutedEventArgs(MouseDownInfoEvent));
                }
                else if (value == 5)
                {
                    ExBack.Background = new SolidColorBrush(Color.FromRgb(19, 31, 58));
                    RaiseEvent(new RoutedEventArgs(MouseDownExitEvent));
                }
            }
        }

        // Using a DependencyProperty as the backing store for SelectedMenuIndex.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedMenuIndexProperty =
            DependencyProperty.Register("SelectedMenuIndex", typeof(int), typeof(LeftMenuBar), new PropertyMetadata(0));


        public event RoutedEventHandler MouseDownDashboard
        {
            add { AddHandler(MouseDownDashboardEvent, value); }
            remove { RemoveHandler(MouseDownDashboardEvent, value); }
        }
        public event RoutedEventHandler MouseDownInsertion
        {
            add { AddHandler(MouseDownInsertionEvent, value); }
            remove { RemoveHandler(MouseDownInsertionEvent, value); }
        }
        public event RoutedEventHandler MouseDownModify
        {
            add { AddHandler(MouseDownModifyEvent, value); }
            remove { RemoveHandler(MouseDownModifyEvent, value); }
        }
        public event RoutedEventHandler MouseDownDeletetion
        {
            add { AddHandler(MouseDownDeletetionEvent, value); }
            remove { RemoveHandler(MouseDownDeletetionEvent, value); }
        }
        public event RoutedEventHandler MouseDownInfo
        {
            add { AddHandler(MouseDownInfoEvent, value); }
            remove { RemoveHandler(MouseDownInfoEvent, value); }
        }
        public event RoutedEventHandler MouseDownExit
        {
            add { AddHandler(MouseDownExitEvent, value); }
            remove { RemoveHandler(MouseDownExitEvent, value); }
        }


        public static readonly RoutedEvent MouseDownDashboardEvent =
            EventManager.RegisterRoutedEvent("MouseDownDashboard", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(LeftMenuBar));
        public static readonly RoutedEvent MouseDownInsertionEvent =
            EventManager.RegisterRoutedEvent("MouseDownInsertion", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(LeftMenuBar));
        public static readonly RoutedEvent MouseDownModifyEvent =
            EventManager.RegisterRoutedEvent("MouseDownModify", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(LeftMenuBar));
        public static readonly RoutedEvent MouseDownDeletetionEvent =
            EventManager.RegisterRoutedEvent("MouseDownDeletetion", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(LeftMenuBar));
        public static readonly RoutedEvent MouseDownInfoEvent =
            EventManager.RegisterRoutedEvent("MouseDownInfo", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(LeftMenuBar));
        public static readonly RoutedEvent MouseDownExitEvent =
            EventManager.RegisterRoutedEvent("MouseDownExit", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(LeftMenuBar));








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


        public static readonly RoutedEvent MouseDownMenuColapsingEvent =
            EventManager.RegisterRoutedEvent("MouseDownMenuColapsing", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(LeftMenuBar));

        public static readonly RoutedEvent MouseDownMenuExpandingEvent =
            EventManager.RegisterRoutedEvent("MouseDownMenuExpanding", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(LeftMenuBar));


        private void Logo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (textBlock4.Visibility == Visibility.Visible)
            {
                RaiseEvent(new RoutedEventArgs(MouseDownMenuColapsingEvent));
                Storyboard? sb = (Resources["StoryboardClosingmenu"] as Storyboard);
                sb?.Begin();
            }
            else
            {
                RaiseEvent(new RoutedEventArgs(MouseDownMenuExpandingEvent));
                Storyboard? sb = (Resources["StoryboardOpeningmenu"] as Storyboard);
                sb?.Begin();
            }
        }

        private void MouseEnterBorder(object sender, MouseEventArgs e)
        {
            if (((Border)sender).Name == Dashboard.Name)
            {
                DashBack.Background = new SolidColorBrush(Color.FromRgb(19, 31, 58));
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
            else if (((Border)sender).Name == Info.Name)
            {
                InfBack.Background = new SolidColorBrush(Color.FromRgb(19, 31, 58));
            }
            else if (((Border)sender).Name == Exit.Name)
            {
                ExBack.Background = new SolidColorBrush(Color.FromRgb(19, 31, 58));
            }
        }

        private void MouseLeaveBorder(object sender, MouseEventArgs e)
        {
            if (((Border)sender).Name == Dashboard.Name)
            {
                if (SelectedMenuIndex != 0)
                    DashBack.Background = new SolidColorBrush(Colors.Transparent);
            }
            else if (((Border)sender).Name == Insertion.Name)
            {
                if (SelectedMenuIndex != 1)
                    InsBack.Background = new SolidColorBrush(Colors.Transparent);
            }
            else if (((Border)sender).Name == Modify.Name)
            {
                if (SelectedMenuIndex != 2)
                    ModBack.Background = new SolidColorBrush(Colors.Transparent);
            }
            else if (((Border)sender).Name == Deletetion.Name)
            {
                if (SelectedMenuIndex != 3)
                    DelBack.Background = new SolidColorBrush(Colors.Transparent);
            }
            else if (((Border)sender).Name == Info.Name)
            {
                if (SelectedMenuIndex != 4)
                    InfBack.Background = new SolidColorBrush(Colors.Transparent);
            }
            else if (((Border)sender).Name == Exit.Name)
            {
                if (SelectedMenuIndex != 5)
                    ExBack.Background = new SolidColorBrush(Colors.Transparent);
            }
        }

        private void MouseDownBorder(object sender, MouseButtonEventArgs e)
        {
            if (((Border)sender).Name == Dashboard.Name)
            {
                SelectedMenuIndex = 0;
            }
            else if (((Border)sender).Name == Insertion.Name)
            {
                SelectedMenuIndex = 1;
            }
            else if (((Border)sender).Name == Modify.Name)
            {
                SelectedMenuIndex = 2;
            }
            else if (((Border)sender).Name == Deletetion.Name)
            {
                SelectedMenuIndex = 3;
            }
            else if (((Border)sender).Name == Info.Name)
            {
                SelectedMenuIndex = 4;
            }
            else if (((Border)sender).Name == Exit.Name)
            {
                SelectedMenuIndex = 5;
            }
        }
    }
}
