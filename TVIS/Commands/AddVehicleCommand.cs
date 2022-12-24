using System;
using System.Collections.Generic;
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

        }

        public override void Execute(object? parameter)
        {
            int? vehicleyear=null ;
            if(insertionViewModel.VehicleYear != "")
            {
                vehicleyear = Convert.ToInt32(insertionViewModel.VehicleYear);
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
    }
}
