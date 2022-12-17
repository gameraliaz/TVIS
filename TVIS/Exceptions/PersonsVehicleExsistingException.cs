using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TVIS.MVVM.Models;

namespace TVIS.Exceptions
{
    public class PersonsVehicleExsistingException:Exception
    {
        public PersonsVehicle ExistingPersonsVehicle { get; }
        public PersonsVehicle IncomingPersonsVehicle { get; }
        public PersonsVehicleExsistingException(PersonsVehicle existingPersonsVehicle, PersonsVehicle incomingPersonsVehicle)
        {
            ExistingPersonsVehicle = existingPersonsVehicle;
            IncomingPersonsVehicle = incomingPersonsVehicle;
        }

        public PersonsVehicleExsistingException(string? message, PersonsVehicle existingPersonsVehicle, PersonsVehicle incomingPersonsVehicle) : base(message)
        {
            ExistingPersonsVehicle = existingPersonsVehicle;
            IncomingPersonsVehicle = incomingPersonsVehicle;
        }

        public PersonsVehicleExsistingException(string? message, Exception? innerException, PersonsVehicle existingPersonsVehicle, PersonsVehicle incomingPersonsVehicle) : base(message, innerException)
        {
            ExistingPersonsVehicle = existingPersonsVehicle;
            IncomingPersonsVehicle = incomingPersonsVehicle;
        }

        protected PersonsVehicleExsistingException(SerializationInfo info, StreamingContext context, PersonsVehicle existingPersonsVehicle, PersonsVehicle incomingPersonsVehicle) : base(info, context)
        {
            ExistingPersonsVehicle = existingPersonsVehicle;
            IncomingPersonsVehicle = incomingPersonsVehicle;
        }

    }
}
