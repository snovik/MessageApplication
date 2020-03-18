using System;

namespace MessageApplication.Web.Exceptions
{
    [Serializable]
    public class BadRequestException : Exception
    {
        public BadRequestException(int code, string message)
            : base(message)
        {
            Code = code;
        }

        public int Code { get; private set; }

        public BadRequestException()
        {
        }

        public BadRequestException(string message) : base(message)
        {
        }

        public BadRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
