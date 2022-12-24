﻿using System;
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
        public IEnumerable<Person> GetPersons()
        {
            return PersonsBook.GetPersons();
        }
        public void MakeVehicle(Vehicle vehicle)
        {
            VehiclesBook.AddVehicles(vehicle);
        }
        public IEnumerable<Vehicle> GetVehicles()
        {
            return VehiclesBook.GetVehicles();
        }
        public void MakePersonsVehicle(PersonsVehicle personsVehicle)
        {
            PersonsVehiclesBook.AddPersonsVehicles(personsVehicle);
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
