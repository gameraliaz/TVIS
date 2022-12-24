using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using TVIS.MVVM.Models;

namespace TVIS.MVVM.ViewModels
{
    public class DashboardViewModel:ViewModelBase
    {
        private int _SumOfCost;
        public string SumOfCost
        {
            get
            {
                return _SumOfCost.ToString();
            }
            set
            {
                _SumOfCost = Convert.ToInt32(value);
                OnPropertyChanged(nameof(SumOfCost));
            }
        }
        private int _CountOfPersons;
		public string CountOfPersons
		{
			get
			{
				return _CountOfPersons.ToString();
			}
			set
			{
				_CountOfPersons = Convert.ToInt32(value);
				OnPropertyChanged(nameof(CountOfPersons));
			}
		}
		private int _CountOfVehicles;
		public string CountOfVehicles
		{
			get
			{
				return _CountOfVehicles.ToString(); 
			}
			set
			{
				_CountOfVehicles = Convert.ToInt32(value);
                OnPropertyChanged(nameof(CountOfVehicles));
			}
		}
		private int _CountOfViolations;
		public string CountOfViolations
		{
			get
			{
				return _CountOfViolations.ToString(); ;
			}
			set
			{
				_CountOfViolations = Convert.ToInt32(value);
                OnPropertyChanged(nameof(CountOfViolations));
			}
		}
		private int _CountOfPersonsVehicles;
		public string CountOfPersonsVehicles
		{
			get
			{
				return _CountOfPersonsVehicles.ToString();
			}
			set
			{
				_CountOfPersonsVehicles = Convert.ToInt32(value);
                OnPropertyChanged(nameof(CountOfPersonsVehicles));
			}
		}
        private string _PVID;
        public string PVID
        {
            get
            {
                return _PVID;
            }
            set
            {
                _PVID = value;
                OnPropertyChanged(nameof(PVID));
            }
        }
        private string _VVPelak;
        public string VVPelak
        {
            get
            {
                return _VVPelak;
            }
            set
            {
                _VVPelak = value;
                OnPropertyChanged(nameof(VVPelak));
            }
        }
        private string _PVDID;
        public string PVDID
        {
            get
            {
                return _PVDID;
            }
            set
            {
                _PVDID = value;
                OnPropertyChanged(nameof(PVDID));
            }
        }
        private BitmapSource _imgVVPelak;
        public BitmapSource imgVVPelak
        {
            get
            {
                return _imgVVPelak;
            }
            set
            {
                _imgVVPelak = value;
                OnPropertyChanged(nameof(imgVVPelak));
            }
        }
        private DateTime _StartDate;
        public DateTime StartDate
        {
            get
            {
                return _StartDate;
            }
            set
            {
                _StartDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }
        private DateTime _EndDate;
        public DateTime EndDate
        {
            get
            {
                return _EndDate;
            }
            set
            {
                _EndDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }
        private string _SelectedTableName;
        public string SelectedTableName
        {
            get
            {
                return _SelectedTableName;
            }
            set
            {
                _SelectedTableName = value;
                OnPropertyChanged(nameof(SelectedTableName));
            }
        }
        private readonly ObservableCollection<PersonViewModel> _Persons;
		public IEnumerable<PersonViewModel> Persons => _Persons;
        private readonly ObservableCollection<VehicleViewModel> _Vehicles;
        public IEnumerable<VehicleViewModel> Vehicles => _Vehicles;
        private readonly ObservableCollection<ViolationViewModel> _Violations;
        public IEnumerable<ViolationViewModel> Violations => _Violations;
        private readonly ObservableCollection<PersonsVehicleViewModel> _PersonsVehicles;
        public IEnumerable<PersonsVehicleViewModel> PersonsVehicles => _PersonsVehicles;
        public ICommand ShowPersons { get; }
		public ICommand ShowVehicles { get; }
		public ICommand ShowViolations { get; }
		public ICommand ShowPersonsVehicle { get; }
		public ICommand ShowPersonViolations { get; }
		public ICommand ShowPersonViolationsDate { get; }
		public ICommand ShowVehicleViolations { get; }


        public DashboardViewModel()
        {
            _Persons = new()
            {
                new PersonViewModel(new Person("1130570010") { FirstName = "Ali", LastName = "Soleymani" }),
                new PersonViewModel(new Person("1130570011") { FirstName = "mmd", LastName = "jafari" }),
                new PersonViewModel(new Person("1130570012") { FirstName = "taghi", LastName = "saleehi" }),
                new PersonViewModel(new Person("1130570013") { FirstName = "jafar", LastName = "lotfi" }),
                new PersonViewModel(new Person("1130570014") { FirstName = "sadegh", LastName = "shams" }),
        };
            
            _Vehicles = new();
            _Violations = new();
            _PersonsVehicles = new();
        }
    }
}
