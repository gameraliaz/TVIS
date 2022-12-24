using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TVIS.MVVM.Models;

namespace TVIS.MVVM.ViewModels
{
    public class PersonViewModel:TableViewModel
    {
        private readonly Person _Person;
        public string? ID => _Person.ID;
        public string? FirstName => _Person.FirstName;
        public string? LastName => _Person.LastName;
        public BitmapSource? Image => _Person.Image;
        public PersonViewModel(Person person)
        {
            _Person = person;
        }
    }
}
