using log4net;
using System;
using System.Runtime.Serialization;

namespace MehsCoreCommon.Exceptions.Security
{
    public class GetHashPasswordException : Exception
    {
        public GetHashPasswordException() : base()
        {

        }

        public GetHashPasswordException(string message) : base(message)
        {

        }

        public GetHashPasswordException(string message, Exception inner) : base(message, inner)
        {

        }

        public GetHashPasswordException(string message, Exception inner, ILog log) : base(message, inner)
        {
            log.Error(message, inner);
        }

        protected GetHashPasswordException(SerializationInfo info, StreamingContext context)
        {

        }

    }
}
