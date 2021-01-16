using System;
using System.Runtime.Serialization;

namespace JokeSender.Domain.EmailValidation
{
    public class EmailValidationFailedException : Exception
    {
        public EmailValidationFailedException()
        {
        }

        public EmailValidationFailedException(string message) : base(message)
        {
        }

        public EmailValidationFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmailValidationFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
