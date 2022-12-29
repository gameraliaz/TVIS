using System.Collections.Generic;
using System.Linq;
using TVIS.Exceptions;

namespace TVIS.MVVM.Models
{
    public class VehiclesBook
    {
        private readonly List<Vehicle> Vehicles;

        public VehiclesBook()
        {
            Vehicles = new();
        }
        public void AddVehicles(Vehicle Vehicle)
        {
            foreach (Vehicle p in Vehicles)
            {
                if (p.Equals(Vehicle))
                    throw new VehicleExsistingException(p, Vehicle);
            }
            Vehicles.Add(Vehicle);
        }
        public void DeleteVehicles(string Pelak)
        {
            Vehicle vhcl = new(Pelak);
            foreach (Vehicle p in Vehicles)
            {
                if (p.Equals(vhcl))
                {
                    Vehicles.Remove(p);
                    break;
                }
            }
        }
        public void EditVehicles(Vehicle vehicle)
        {
            Vehicles.Remove(Vehicles.ElementAt(Vehicles.IndexOf(vehicle)));
            AddVehicles(vehicle);
        }

        public IEnumerable<Vehicle> GetVehicles()
        {
            return Vehicles;
        }
    }
}
