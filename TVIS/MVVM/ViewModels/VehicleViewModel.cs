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
    public class VehicleViewModel:TableViewModel
    {
        private readonly Vehicle _Vehicle;
        public string Pelak => _Vehicle.Pelak;
        public string? Type => _Vehicle.TypeOfVehicle.ToString();
        public string? Year => _Vehicle.YearOfConstruction.ToString();
        public VehicleViewModel(Vehicle vehicle)
        {
            _Vehicle = vehicle;
        }
    }
}
