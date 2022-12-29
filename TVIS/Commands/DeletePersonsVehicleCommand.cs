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
    public class DeletePersonsVehicleCommand : CommandBase
    {
        private readonly DeletetionViewModel deletetionViewModel;
        private readonly TVISModel tvis;
        private readonly ObservableCollection<PersonsVehicleViewModel> personsVehicles;

        public DeletePersonsVehicleCommand(DeletetionViewModel deletetionViewModel, TVISModel tvis, ObservableCollection<PersonsVehicleViewModel> _PersonsVehicles)
        {
            this.deletetionViewModel = deletetionViewModel;
            this.tvis = tvis;
            personsVehicles = _PersonsVehicles;
            deletetionViewModel.PropertyChanged += OnViewModelPropertyChenged;
        }

        public override void Execute(object? parameter)
        {
            string? Pelak = deletetionViewModel.PersonsVehicles.ElementAtOrDefault((int)deletetionViewModel.PersonsVehiclesIndex).Pelak;
            string? ID = deletetionViewModel.PersonsVehicles.ElementAtOrDefault((int)deletetionViewModel.PersonsVehiclesIndex).ID;
            tvis.DeletePersonsVehicles(ID, Pelak);
            personsVehicles.RemoveAt((int)deletetionViewModel.PersonsVehiclesIndex);
            deletetionViewModel.PersonsVehiclesIndex = -1;
        }
        public override bool CanExecute(object? parameter)
        {
            return deletetionViewModel.PersonsVehiclesIndex != null && deletetionViewModel.PersonsVehiclesIndex != -1 && base.CanExecute(parameter);
        }
        private void OnViewModelPropertyChenged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(deletetionViewModel.PersonsVehiclesIndex))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
