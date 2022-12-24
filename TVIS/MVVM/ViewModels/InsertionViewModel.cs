using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TVIS.MVVM.ViewModels
{
    public class InsertionViewModel:ViewModelBase
    {
        public ICommand AddPerson { get; }
        public ICommand AddVehicle { get; }
        public ICommand AddViolation { get; }
        public ICommand AddPersonsVehicle { get; }
        public ICommand SelectImg { get; }
        private string _PersonID;
        public string PersonID
        {
            get
            {
                return _PersonID;
            }
            set
            {
                _PersonID = value;
                OnPropertyChanged(nameof(PersonID));
            }
        }
        private string _PersonFirstName;
        public string PersonFirstName
        {
            get
            {
                return _PersonFirstName;
            }
            set
            {
                _PersonFirstName = value;
                OnPropertyChanged(nameof(PersonFirstName));
            }
        }
        private string _PersonLastName;
        public string PersonLastName
        {
            get
            {
                return _PersonLastName;
            }
            set
            {
                _PersonLastName = value;
                OnPropertyChanged(nameof(PersonLastName));
            }
        }
        private string _VehiclePelak;
        public string VehiclePelak
        {
            get
            {
                return _VehiclePelak;
            }
            set
            {
                _VehiclePelak = value;
                OnPropertyChanged(nameof(VehiclePelak));
            }
        }
        private int _VehicleType;
        public int VehicleType
        {
            get
            {
                return _VehicleType;
            }
            set
            {
                _VehicleType = value;
                OnPropertyChanged(nameof(VehicleType));
            }
        }
        private string _VehicleYear;
        public string VehicleYear
        {
            get
            {
                return _VehicleYear;
            }
            set
            {
                _VehicleYear = value;
                OnPropertyChanged(nameof(VehicleYear));
            }
        }
        private string _ViolationID;
        public string ViolationID
        {
            get
            {
                return _ViolationID;
            }
            set
            {
                _ViolationID = value;
                OnPropertyChanged(nameof(ViolationID));
            }
        }
        private string _ViolationPelak;
        public string ViolationPelak
        {
            get
            {
                return _ViolationPelak;
            }
            set
            {
                _ViolationPelak = value;
                OnPropertyChanged(nameof(ViolationPelak));
            }
        }
        private int _ViolationType;
        public int ViolationType
        {
            get
            {
                return _ViolationType;
            }
            set
            {
                _ViolationType = value;
                OnPropertyChanged(nameof(ViolationType));
            }
        }
        private DateTime _ViolationTime;
        public DateTime ViolationTime
        {
            get
            {
                return _ViolationTime;
            }
            set
            {
                _ViolationTime = value;
                OnPropertyChanged(nameof(ViolationTime));
            }
        }
        private string _ViolationCost;
        public string ViolationCost
        {
            get
            {
                return _ViolationCost;
            }
            set
            {
                _ViolationCost = value;
                OnPropertyChanged(nameof(ViolationCost));
            }
        }
        private string _PersonsVehicleID;
        public string PersonsVehicleID
        {
            get
            {
                return _PersonsVehicleID;
            }
            set
            {
                _PersonsVehicleID = value;
                OnPropertyChanged(nameof(PersonsVehicleID));
            }
        }
        private string _PersonsVehiclePelak;
        public string PersonsVehiclePelak
        {
            get
            {
                return _PersonsVehiclePelak;
            }
            set
            {
                _PersonsVehiclePelak = value;
                OnPropertyChanged(nameof(PersonsVehiclePelak));
            }
        }


        public InsertionViewModel()
        {

        }
    }
}
