using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVIS.MVVM.Models;

namespace TVIS.MVVM.ViewModels
{
    public class VehiclesViolationViewModel : TableViewModel
    {
        private readonly VehiclesViolation _VehiclesViolation;
        public string? FirstName => _VehiclesViolation.FirstName;
        public string? LastName => _VehiclesViolation.LastName;
        public string? CostSum => _VehiclesViolation.CostSum.ToString();
        public VehiclesViolationViewModel(VehiclesViolation vehiclesViolation)
        {
            _VehiclesViolation = vehiclesViolation;
        }
    }
}
