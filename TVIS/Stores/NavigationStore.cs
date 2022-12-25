using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVIS.MVVM.ViewModels;

namespace TVIS.Stores
{
    public class NavigationStore
    {
        private ViewModelBase _CurentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _CurentViewModel;
            set
            {
                _CurentViewModel= value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChenged?.Invoke();
        }

        public event Action CurrentViewModelChenged;
    }
}
