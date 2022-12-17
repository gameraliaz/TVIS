using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVIS.MVVM.Model;

namespace TVIS.MVVM.Models
{
    public class ViolationsBook
    {
        private readonly List<Violation> Violations;

        public ViolationsBook()
        {
            Violations = new();
        }
        public void AddViolation(Violation violation)
        {
            Violations.Add(violation);
        }

        public IEnumerable<Violation> GetViolationsForPerson(Person Person)
        {
            return Violations.Where(v => v.Person.Equals(Person));
        }
        public IEnumerable<Violation> GetViolationsForVehicle(Vehicle Vehicle)
        {
            return Violations.Where(v => v.Vehicle.Equals(Vehicle));
        }
        public IEnumerable<Violation> GetViolationsForVehicle(DateTime ViolationDateTime)
        {
            return Violations.Where(v => v.ViolationDateTime.Equals(ViolationDateTime));
        }
        public IEnumerable<Violation> GetViolationsForPersonVehicle(Person Person, Vehicle Vehicle)
        {
            return Violations.Where(v => v.Person.Equals(Person) && v.Vehicle.Equals(Vehicle));
        }
    }
}
