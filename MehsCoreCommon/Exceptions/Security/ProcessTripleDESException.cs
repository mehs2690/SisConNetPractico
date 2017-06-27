using log4net;
using System;
using System.Runtime.Serialization;

namespace MehsCoreCommon.Exceptions.Security
{
    public class ProcessTripleDESException : Exception
    {
        public ProcessTripleDESException() : base()
        {

        }

        public ProcessTripleDESException(string message) : base(message)
        {

        }

        public ProcessTripleDESException(string message, Exception inner) : base(message, inner)
        {

        }

        public ProcessTripleDESException(string message, Exception inner, ILog log) : base(message, inner)
        {
            log.Error(message, inner);
        }

        protected ProcessTripleDESException(SerializationInfo info, StreamingContext context)
        {

        }
    }
}
