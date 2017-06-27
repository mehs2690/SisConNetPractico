using log4net;
using System;
using System.Runtime.Serialization;

namespace MehsCoreCommon.Exceptions.Security
{
    public class ProcessDESException : Exception
    {
        public ProcessDESException() : base()
        {

        }

        public ProcessDESException(string message) : base(message)
        {

        }

        public ProcessDESException(string message, Exception inner) : base(message, inner)
        {

        }

        public ProcessDESException(string message, Exception inner, ILog log) : base(message, inner)
        {
            log.Error(message, inner);
        }

        protected ProcessDESException(SerializationInfo info, StreamingContext context)
        {

        }
    }
}
