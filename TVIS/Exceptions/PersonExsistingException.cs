using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TVIS.MVVM.Model;

namespace TVIS.Exceptions
{
    public class PersonExsistingException:Exception
    {
        public Person ExistingPerson { get; }
        public Person IncomingPerson { get; }
        public PersonExsistingException(Person existingPerson, Person incomingPerson)
        {
            ExistingPerson = existingPerson;
            IncomingPerson = incomingPerson;
        }

        public PersonExsistingException(string? message, Person existingPerson, Person incomingPerson) : base(message)
        {
            ExistingPerson = existingPerson;
            IncomingPerson = incomingPerson;
        }

        public PersonExsistingException(string? message, Exception? innerException, Person existingPerson, Person incomingPerson) : base(message, innerException)
        {
            ExistingPerson = existingPerson;
            IncomingPerson = incomingPerson;
        }

        protected PersonExsistingException(SerializationInfo info, StreamingContext context, Person existingPerson, Person incomingPerson) : base(info, context)
        {
            ExistingPerson = existingPerson;
            IncomingPerson = incomingPerson;
        }

    }
}
