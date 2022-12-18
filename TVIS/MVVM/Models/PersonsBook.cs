using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public IEnumerable<Person> GetPersons()
        {
            return Persons;
        }
    }
}
