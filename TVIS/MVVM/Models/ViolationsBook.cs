using System;
using System.Collections.Generic;
using System.Linq;
using TVIS.Exceptions;

namespace TVIS.MVVM.Models
{
    public class ViolationsBook
    {
        private readonly List<Violation> Violations;

        public ViolationsBook()
        {
            Violations = new();
        }
        public void AddViolation(Violation Violation)
        {
            foreach (Violation v in Violations)
            {
                if (v.Equals(Violation))
                    throw new ViolationExsistingException(v, Violation);
            }
            Violations.Add(Violation);
        }
        public void DeleteViolation(string ID,string Pelak,DateTime Time)
        {
            Violation viol=new(new(ID),new(Pelak),Time);
            foreach (Violation v in Violations)
            {
                if (v.Equals(viol))
                {
                    Violations.Remove(viol);
                    break;
                }
            }
        }
        public void EditViolation(Violation Violation)
        {
            Violations.Remove(Violations.ElementAt(Violations.IndexOf(Violation)));
            AddViolation(Violation);
        }

        public IEnumerable<Violation> GetViolations()
        {
            return Violations;
        }
        public IEnumerable<Violation> GetViolationsForPerson(Person Person)
        {
            return Violations.Where(v => v.Person.Equals(Person));
        }
        public IEnumerable<Violation> GetViolationsForVehicle(Vehicle Vehicle)
        {
            return Violations.Where(v => v.Vehicle.Equals(Vehicle));
        }
        public IEnumerable<Violation> GetViolationsForViolationDateTime(DateTime ViolationDateTime)
        {
            return Violations.Where(v => v.ViolationDateTime.Equals(ViolationDateTime));
        }
        public IEnumerable<Violation> GetViolationsForPersonVehicle(Person Person, Vehicle Vehicle)
        {
            return Violations.Where(v => v.Person.Equals(Person) && v.Vehicle.Equals(Vehicle));
        }
    }
}
