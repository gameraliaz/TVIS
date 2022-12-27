using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TVIS.Exceptions;
using TVIS.MVVM.Models;
using TVIS.MVVM.ViewModels;

namespace TVIS.Commands
{
    public class EditVehicleCommand:CommandBase
    {
        private readonly ModifyViewModel modifyViewModel;
        private readonly TVISModel tvis;

        public EditVehicleCommand(ModifyViewModel modifyViewModel, TVISModel tvis)
        {
            this.modifyViewModel = modifyViewModel;
            this.tvis = tvis;

            modifyViewModel.PropertyChanged += OnViewModelPropertyChenged;
        }

        public override void Execute(object? parameter)
        {
            short? vehicleyear = null;
            if (!string.IsNullOrEmpty(modifyViewModel.VehicleYear?.Trim()))
            {
                vehicleyear = Convert.ToInt16(modifyViewModel.VehicleYear);
            }
            Vehicle vehicle = new(modifyViewModel.VehiclePelak)
            {
                TypeOfVehicle = (VehiclesType?)modifyViewModel.VehicleType,
                YearOfConstruction = vehicleyear
            };
            tvis.EditVehicles(vehicle);
        }
        public override bool CanExecute(object? parameter)
        {
            return (!string.IsNullOrEmpty(modifyViewModel.VehiclePelak?.Trim())) && tvis.GetVehicles().Where(v => v.Equals(new Vehicle(modifyViewModel.VehiclePelak))).Count() > 0 && base.CanExecute(parameter);
        }
        private void OnViewModelPropertyChenged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(modifyViewModel.VehiclePelak))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
