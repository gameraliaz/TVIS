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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
