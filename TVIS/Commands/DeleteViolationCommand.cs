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
    public class DeleteViolationCommand : CommandBase
    {
        private readonly DeletetionViewModel deletetionViewModel;
        private readonly TVISModel tvis;
        private readonly ObservableCollection<ViolationViewModel> _Violations;

        public DeleteViolationCommand(DeletetionViewModel deletetionViewModel, TVISModel tvis, ObservableCollection<ViolationViewModel> _Violations)
        {
            this.deletetionViewModel = deletetionViewModel;
            this.tvis = tvis;
            this._Violations = _Violations;
            deletetionViewModel.PropertyChanged += OnViewModelPropertyChenged;
        }

        public override void Execute(object? parameter)
        {
            string? Pelak = deletetionViewModel.Violations.ElementAtOrDefault((int)deletetionViewModel.ViolationsIndex).Pelak;
            string? Time = deletetionViewModel.Violations.ElementAtOrDefault((int)deletetionViewModel.ViolationsIndex).Time;
            string? ID = deletetionViewModel.Violations.ElementAtOrDefault((int)deletetionViewModel.ViolationsIndex).ID;
            tvis.DeleteViolation( ID,Pelak,DateTime.Parse(Time));
            _Violations.RemoveAt((int)deletetionViewModel.ViolationsIndex);
            deletetionViewModel.ViolationsIndex = -1;
        }
        public override bool CanExecute(object? parameter)
        {
            return deletetionViewModel.ViolationsIndex != null && deletetionViewModel.ViolationsIndex != -1 && base.CanExecute(parameter);
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
