using System.Collections.Generic;
using System.Linq;
using TVIS.Exceptions;

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
        public void DeletePersonsVehicles(string ID,string Pelak)
        {
            PersonsVehicle prsnvhicl=new(new(ID),new(Pelak));
            foreach (PersonsVehicle p in PersonsVehicles)
            {
                if (p.Equals(prsnvhicl))
                {
                    PersonsVehicles.Remove(p);
                    break;
                }
            }
        }
        public void EditPersonsVehicles(PersonsVehicle personsVehicle)
        {
            PersonsVehicles.Remove(PersonsVehicles.ElementAt(PersonsVehicles.IndexOf(personsVehicle)));
            AddPersonsVehicles(personsVehicle);
        }


        public IEnumerable<PersonsVehicle> GetPersonsVehicles()
        {
            return PersonsVehicles;
        }
        public IEnumerable<PersonsVehicle> GetPersonsVehiclesForPerson(Person Person)
        {
            return PersonsVehicles.Where(pv => pv.Person.Equals(Person));
        }
        public IEnumerable<PersonsVehicle> GetPersonsVehiclesForVehicle(Vehicle Vehicle)
        {
            return PersonsVehicles.Where(pv => pv.Vehicle.Equals(Vehicle));
        }
    }
}
