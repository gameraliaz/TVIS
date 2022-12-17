using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVIS.Exceptions;
using TVIS.MVVM.Model;

namespace TVIS.MVVM.Models
{
    public class PersonsVehiclesBook
    {
        private readonly List<PersonsVehicle> PersonsVehicles;

        public PersonsVehiclesBook()
        {
            PersonsVehicles = new();
        }
        public void AddPersonsVehicles(PersonsVehicle PersonsVehicle)
        {
            foreach (PersonsVehicle p in PersonsVehicles)
            {
                if (p.Equals(PersonsVehicle))
                    throw new PersonsVehicleExsistingException(p, PersonsVehicle);
            }
            PersonsVehicles.Add(PersonsVehicle);
        }

        public IEnumerable<PersonsVehicle> GetPersonsVehicles()
        {
            return PersonsVehicles;
        }
        public IEnumerable<PersonsVehicle> GetPersonsVehiclesForPerson(Person Person)
        {
            return PersonsVehicles.Where(pv=>pv.Person.Equals(Person));
        }
        public IEnumerable<PersonsVehicle> GetPersonsVehiclesForVehicle(Vehicle Vehicle)
        {
            return PersonsVehicles.Where(pv => pv.Vehicle.Equals(Vehicle));
        }
    }
}
