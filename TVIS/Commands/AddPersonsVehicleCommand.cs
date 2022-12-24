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
    public class AddPersonsVehicleCommand:CommandBase
    {
        private readonly InsertionViewModel insertionViewModel;
        private readonly TVISModel tvis;

        public AddPersonsVehicleCommand(InsertionViewModel insertionViewModel, TVISModel tvis)
        {
            this.insertionViewModel = insertionViewModel;
            this.tvis = tvis;
        }

        public override void Execute(object? parameter)
        {
            PersonsVehicle personsVehicle = new(new Person(insertionViewModel.ViolationID), new Vehicle(insertionViewModel.ViolationPelak));
            try
            {
                tvis.MakePersonsVehicle(personsVehicle);
            }
            catch (PersonsVehicleExsistingException ex)
            {
                MessageBox.Show($"Person's vehicle alredy exsist with this Pelak. \n(exsisting:{ex.ExistingPersonsVehicle},Incoming:{ex.IncomingPersonsVehicle})",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
