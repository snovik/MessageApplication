using System;

namespace MessageApplication.Web.Exceptions
{
    [Serializable]
    public class InternalSmsServiceException : Exception
    {
        public InternalSmsServiceException(int code, string message)
            : base(message)
        {
            Code = code;
        }

        public int Code { get; private set; }

        public InternalSmsServiceException()
        {
        }

        public InternalSmsServiceException(string message) : base(message)
        {
        }

        public InternalSmsServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
