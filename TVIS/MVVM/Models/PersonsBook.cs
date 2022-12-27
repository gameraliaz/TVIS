using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TVIS.Exceptions;

namespace TVIS.MVVM.Models
{
    public class PersonsBook
    {
        private readonly List<Person> Persons;

        public PersonsBook()
        {
            Persons = new();
        }
        public void AddPersons(Person Person)
        {
            foreach (Person p in Persons)
            {
                if (p.Equals(Person))
                    throw new PersonExsistingException(p, Person);
            }
            Persons.Add(Person);
        }
        public void DeletePersons(string ID)
        {
            Person prsn = new(ID);
            foreach (Person p in Persons)
            {
                if (p.Equals(prsn))
                {
                    Persons.Remove(p);
                    break;
                }
            }
        }
        public void EditPersons(Person Person)
        {
            Persons.Remove(Persons.ElementAt(Persons.IndexOf(Person)));
            AddPersons(Person);
        }
        public IEnumerable<Person> GetPersons()
        {
            return Persons;
        }
        public IEnumerable<PersonsViolation> GetPersonsViolations(string ID)
        {
            return new List<PersonsViolation>();
        }
        public IEnumerable<PersonsViolation> GetPersonsViolationsTime(string ID,DateTime StartDate,DateTime EndDate)
        {
            return new List<PersonsViolation>();
        }
    }
}
