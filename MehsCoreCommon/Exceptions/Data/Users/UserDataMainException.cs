using log4net;
using System;
using System.Runtime.Serialization;

namespace MehsCoreCommon.Exceptions.Data.Users
{
    public class UserDataMainException : Exception
    {
        public UserDataMainException() : base()
        {

        }

        public UserDataMainException(string message) : base(message)
        {

        }

        public UserDataMainException(string message, Exception inner) : base(message, inner)
        {

        }

        public UserDataMainException(string message, Exception inner, ILog log) : base(message, inner)
        {
            log.Error(message, inner);
        }

        protected UserDataMainException(SerializationInfo info, StreamingContext context)
        {

        }
    }
}
