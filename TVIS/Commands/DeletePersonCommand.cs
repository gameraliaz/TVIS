using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class DeletePersonCommand : CommandBase
    {
        private readonly DeletetionViewModel deletetionViewModel;
        private readonly TVISModel tvis;
        private readonly ObservableCollection<PersonViewModel> persons;

        public DeletePersonCommand(DeletetionViewModel deletetionViewModel, TVISModel tvis, ObservableCollection<PersonViewModel> _Persons)
        {
            this.deletetionViewModel = deletetionViewModel;
            this.tvis = tvis;
            persons = _Persons;
            deletetionViewModel.PropertyChanged += OnViewModelPropertyChenged;
        }

        public override void Execute(object? parameter)
        {
            string? ID = deletetionViewModel.Persons.ElementAtOrDefault((int)deletetionViewModel.PersonsIndex).ID;
            tvis.DeletePersons(ID);
            persons.RemoveAt((int)deletetionViewModel.PersonsIndex);
            deletetionViewModel.PersonsIndex = -1;
        }
        public override bool CanExecute(object? parameter)
        {
            return deletetionViewModel.PersonsIndex!=null && deletetionViewModel.PersonsIndex != -1 && base.CanExecute(parameter);
        }
        private void OnViewModelPropertyChenged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(deletetionViewModel.PersonsIndex))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
