using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVIS.MVVM.Models
{
    public enum ViolationsType
    {
        overtaking = 1,
        Speed = 2,
        Belt = 3,
    }
    public class Violation
    {
        public Person Person { get; }
        public Vehicle Vehicle { get; }
        public DateTime ViolationDateTime { get; }
        public ViolationsType? TypeOfViolation { get; set; }
        public int? Cost { get; set; }
        public Violation(Person Person, Vehicle Vehicle, DateTime ViolationDateTime)
        {
            this.Person = Person;
            this.Vehicle = Vehicle;
            this.ViolationDateTime = ViolationDateTime;
        }

        public override bool Equals(object? obj)
        {
            return obj is Violation violation &&
                   EqualityComparer<Person>.Default.Equals(Person, violation.Person) &&
                   EqualityComparer<Vehicle>.Default.Equals(Vehicle, violation.Vehicle) &&
                   ViolationDateTime == violation.ViolationDateTime;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Person, Vehicle, ViolationDateTime);
        }

        public override string? ToString()
        {
            return $"{Person},{Vehicle},{ViolationDateTime}";
        }
    }
}
