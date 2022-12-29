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
    public class AddVehicleCommand:CommandBase
    {
        private readonly InsertionViewModel insertionViewModel;
        private readonly TVISModel tvis;

        public AddVehicleCommand(InsertionViewModel insertionViewModel, TVISModel tvis)
        {
            this.insertionViewModel = insertionViewModel;
            this.tvis = tvis;
            insertionViewModel.PropertyChanged += OnViewModelPropertyChenged;

        }

        public override void Execute(object? parameter)
        {
            short? vehicleyear=null ;
            if(!string.IsNullOrEmpty(insertionViewModel.VehicleYear?.Trim()))
            {
                vehicleyear = Convert.ToInt16(insertionViewModel.VehicleYear);
            }
            Vehicle vehicle = new(insertionViewModel.VehiclePelak)
            {
                TypeOfVehicle = (VehiclesType?)insertionViewModel.VehicleType,
                YearOfConstruction = vehicleyear
            };
            try
            {
                tvis.MakeVehicle(vehicle);
            }
            catch (VehicleExsistingException ex)
            {
                MessageBox.Show($"Vehicle alredy exsist with this Pelak. \n(exsisting:{ex.ExistingVehicle},Incoming:{ex.IncomingVehicle})",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        public override bool CanExecute(object? parameter)
        {
            return (!string.IsNullOrEmpty(insertionViewModel.VehiclePelak?.Trim())) && base.CanExecute(parameter);
        }
        private void OnViewModelPropertyChenged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(insertionViewModel.VehiclePelak))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
