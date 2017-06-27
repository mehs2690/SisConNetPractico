using log4net;
using System;
using System.Runtime.Serialization;

namespace MehsCoreCommon.Exceptions.Security
{
    public class ProcessHexaDecimalException : Exception
    {
        public ProcessHexaDecimalException() : base()
        {

        }

        public ProcessHexaDecimalException(string message) : base(message)
        {

        }

        public ProcessHexaDecimalException(string message, Exception inner) : base(message, inner)
        {

        }

        public ProcessHexaDecimalException(string message, Exception inner, ILog log) : base(message, inner)
        {
            log.Error(message, inner);
        }

        protected ProcessHexaDecimalException(SerializationInfo info, StreamingContext context)
        {

        }
    }
}
