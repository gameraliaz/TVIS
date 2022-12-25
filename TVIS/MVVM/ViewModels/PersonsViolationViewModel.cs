using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVIS.MVVM.Models;

namespace TVIS.MVVM.ViewModels
{
    public class PersonsViolationViewModel : TableViewModel
    {
        private readonly PersonsViolation _PersonsViolation;
        public string Pelak => _PersonsViolation.Pelak;
        public string? CostSum => _PersonsViolation.CostSum.ToString();
        public PersonsViolationViewModel(PersonsViolation personsViolation)
        {
            _PersonsViolation = personsViolation;
        }
    }
}
