using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using TVIS.Commands;
using TVIS.MVVM.Models;
using TVIS.Services;

namespace TVIS.MVVM.ViewModels
{
    public class DashboardViewModel : ViewModelBase
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
        private DateTime _StartDate=new(2022,1,1);
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
        private DateTime _EndDate=new(2022,12,29);
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
        private IEnumerable<TableViewModel> table;

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
        //private readonly ObservableCollection<TableViewModel> _Table;
        public IEnumerable<TableViewModel> Table { 
            get 
            {
                return table;
            }
            set 
            {
                table = value;
                OnPropertyChanged(nameof(Table));
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
        private readonly ObservableCollection<PersonsViolationViewModel> _PersonsViolations;
        public IEnumerable<PersonsViolationViewModel> PersonsViolations => _PersonsViolations;
        private readonly ObservableCollection<ViolationViewModel> _PersonsTimeViolations;
        public IEnumerable<ViolationViewModel> PersonsTimeViolations => _PersonsTimeViolations;
        private readonly ObservableCollection<VehiclesViolationViewModel> _VehiclesViolations;
        private readonly TVISModel tvis;
        public IEnumerable<VehiclesViolationViewModel> VehiclesViolations => _VehiclesViolations;
        public ICommand ShowPersons { get; }
        public ICommand ShowVehicles { get; }
        public ICommand ShowViolations { get; }
        public ICommand ShowPersonsVehicles { get; }
        public ICommand ShowPersonViolations { get; }
        public ICommand ShowPersonViolationsDate { get; }
        public ICommand ShowVehicleViolations { get; }


        public DashboardViewModel(TVISModel tvis)
        {
            _Persons = new();
            _Vehicles = new();
            _Violations = new();
            _PersonsVehicles = new();
            _PersonsViolations= new();
            _PersonsTimeViolations= new();
            _VehiclesViolations=new();

            Table = Persons;

            ShowPersons = new ShowPersonsCommand(this);
            ShowVehicles = new ShowVehiclesCommand(this);
            ShowViolations = new ShowViolationsCommand(this);
            ShowPersonsVehicles = new ShowPersonsVehiclesCommand(this);

            ShowPersonViolations= new ShowPersonViolationsCommand(this);
            ShowPersonViolationsDate=new ShowPersonViolationsDateCommand(this);
            ShowVehicleViolations=new ShowVehicleViolationsCommand(this);

            this.tvis = tvis;
            UpdateView();
        }

        private void UpdateView()
        {
            _Persons.Clear();
            _Vehicles.Clear();
            _Violations.Clear();
            _PersonsVehicles.Clear();
            _PersonsTimeViolations.Clear();
            _PersonsViolations.Clear();
            _VehiclesViolations.Clear();

            foreach(var a in tvis.GetPersons())
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
