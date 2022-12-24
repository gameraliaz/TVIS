using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TVIS.MVVM.ViewModels
{
    public class DeletetionViewModel:ViewModelBase
    {
        private readonly ObservableCollection<PersonViewModel> _Persons;
        public IEnumerable<PersonViewModel> Persons => _Persons;
        private readonly ObservableCollection<VehicleViewModel> _Vehicles;
        public IEnumerable<VehicleViewModel> Vehicles => _Vehicles;
        private readonly ObservableCollection<ViolationViewModel> _Violations;
        public IEnumerable<ViolationViewModel> Violations => _Violations;
        private readonly ObservableCollection<PersonsVehicleViewModel> _PersonsVehicles;
        public IEnumerable<PersonsVehicleViewModel> PersonsVehicles => _PersonsVehicles;
        public ICommand DeletePerson { get; }
        public ICommand DeleteVehicle { get; }
        public ICommand DeleteViolation { get; }
        public ICommand DeletePersonsVehicle { get; }

        public DeletetionViewModel()
        {
            _Persons = new();
            _Vehicles = new();
            _Violations = new();
            _PersonsVehicles = new();
        }

    }
}
