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
    public class EditViolationCommand : CommandBase
    {
        private readonly ModifyViewModel modifyViewModel;
        private readonly TVISModel tvis;

        public EditViolationCommand(ModifyViewModel modifyViewModel, TVISModel tvis)
        {
            this.modifyViewModel = modifyViewModel;
            this.tvis = tvis;

            modifyViewModel.PropertyChanged += OnViewModelPropertyChenged;
        }

        public override void Execute(object? parameter)
        {
            int? cost = null;
            if (!string.IsNullOrEmpty(modifyViewModel.ViolationCost?.Trim()))
                cost = Convert.ToInt32(modifyViewModel.ViolationCost.Trim());
            Violation violation = new(new Person(modifyViewModel.ViolationID), new Vehicle(modifyViewModel.ViolationPelak),
                modifyViewModel.ViolationTime)
            {
                Cost = cost,
                TypeOfViolation = (ViolationsType?)modifyViewModel.ViolationType
            };
            tvis.EditViolation(violation);
        }
        public override bool CanExecute(object? parameter)
        {
            return (!string.IsNullOrEmpty(modifyViewModel.ViolationID?.Trim())) && (!string.IsNullOrEmpty(modifyViewModel.ViolationPelak?.Trim())) && tvis.GetViolations().Where(v => v.Equals(new Violation(new(modifyViewModel.ViolationID),new(modifyViewModel.ViolationPelak),modifyViewModel.ViolationTime))).Count() > 0 && base.CanExecute(parameter);
        }
        private void OnViewModelPropertyChenged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(modifyViewModel.ViolationID) || e.PropertyName == nameof(modifyViewModel.ViolationPelak) || e.PropertyName == nameof(modifyViewModel.ViolationTime))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
