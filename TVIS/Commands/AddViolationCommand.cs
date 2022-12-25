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
    public class AddViolationCommand:CommandBase
    {
        private readonly InsertionViewModel insertionViewModel;
        private readonly TVISModel tvis;

        public AddViolationCommand(InsertionViewModel insertionViewModel, TVISModel tvis)
        {
            this.insertionViewModel = insertionViewModel;
            this.tvis = tvis;
            insertionViewModel.PropertyChanged += OnViewModelPropertyChenged;
        }

        public override void Execute(object? parameter)
        {
            int? cost = null;
            if (Convert.ToInt32(insertionViewModel.ViolationCost)!=0)
                cost = Convert.ToInt32(insertionViewModel.ViolationCost.Trim());
            Violation violation = new(new Person(insertionViewModel.ViolationID), new Vehicle(insertionViewModel.ViolationPelak),
                insertionViewModel.ViolationTime)
            {
                Cost = cost,
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
        public override bool CanExecute(object? parameter)
        {
            return (!string.IsNullOrEmpty(insertionViewModel.ViolationID?.Trim())) && (!string.IsNullOrEmpty(insertionViewModel.ViolationPelak?.Trim()))  && base.CanExecute(parameter);
        }
        private void OnViewModelPropertyChenged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(insertionViewModel.ViolationID) || e.PropertyName == nameof(insertionViewModel.ViolationPelak))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
