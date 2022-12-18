using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVIS.MVVM.Models
{
    public class PersonsVehicle
    {
        public Person Person { get; }
        public Vehicle Vehicle { get; }

        public PersonsVehicle(Person Person, Vehicle Vehicle)
        {
            this.Person = Person;
            this.Vehicle = Vehicle;
        }

        public override bool Equals(object? obj)
        {
            return obj is PersonsVehicle vehicle &&
                   EqualityComparer<Person>.Default.Equals(Person, vehicle.Person) &&
                   EqualityComparer<Vehicle>.Default.Equals(Vehicle, vehicle.Vehicle);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Person, Vehicle);
        }

        public override string? ToString()
        {
            return $"{Person},{Vehicle}";
        }
    }
}
