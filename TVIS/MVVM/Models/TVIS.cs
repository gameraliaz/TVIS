using System;
using System.Collections.Generic;

namespace TVIS.MVVM.Models
{
    public class TVISModel
    {
        private readonly ViolationsBook ViolationsBook;
        private readonly PersonsBook PersonsBook;
        private readonly VehiclesBook VehiclesBook;
        private readonly PersonsVehiclesBook PersonsVehiclesBook;
        public TVISModel()
        {
            ViolationsBook = new();
            PersonsBook = new();
            VehiclesBook = new();
            PersonsVehiclesBook = new();
        }

        public void MakeViolation(Violation violation)
        {
            ViolationsBook.AddViolation(violation);
        }
        public void DeleteViolation(string ID, string Pelak, DateTime Time)
        {
            ViolationsBook.DeleteViolation(ID, Pelak, Time);
        }

        public void EditViolation(Violation Violation)
        {
            ViolationsBook.EditViolation(Violation);
        }


        public IEnumerable<Violation> GetViolations()
        {
            return ViolationsBook.GetViolations();
        }
        public IEnumerable<Violation> GetViolationsForPerson(Person Person)
        {
            return ViolationsBook.GetViolationsForPerson(Person);
        }
        public IEnumerable<Violation> GetViolationsForVehicle(Vehicle Vehicle)
        {
            return ViolationsBook.GetViolationsForVehicle(Vehicle);
        }
        public IEnumerable<Violation> GetViolationsForViolationDateTime(DateTime ViolationDateTime)
        {
            return ViolationsBook.GetViolationsForViolationDateTime(ViolationDateTime);
        }
        public IEnumerable<Violation> GetViolationsForPersonVehicle(Person Person, Vehicle Vehicle)
        {
            return ViolationsBook.GetViolationsForPersonVehicle(Person, Vehicle);
        }
        public void MakePerson(Person person)
        {
            PersonsBook.AddPersons(person);
        }
        public void DeletePersons(string ID)
        {
            PersonsBook.DeletePersons(ID);
        }
        public void EditPersons(Person Person)
        {
            PersonsBook.EditPersons(Person);
        }
        public IEnumerable<Person> GetPersons()
        {
            return PersonsBook.GetPersons();
        }
        public void MakeVehicle(Vehicle vehicle)
        {
            VehiclesBook.AddVehicles(vehicle);
        }
        public void DeleteVehicles(string Pelak)
        {
            VehiclesBook.DeleteVehicles(Pelak);
        }
        public void EditVehicles(Vehicle vehicle)
        {
            VehiclesBook.EditVehicles(vehicle);
        }

        public IEnumerable<Vehicle> GetVehicles()
        {
            return VehiclesBook.GetVehicles();
        }
        public void MakePersonsVehicle(PersonsVehicle personsVehicle)
        {
            PersonsVehiclesBook.AddPersonsVehicles(personsVehicle);
        }
        public void DeletePersonsVehicles(string ID, string Pelak)
        {
            PersonsVehiclesBook.DeletePersonsVehicles(ID, Pelak);
        }
        public void EditPersonsVehicles(PersonsVehicle personsVehicle)
        {
            PersonsVehiclesBook.EditPersonsVehicles(personsVehicle);
        }
        public IEnumerable<PersonsVehicle> GetPersonsVehicles()
        {
            return PersonsVehiclesBook.GetPersonsVehicles();
        }
        public IEnumerable<PersonsVehicle> GetPersonsVehiclesForPerson(Person Person)
        {
            return PersonsVehiclesBook.GetPersonsVehiclesForPerson(Person);
        }
        public IEnumerable<PersonsVehicle> GetPersonsVehiclesForVehicle(Vehicle Vehicle)
        {
            return PersonsVehiclesBook.GetPersonsVehiclesForVehicle(Vehicle);
        }
    }
}
