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
    public class AddViolationCommand:CommandBase
    {
        private readonly InsertionViewModel insertionViewModel;
        private readonly TVISModel tvis;

        public AddViolationCommand(InsertionViewModel insertionViewModel, TVISModel tvis)
        {
            this.insertionViewModel = insertionViewModel;
            this.tvis = tvis;

        }

        public override void Execute(object? parameter)
        {
            Violation violation = new(new Person(insertionViewModel.ViolationID), new Vehicle(insertionViewModel.ViolationPelak),
                insertionViewModel.ViolationTime)
            {
                Cost = Convert.ToInt32(insertionViewModel.ViolationCost),
                TypeOfViolation = (ViolationsType?)insertionViewModel.ViolationType
            };
            try
            {
                tvis.MakeViolation(violation);
            }
            catch (ViolationExsistingException ex)
            {
                MessageBox.Show($"Violation alredy exsist with this Pelak. \n(exsisting:{ex.ExistingViolation},Incoming:{ex.IncomingViolation})",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
