using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVIS.MVVM.Models;

namespace TVIS.MVVM.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        public ViewModelBase CurentViewModel { get; }
        public MainViewModel(TVISModel tvis)
        {
            CurentViewModel = new InsertionViewModel(tvis);
        }
    }
}
