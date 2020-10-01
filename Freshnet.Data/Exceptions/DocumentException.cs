using System;

namespace Freshnet.Data.Exceptions
{
    public class DocumentException : Exception
    {
        public DocumentException()
        {
        }

        public DocumentException(string? message) : base(message)
        {
        }

        public DocumentException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}