using System;
using System.Text.RegularExpressions;
namespace TVIS.MVVM.Models
{
    public enum VehiclesType
    {
        Undifiend = 0,
        Car = 1,
        Truck = 2,
        Motorcycle = 3
    }
    public class Vehicle
    {
        public string Pelak { get; }
        public VehiclesType? TypeOfVehicle { get; set; }
        short? yearOfConstruction;
        public short? YearOfConstruction
        {
            get
            {
                return yearOfConstruction;
            }
            set
            {
                int MIN = 1350;
                int MAX = DateTime.Now.Year;
                if ((MIN > value || value > MAX) && value is not null)
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
            this.Pelak = Pelak.Substring(0, 6) + Pelak[..2];
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
