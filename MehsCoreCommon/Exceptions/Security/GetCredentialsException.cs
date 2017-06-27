using log4net;
using System;
using System.Runtime.Serialization;

namespace MehsCoreCommon.Exceptions.Security
{
    public class GetCredentialsException:Exception
    {
        public GetCredentialsException() : base()
        {

        }

        public GetCredentialsException(string message) : base(message)
        {

        }

        public GetCredentialsException(string message,Exception inner) : base(message, inner)
        {

        }

        public GetCredentialsException(string message,Exception inner,ILog log) : base(message, inner)
        {
            log.Error(message, inner);
        }

        protected GetCredentialsException(SerializationInfo info,StreamingContext context)
        {

        }
    }
}
