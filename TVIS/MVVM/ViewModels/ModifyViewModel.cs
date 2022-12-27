using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using TVIS.Commands;
using TVIS.MVVM.Models;

namespace TVIS.MVVM.ViewModels
{
    public class ModifyViewModel:ViewModelBase
    {
        public ICommand EditPerson { get; }
        public ICommand EditVehicle { get; }
        public ICommand EditViolation { get; }
        public ICommand EditPersonsVehicle { get; }
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
                try
                {
                    foreach (var v in tvis.GetPersons())
                    {
                        if (v.ID == _PersonID)
                        {
                            PersonFirstName = v.FirstName;
                            PersonLastName = v.LastName;
                            PersonImage = v.Image;
                            break;
                        }
                    }
                    OnPropertyChanged(nameof(PersonID));
                }catch
                {

                }
            }
        }
        private string? _PersonFirstName;
        public string? PersonFirstName
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
        private string? _PersonLastName;
        public string? PersonLastName
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
        private BitmapImage? _PersonImage;
        public BitmapImage? PersonImage
        {
            get
            {
                return _PersonImage;
            }
            set
            {
                _PersonImage = value;
                OnPropertyChanged(nameof(PersonImage));
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
                try
                {
                    foreach (var v in tvis.GetVehicles())
                    {
                        if (v.Pelak == _VehiclePelak)
                        {
                            VehicleType = (int)v.TypeOfVehicle.Value;
                            VehicleYear = v.YearOfConstruction.ToString();
                            break;
                        }
                    }
                    OnPropertyChanged(nameof(VehiclePelak));
                }
                catch { }
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
        private string? _VehicleYear;
        public string? VehicleYear
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
                try
                {
                    if (!string.IsNullOrEmpty(_ViolationID) && !string.IsNullOrEmpty(_ViolationPelak))
                    {
                        foreach (var v in tvis.GetViolations())
                        {
                            if (v.Person.ID == _ViolationID && v.Vehicle.Pelak == _ViolationPelak && v.ViolationDateTime == _ViolationTime)
                            {
                                ViolationType = (int)v.TypeOfViolation.Value;
                                ViolationCost = v.Cost.ToString();
                                break;
                            }
                        }
                    }
                    OnPropertyChanged(nameof(ViolationID));
                }
                catch { }
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
                try
                {
                    if (!string.IsNullOrEmpty(_ViolationID) && !string.IsNullOrEmpty(_ViolationPelak))
                    {
                        foreach (var v in tvis.GetViolations())
                        {
                            if (v.Person.ID == _ViolationID && v.Vehicle.Pelak == _ViolationPelak && v.ViolationDateTime == _ViolationTime)
                            {
                                ViolationType = (int)v.TypeOfViolation.Value;
                                ViolationCost = v.Cost.ToString();
                                break;
                            }
                        }
                    }
                    OnPropertyChanged(nameof(ViolationPelak));
                }
                catch { }
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
        private DateTime _ViolationTime = DateTime.Now;
        public DateTime ViolationTime
        {
            get
            {
                return _ViolationTime;
            }
            set
            {
                _ViolationTime = value;
                try
                {
                    if (!string.IsNullOrEmpty(_ViolationID) && !string.IsNullOrEmpty(_ViolationPelak))
                    {
                        foreach (var v in tvis.GetViolations())
                        {
                            if (v.Person.ID == _ViolationID && v.Vehicle.Pelak == _ViolationPelak && v.ViolationDateTime == _ViolationTime)
                            {
                                ViolationType = (int)v.TypeOfViolation.Value;
                                ViolationCost = v.Cost.ToString();
                                break;
                            }
                        }
                    }
                    OnPropertyChanged(nameof(ViolationTime));
                }
                catch { }
            }
        }
        private string? _ViolationCost;
        public string? ViolationCost
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

        private readonly TVISModel tvis;
        public ModifyViewModel(TVISModel tvis)
        {
            this.tvis = tvis;
            SelectImg = new SelectImgModifyCommand(this);
            EditPerson = new EditPersonCommand(this, tvis);
            EditVehicle = new EditVehicleCommand(this, tvis);
            EditViolation = new EditViolationCommand(this, tvis);
            EditPersonsVehicle = new EditPersonsVehicleCommand();
        }

    }
}
