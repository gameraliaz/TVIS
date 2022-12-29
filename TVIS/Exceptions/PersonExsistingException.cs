using System;
using System.Runtime.Serialization;
using TVIS.MVVM.Models;

namespace TVIS.Exceptions
{
    public class PersonExsistingException : Exception
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
