using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVIS.MVVM.Models;
using TVIS.Stores;

namespace TVIS.MVVM.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        public ViewModelBase CurentViewModel => _navigationStore.CurrentViewModel;



        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChenged += _navigationStore_CurrentViewModelChenged;
        }

        private void _navigationStore_CurrentViewModelChenged()
        {
            OnPropertyChanged(nameof(CurentViewModel));
        }
    }
}
