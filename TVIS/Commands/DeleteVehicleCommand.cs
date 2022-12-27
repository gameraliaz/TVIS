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
    public class DeleteVehicleCommand : CommandBase
    {
        private readonly DeletetionViewModel deletetionViewModel;
        private readonly TVISModel tvis;
        private readonly ObservableCollection<VehicleViewModel> vehicles;

        public DeleteVehicleCommand(DeletetionViewModel deletetionViewModel, TVISModel tvis, ObservableCollection<VehicleViewModel> _Vehicles)
        {
            this.deletetionViewModel = deletetionViewModel;
            this.tvis = tvis;
            vehicles = _Vehicles;
            deletetionViewModel.PropertyChanged += OnViewModelPropertyChenged;
        }

        public override void Execute(object? parameter)
        {
            string? Pelak = deletetionViewModel.Vehicles.ElementAtOrDefault((int)deletetionViewModel.VehiclesIndex).Pelak;
            tvis.DeleteVehicles(Pelak);
            vehicles.RemoveAt((int)deletetionViewModel.VehiclesIndex);
            deletetionViewModel.VehiclesIndex = -1;
        }
        public override bool CanExecute(object? parameter)
        {
            return deletetionViewModel.VehiclesIndex != null && deletetionViewModel.VehiclesIndex != -1 && base.CanExecute(parameter);
        }
        private void OnViewModelPropertyChenged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(deletetionViewModel.VehiclesIndex))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
