using log4net;
using System;
using System.Runtime.Serialization;

namespace MehsCoreCommon.Exceptions.Security
{
    public class ProcessMD5Exception : Exception
    {
        public ProcessMD5Exception() : base()
        {

        }

        public ProcessMD5Exception(string message) : base(message)
        {

        }

        public ProcessMD5Exception(string message, Exception inner) : base(message, inner)
        {

        }

        public ProcessMD5Exception(string message, Exception inner, ILog log) : base(message, inner)
        {
            log.Error(message, inner);
        }

        protected ProcessMD5Exception(SerializationInfo info, StreamingContext context)
        {

        }
    }
}
