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
    public class AddPersonCommand : CommandBase
    {
        private readonly InsertionViewModel insertionViewModel;
        private readonly TVISModel tvis;

        public AddPersonCommand(InsertionViewModel insertionViewModel,TVISModel tvis)
        {
            this.insertionViewModel = insertionViewModel;
            this.tvis = tvis;

        }

        public override void Execute(object? parameter)
        {
            Person person = new(insertionViewModel.PersonID)
            {
                FirstName = insertionViewModel.PersonFirstName,
                LastName = insertionViewModel.PersonLastName,
                Image = insertionViewModel.PersonImage
            };
            try
            {
                tvis.MakePerson(person);
            }
            catch(PersonExsistingException ex)
            {
                MessageBox.Show($"Person alredy exsist with this ID. \n(exsisting:{ex.ExistingPerson},Incoming:{ex.IncomingPerson})",
                    "Error",MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }
}
