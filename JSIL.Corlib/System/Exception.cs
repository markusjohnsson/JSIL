
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
    [Serializable]
    public class Exception : _Exception
    {
        public Exception(): this(string.Empty)
        {
        }

        public Exception(string message)
        {
            Message = message;
        }

        public Exception(string message, Exception innerException)
        {
            Message = message;
            InnerException = innerException;
        }

        protected int HResult { get; set; }

        public string HelpLink
        {
            get;
            set;
        }

        public Exception InnerException
        {
            get;
            protected set;
        }

        public virtual string Message
        {
            get;
            protected set;
        }

        public string Source
        {
            get;
            set;
        }

        public string StackTrace
        {
            get;
            protected set;
        }

        public Exception GetBaseException()
        {
            throw new global::System.NotImplementedException();
        }

        public int GetHashCode()
        {
            throw new global::System.NotImplementedException();
        }
    }
}