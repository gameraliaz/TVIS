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
    public class DeleteViolationCommand : CommandBase
    {
        private readonly DeletetionViewModel deletetionViewModel;
        private readonly TVISModel tvis;

        public DeleteViolationCommand(DeletetionViewModel deletetionViewModel, TVISModel tvis)
        {
            this.deletetionViewModel = deletetionViewModel;
            this.tvis = tvis;

            deletetionViewModel.PropertyChanged += OnViewModelPropertyChenged;
        }

        public override void Execute(object? parameter)
        {
            string? Pelak = deletetionViewModel.Violations.ElementAtOrDefault((int)deletetionViewModel.ViolationsIndex).Pelak;
            string? Time = deletetionViewModel.Violations.ElementAtOrDefault((int)deletetionViewModel.ViolationsIndex).Time;
            string? ID = deletetionViewModel.Violations.ElementAtOrDefault((int)deletetionViewModel.ViolationsIndex).ID;
            tvis.DeleteViolation( ID,Pelak,DateTime.Parse(Time));
        }
        public override bool CanExecute(object? parameter)
        {
            return deletetionViewModel.ViolationsIndex != null && base.CanExecute(parameter);
        }
        private void OnViewModelPropertyChenged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(deletetionViewModel.ViolationsIndex))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
