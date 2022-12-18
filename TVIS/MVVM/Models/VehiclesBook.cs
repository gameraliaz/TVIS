using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public IEnumerable<Vehicle> GetVehicles()
        {
            return Vehicles;
        }
    }
}
