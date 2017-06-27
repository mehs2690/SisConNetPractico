using log4net;
using System;
using System.Runtime.Serialization;

namespace MehsCoreCommon.Exceptions.Security
{
    public class ValidateTokenException : Exception
    {
        public ValidateTokenException() : base()
        {

        }

        public ValidateTokenException(string message) : base(message)
        {

        }

        public ValidateTokenException(string message, Exception inner) : base(message, inner)
        {

        }

        public ValidateTokenException(string message, Exception inner, ILog log) : base(message, inner)
        {
            log.Error(message, inner);
        }

        protected ValidateTokenException(SerializationInfo info, StreamingContext context)
        {

        }
    }
}
