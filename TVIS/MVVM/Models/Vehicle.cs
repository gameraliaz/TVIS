using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TVIS.MVVM.View;

namespace TVIS.MVVM.Model
{
    public enum VehiclesType
    {
        Car = 1,
        Truck = 2,
        Motorcycle = 3
    }
    public class Vehicle
    {
        public string Pelak { get; }
        public VehiclesType? TypeOfVehicle { get; set; }
        int? yearOfConstruction;
        public int? YearOfConstruction
        {
            get
            {
                return yearOfConstruction;
            }
            set
            {
                int MIN = 1350;
                int MAX = DateTime.Now.Year;
                if ((MIN > value || value > MAX ) && value is not null)
                {
                    var message = string.Format("Year must be between {0} and {1}.", MIN, MAX);
                    throw new ArgumentOutOfRangeException("year", value, message);
                }
                yearOfConstruction = value;
            }
        }
        public Vehicle(string Pelak)
        {
            if (!Regex.IsMatch(Pelak, "[1-9][0-9][a-zA-Z][0-9]{3}[-_\\s:|.,;]?[1-9][0-9]"))
            {
                var message = string.Format("Pelak({0}) is not valid.", Pelak);
                throw new ArgumentException(message, nameof(this.Pelak));
            }
            this.Pelak = Pelak;
        }

        public override string ToString()
        {
            return $"{Pelak},{TypeOfVehicle},{yearOfConstruction}";
        }
        public override bool Equals(object? obj)
        {
            return obj is Vehicle vehicle &&
                   Pelak == vehicle.Pelak;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Pelak);
        }
    }
}
