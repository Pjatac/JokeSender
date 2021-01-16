using System;
using System.Runtime.Serialization;

namespace JokeSender.Domain.JokeGenerator
{
    public class JokeGenerationFailedException : Exception
    {
        public JokeGenerationFailedException()
        {
        }

        public JokeGenerationFailedException(string message) : base(message)
        {
        }

        public JokeGenerationFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected JokeGenerationFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
