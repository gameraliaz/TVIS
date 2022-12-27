using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TVIS.Commands;
using TVIS.MVVM.Models;

namespace TVIS.MVVM.ViewModels
{
    public class DeletetionViewModel:ViewModelBase
    {
        private int? _PersonsIndex;
        public int? PersonsIndex
        {
            get
            {
                return _PersonsIndex;
            }
            set
            {
                _PersonsIndex = value;
                OnPropertyChanged(nameof(PersonsIndex));
                
            }
        }
        private int? _VehiclesIndex;
        public int? VehiclesIndex
        {
            get
            {
                return _VehiclesIndex;
            }
            set
            {
                _VehiclesIndex = value;
                OnPropertyChanged(nameof(VehiclesIndex));
            }
        }
        private int? _ViolationsIndex;
        public int? ViolationsIndex
        {
            get
            {
                return _ViolationsIndex;
            }
            set
            {
                _ViolationsIndex = value;
                OnPropertyChanged(nameof(ViolationsIndex));
            }
        }
        private int? _PersonsVehiclesIndex;
        public int? PersonsVehiclesIndex
        {
            get
            {
                return _PersonsVehiclesIndex;
            }
            set
            {
                _PersonsVehiclesIndex = value;
                OnPropertyChanged(nameof(PersonsVehiclesIndex));
            }
        }
        private readonly ObservableCollection<PersonViewModel> _Persons;
        public IEnumerable<PersonViewModel> Persons => _Persons;
        private readonly ObservableCollection<VehicleViewModel> _Vehicles;
        public IEnumerable<VehicleViewModel> Vehicles => _Vehicles;
        private readonly ObservableCollection<ViolationViewModel> _Violations;
        public IEnumerable<ViolationViewModel> Violations => _Violations;
        private readonly ObservableCollection<PersonsVehicleViewModel> _PersonsVehicles;
        private readonly TVISModel tvis;

        public IEnumerable<PersonsVehicleViewModel> PersonsVehicles => _PersonsVehicles;
        public ICommand DeletePerson { get; }
        public ICommand DeleteVehicle { get; }
        public ICommand DeleteViolation { get; }
        public ICommand DeletePersonsVehicle { get; }

        public DeletetionViewModel(TVISModel tvis)
        {
            _Persons = new();
            _Vehicles = new();
            _Violations = new();
            _PersonsVehicles = new();

            DeletePerson = new DeletePersonCommand(this, tvis, _Persons);
            DeleteVehicle=new DeleteVehicleCommand(this,tvis, _Vehicles);
            DeleteViolation=new DeleteViolationCommand(this,tvis, _Violations);
            DeletePersonsVehicle=new DeletePersonsVehicleCommand(this,tvis, _PersonsVehicles);

            this.tvis = tvis;
            UpdateView();
        }
        private void UpdateView()
        {
            _Persons.Clear();
            _Vehicles.Clear();
            _Violations.Clear();
            _PersonsVehicles.Clear();

            foreach (var a in tvis.GetPersons())
            {
                PersonViewModel p = new(a);
                _Persons.Add(p);
            }
            foreach (var a in tvis.GetVehicles())
            {
                VehicleViewModel v = new(a);
                _Vehicles.Add(v);
            }
            foreach (var a in tvis.GetViolations())
            {
                ViolationViewModel v = new(a);
                _Violations.Add(v);
            }
            foreach (var a in tvis.GetPersonsVehicles())
            {
                PersonsVehicleViewModel pv = new(a);
                _PersonsVehicles.Add(pv);
            }
        }

    }
}
