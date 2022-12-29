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
    public class ViolationViewModel:TableViewModel
    {
        private readonly Violation _Violation;
        public string ID => _Violation.Person.ID;
        public string Pelak => _Violation.Vehicle.Pelak;
        public string Time => _Violation.ViolationDateTime.ToString();
        public string? Type => _Violation.TypeOfViolation?.ToString();
        public string? Cost => _Violation.Cost?.ToString();
        public ViolationViewModel(Violation violation)
        {
            _Violation = violation;
        }
    }
}
