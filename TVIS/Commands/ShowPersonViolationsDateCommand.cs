using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVIS.MVVM.Models;
using TVIS.MVVM.ViewModels;

namespace TVIS.Commands
{
    public class ShowPersonViolationsDateCommand : CommandBase
    {
        private readonly DashboardViewModel dashboardViewModel;
        private readonly TVISModel tvis;
        private readonly ObservableCollection<ViolationViewModel> personsTimeViolations;

        public ShowPersonViolationsDateCommand(DashboardViewModel dashboardViewModel, TVISModel tvis,ObservableCollection<ViolationViewModel> _PersonsTimeViolations)
        {
            this.dashboardViewModel = dashboardViewModel;
            this.tvis = tvis;
            personsTimeViolations = _PersonsTimeViolations; 
            dashboardViewModel.PropertyChanged += OnViewModelPropertyChenged;
        }

        public override bool CanExecute(object? parameter)
        {
            return (!string.IsNullOrEmpty(dashboardViewModel.PVDID?.Trim())) && base.CanExecute(parameter);
        }
        private void OnViewModelPropertyChenged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(dashboardViewModel.PVDID))
            {
                OnCanExecuteChanged();
            }
        }

        public override void Execute(object? parameter)
        {
            dashboardViewModel.Table = dashboardViewModel.PersonsTimeViolations;
            personsTimeViolations.Clear();
            string ID = dashboardViewModel.PVDID;
            var get = tvis.GetPersonsViolationsTime(ID,dashboardViewModel.StartDate,dashboardViewModel.EndDate);
            foreach (var pv in get)
            {
                ViolationViewModel _v = new(pv);
                personsTimeViolations.Add(_v);
            }
        }
    }
}
