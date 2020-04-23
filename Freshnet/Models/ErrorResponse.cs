using System;
using System.Collections.Generic;

namespace Freshnet.Models
{
    public class ErrorResponse 
    {
        private List<Error> Errors { get; set; }

        public void AppendError(Exception exception, int status)
        {
            Errors.Add(new Error(exception.Message, status));
        }
        
        public void AppendError(string message, int status)
        {
            Errors.Add(new Error(message, status));
        }
    }

    public class Error
    {
        public Error(string message, int status)
        {
            Message = message;
            Timestamp = DateTime.Now;
            Status = status;
        }

        private string Message { get; set; }
        private int Status { get; set; }
        private DateTime Timestamp { get; set; }
    }
}