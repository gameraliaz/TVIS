using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for Info.xaml
    /// </summary>
    public partial class Info : UserControl
    {
        public Info()
        {
            InitializeComponent();
        }

        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender==Github) Process.Start(new ProcessStartInfo { FileName = @"https://github.com/gameraliaz/", UseShellExecute = true });
            else if (sender==Code) Process.Start(new ProcessStartInfo { FileName = @"https://github.com/gameraliaz/TVIS", UseShellExecute = true }); 
            else if (sender==Telegram) Process.Start(new ProcessStartInfo { FileName = @"https://t.me/AliSoleimaniDorcheh", UseShellExecute = true }); 
        }
    }
}
