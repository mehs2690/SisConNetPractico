using log4net;
using System;
using System.Runtime.Serialization;

namespace MehsCoreCommon.Exceptions.Security
{
    public class GenerateTokenException : Exception
    {
        public GenerateTokenException() : base()
        {

        }

        public GenerateTokenException(string message) : base(message)
        {

        }

        public GenerateTokenException(string message, Exception inner) : base(message, inner)
        {

        }

        public GenerateTokenException(string message, Exception inner, ILog log) : base(message, inner)
        {
            log.Error(message, inner);
        }

        protected GenerateTokenException(SerializationInfo info, StreamingContext context)
        {

        }
    }
}
