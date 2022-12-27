using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using TVIS.Services;

namespace TVIS.MVVM.Models
{
    public class TVISModel
    {
        private ViolationsBook ViolationsBook;
        private PersonsBook PersonsBook;
        private VehiclesBook VehiclesBook;
        private PersonsVehiclesBook PersonsVehiclesBook;
        private readonly Database database;

        public TVISModel(Database _Database)
        {
            database = _Database;
            LoadAll();
        }

        public void LoadAll()
        {
            PersonsBook = database.GetPersons();
            VehiclesBook = database.GetVehicles();
            ViolationsBook = database.GetViolations();
            PersonsVehiclesBook = database.GetPersonsVehicles();
        }
        public void LoadPersons()
        {
            PersonsBook = database.GetPersons();
        }
        public void LoadVehicles()
        {
            VehiclesBook = database.GetVehicles();
        }
        public void LoadViolations()
        {
            ViolationsBook = database.GetViolations();
        }
        public void LoadPersonsVehicles()
        {
            PersonsVehiclesBook = database.GetPersonsVehicles();
        }
        public Tuple<BitmapImage?,List<PersonsViolation>> GetPersonsViolations(string ID)
        {
            return database.GetPersonsViolations(ID);
        }
        public List<Violation> GetPersonsViolationsTime(string ID, DateTime StartDate, DateTime EndDate)
        {
            return database.GetPersonsViolationsTime(ID,StartDate,EndDate);
        }
        public List<VehiclesViolation> GetVehiclesViolationsTime(string Pelak)
        {
            return database.GetVehiclesViolationsTime(Pelak);
        }

        public void MakeViolation(Violation violation)
        {
            ViolationsBook.AddViolation(violation);
            database.InsertToViolations(violation);
        }
        public void DeleteViolation(string ID, string Pelak, DateTime Time)
        {
            ViolationsBook.DeleteViolation(ID, Pelak, Time);
            database.DeleteFromViolations(ID, Pelak, Time);
        }
        public void EditViolation(Violation Violation)
        {
            ViolationsBook.EditViolation(Violation);
            database.ModifyFromViolations(Violation);
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
            database.InsertToPersons(person);
        }
        public void DeletePersons(string ID)
        {
            PersonsBook.DeletePersons(ID);
            database.DeleteFromPersons(ID);
        }
        public void EditPersons(Person Person)
        {
            PersonsBook.EditPersons(Person);
            database.ModifyFromPersons(Person);
        }
        public IEnumerable<Person> GetPersons()
        {
            return PersonsBook.GetPersons();
        }
        
        public void MakeVehicle(Vehicle vehicle)
        {
            VehiclesBook.AddVehicles(vehicle);
            database.InsertToVehicles(vehicle);
        }
        public void DeleteVehicles(string Pelak)
        {
            VehiclesBook.DeleteVehicles(Pelak);
            database.DeleteFromVehicles(Pelak);
        }
        public void EditVehicles(Vehicle vehicle)
        {
            VehiclesBook.EditVehicles(vehicle);
            database.ModifyFromVehicles(vehicle);
        }
        public IEnumerable<Vehicle> GetVehicles()
        {
            return VehiclesBook.GetVehicles();
        }
        
        public void MakePersonsVehicle(PersonsVehicle personsVehicle)
        {
            PersonsVehiclesBook.AddPersonsVehicles(personsVehicle);
            database.InsertToPersonsVehicles(personsVehicle);
        }
        public void DeletePersonsVehicles(string ID, string Pelak)
        {
            PersonsVehiclesBook.DeletePersonsVehicles(ID, Pelak);
            database.DeleteFromPersonsVehicles(ID, Pelak);
        }
        public void EditPersonsVehicles(PersonsVehicle personsVehicle)
        {
            PersonsVehiclesBook.EditPersonsVehicles(personsVehicle);
            database.ModifyFromPersonsVehicle(personsVehicle);
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
