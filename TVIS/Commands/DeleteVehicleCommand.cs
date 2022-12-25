using System;
using System.Collections.Generic;
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

        public DeleteVehicleCommand(DeletetionViewModel deletetionViewModel, TVISModel tvis)
        {
            this.deletetionViewModel = deletetionViewModel;
            this.tvis = tvis;

            deletetionViewModel.PropertyChanged += OnViewModelPropertyChenged;
        }

        public override void Execute(object? parameter)
        {
            string? Pelak = deletetionViewModel.Vehicles.ElementAtOrDefault((int)deletetionViewModel.PersonsIndex).Pelak;
            tvis.DeleteVehicles(Pelak);
        }
        public override bool CanExecute(object? parameter)
        {
            return deletetionViewModel.VehiclesIndex != null && base.CanExecute(parameter);
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
