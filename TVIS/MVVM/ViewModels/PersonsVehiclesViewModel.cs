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
    public class PersonsVehicleViewModel:ViewModelBase
    {
        private readonly PersonsVehicle _PersonsVehicle;
        public string ID => _PersonsVehicle.Person.ID;
        public string Pelak => _PersonsVehicle.Vehicle.Pelak;
        public PersonsVehicleViewModel(PersonsVehicle PersonsVehicle)
        {
            _PersonsVehicle = PersonsVehicle;
        }
    }
}
