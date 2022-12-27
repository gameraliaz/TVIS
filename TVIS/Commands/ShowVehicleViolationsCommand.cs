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
    public class ShowVehicleViolationsCommand : CommandBase
    {
        private readonly DashboardViewModel dashboardViewModel;
        private readonly TVISModel tvis;
        private readonly ObservableCollection<VehiclesViolationViewModel> vehiclesViolations;

        public ShowVehicleViolationsCommand(DashboardViewModel dashboardViewModel, TVISModel tvis, ObservableCollection<VehiclesViolationViewModel> _VehiclesViolations)
        {
            this.dashboardViewModel = dashboardViewModel;
            this.tvis = tvis;
            vehiclesViolations = _VehiclesViolations;
            dashboardViewModel.PropertyChanged += OnViewModelPropertyChenged;
        }

        public override bool CanExecute(object? parameter)
        {
            return (!string.IsNullOrEmpty(dashboardViewModel.VVPelak?.Trim())) && base.CanExecute(parameter);
        }
        private void OnViewModelPropertyChenged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(dashboardViewModel.VVPelak))
            {
                OnCanExecuteChanged();
            }
        }

        public override void Execute(object? parameter)
        {
            dashboardViewModel.Table = dashboardViewModel.VehiclesViolations;
            vehiclesViolations.Clear();
            string Pelak = dashboardViewModel.VVPelak;
            var get = tvis.GetVehiclesViolations(Pelak);
            foreach (var pv in get)
            {
                VehiclesViolationViewModel _v = new(pv);
                vehiclesViolations.Add(_v);
            }
        }
    }
}
