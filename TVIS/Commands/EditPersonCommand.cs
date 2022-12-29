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
    public class EditPersonCommand:CommandBase
    {
        private readonly ModifyViewModel modifyViewModel;
        private readonly TVISModel tvis;

        public EditPersonCommand(ModifyViewModel modifyViewModel, TVISModel tvis)
        {
            this.modifyViewModel = modifyViewModel;
            this.tvis = tvis;

            modifyViewModel.PropertyChanged += OnViewModelPropertyChenged;
        }

        public override void Execute(object? parameter)
        {
            string? firstname = null;
            string? lastname = null;
            if (!string.IsNullOrEmpty(modifyViewModel.PersonFirstName?.Trim()))
                firstname = modifyViewModel.PersonFirstName.Trim();
            if (!string.IsNullOrEmpty(modifyViewModel.PersonLastName?.Trim()))
                lastname = modifyViewModel.PersonLastName.Trim();
            Person person = new(modifyViewModel.PersonID)
            {
                FirstName = firstname,
                LastName = lastname,
                Image = modifyViewModel.PersonImage
            };
            tvis.EditPersons(person);
        }
        public override bool CanExecute(object? parameter)
        {
            return (!string.IsNullOrEmpty(modifyViewModel.PersonID?.Trim())) && tvis.GetPersons().Where(v => v.Equals(new Person(modifyViewModel.PersonID))).Count()>0 && base.CanExecute(parameter);
        }
        private void OnViewModelPropertyChenged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(modifyViewModel.PersonID))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
