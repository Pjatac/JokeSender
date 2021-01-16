using System;
using System.Runtime.Serialization;

namespace JokeSender.Domain.EmailSender
{
    public class EmailSendFailedException : Exception
    {
        public EmailSendFailedException()
        {
        }

        public EmailSendFailedException(string message) : base(message)
        {
        }

        public EmailSendFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmailSendFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
