using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using TVIS.Exceptions;
using TVIS.MVVM.Models;
using TVIS.MVVM.ViewModels;

namespace TVIS.Commands
{
    public class AddPersonCommand : CommandBase
    {
        private readonly InsertionViewModel insertionViewModel;
        private readonly TVISModel tvis;

        public AddPersonCommand(InsertionViewModel insertionViewModel, TVISModel tvis)
        {
            this.insertionViewModel = insertionViewModel;
            this.tvis = tvis;

            insertionViewModel.PropertyChanged += OnViewModelPropertyChenged;
        }

        public override void Execute(object? parameter)
        {
            string? firstname = null;
            string? lastname = null;
            if (!string.IsNullOrEmpty(insertionViewModel.PersonFirstName?.Trim()))
                firstname = insertionViewModel.PersonFirstName.Trim();
            if (!string.IsNullOrEmpty(insertionViewModel.PersonLastName?.Trim()))
                lastname = insertionViewModel.PersonLastName.Trim();
            Person person = new(insertionViewModel.PersonID)
            {
                FirstName = firstname,
                LastName = lastname,
                Image = insertionViewModel.PersonImage
            };
            try
            {
                tvis.MakePerson(person);
            }
            catch (PersonExsistingException ex)
            {
                MessageBox.Show($"Person alredy exsist with this ID. \n(exsisting:{ex.ExistingPerson},Incoming:{ex.IncomingPerson})",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        public override bool CanExecute(object? parameter)
        {
            return (!string.IsNullOrEmpty(insertionViewModel.PersonID?.Trim())) && base.CanExecute(parameter);
        }
        private void OnViewModelPropertyChenged(object? sender, PropertyChangedEventArgs e)
        {
           if(e.PropertyName == nameof(insertionViewModel.PersonID))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
