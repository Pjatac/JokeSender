using System;
using System.Runtime.Serialization;

namespace JokeSender.Domain
{
    public class BusinessProcessFailedException : Exception
    {
        public BusinessProcessFailedException()
        {
        }

        public BusinessProcessFailedException(string message) : base(message)
        {
        }

        public BusinessProcessFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BusinessProcessFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
