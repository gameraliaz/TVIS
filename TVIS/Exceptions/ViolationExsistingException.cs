using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TVIS.MVVM.Models;

namespace TVIS.Exceptions
{
    public class ViolationExsistingException : Exception
    {
        public Violation ExistingViolation { get; }
        public Violation IncomingViolation { get; }
        public ViolationExsistingException(Violation existingViolation, Violation incomingViolation)
        {
            ExistingViolation = existingViolation;
            IncomingViolation = incomingViolation;
        }

        public ViolationExsistingException(string? message, Violation existingViolation, Violation incomingViolation) : base(message)
        {
            ExistingViolation = existingViolation;
            IncomingViolation = incomingViolation;
        }

        public ViolationExsistingException(string? message, Exception? innerException, Violation existingViolation, Violation incomingViolation) : base(message, innerException)
        {
            ExistingViolation = existingViolation;
            IncomingViolation = incomingViolation;
        }

        protected ViolationExsistingException(SerializationInfo info, StreamingContext context, Violation existingViolation, Violation incomingViolation) : base(info, context)
        {
            ExistingViolation = existingViolation;
            IncomingViolation = incomingViolation;
        }
    }
}
