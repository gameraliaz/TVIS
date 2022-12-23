using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TVIS.MVVM.Views
{
    /// <summary>
    /// Interaction logic for WinTool.xaml
    /// </summary>
    public partial class WinTool : UserControl
    {
        public WinTool()
        {
            InitializeComponent();
        }
        private void MinimizeWindow(object sender, MouseButtonEventArgs e)
        {
            var myWindow = Window.GetWindow(this);
            myWindow.WindowState = WindowState.Minimized;
        }

        private void MaximizeWindow(object sender, MouseButtonEventArgs e)
        {
            var myWindow = Window.GetWindow(this);
            if (myWindow.WindowState != WindowState.Maximized)
                myWindow.WindowState = WindowState.Maximized;
            else
                myWindow.WindowState = WindowState.Normal;
        }

        private void CloseWindow(object sender, MouseButtonEventArgs e)
        {
            var myWindow = Window.GetWindow(this);
            myWindow.Close();
        }
    }
}
