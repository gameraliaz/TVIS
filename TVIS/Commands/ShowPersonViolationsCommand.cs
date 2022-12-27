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
    public class ShowPersonViolationsCommand:CommandBase
    {
        private readonly DashboardViewModel dashboardViewModel;
        private readonly TVISModel tvis;
        private readonly ObservableCollection<PersonsViolationViewModel> personsViolations;

        public ShowPersonViolationsCommand(DashboardViewModel dashboardViewModel, TVISModel tvis, ObservableCollection<PersonsViolationViewModel> _PersonsViolations)
        {
            this.dashboardViewModel = dashboardViewModel;
            this.tvis = tvis;
            personsViolations = _PersonsViolations;
            dashboardViewModel.PropertyChanged += OnViewModelPropertyChenged;
        }

        public override bool CanExecute(object? parameter)
        {
            return (!string.IsNullOrEmpty(dashboardViewModel.PVID?.Trim())) && base.CanExecute(parameter);
        }
        private void OnViewModelPropertyChenged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(dashboardViewModel.PVID))
            {
                OnCanExecuteChanged();
            }
        }

        public override void Execute(object? parameter)
        {
            personsViolations.Clear();
            dashboardViewModel.Table = dashboardViewModel.PersonsViolations;

            string ID = dashboardViewModel.PVID;
            var get = tvis.GetPersonsViolations(ID);
            foreach ( var pv in get.Item2)
            {
                PersonsViolationViewModel _pv = new(pv);
                personsViolations.Add( _pv );
            }
            dashboardViewModel.imgVVPelak = get.Item1;
        }
    }
}
