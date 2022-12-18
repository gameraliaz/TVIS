using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TVIS.MVVM.Models;

namespace TVIS.Exceptions
{
    public class VehicleExsistingException:Exception
    {
        public Vehicle ExistingVehicle { get; }
        public Vehicle IncomingVehicle { get; }
        public VehicleExsistingException(Vehicle existingVehicle, Vehicle incomingVehicle)
        {
            ExistingVehicle = existingVehicle;
            IncomingVehicle = incomingVehicle;
        }

        public VehicleExsistingException(string? message, Vehicle existingVehicle, Vehicle incomingVehicle) : base(message)
        {
            ExistingVehicle = existingVehicle;
            IncomingVehicle = incomingVehicle;
        }

        public VehicleExsistingException(string? message, Exception? innerException, Vehicle existingVehicle, Vehicle incomingVehicle) : base(message, innerException)
        {
            ExistingVehicle = existingVehicle;
            IncomingVehicle = incomingVehicle;
        }

        protected VehicleExsistingException(SerializationInfo info, StreamingContext context, Vehicle existingVehicle, Vehicle incomingVehicle) : base(info, context)
        {
            ExistingVehicle = existingVehicle;
            IncomingVehicle = incomingVehicle;
        }

    }
}
