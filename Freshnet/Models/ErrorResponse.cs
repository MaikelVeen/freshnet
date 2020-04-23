using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Freshnet.Models
{
    public class ErrorResponse 
    {
        public ErrorResponse()
        {
            Errors = new List<Error>();
        }

        public ErrorResponse(ModelStateDictionary modelStateDictionary) : this()
        {
            foreach (ModelError entryError in modelStateDictionary.Values.SelectMany(entry => entry.Errors))
            {
                AppendError(entryError.ErrorMessage, 400);
            }
        }
 
        public List<Error> Errors { get; set; }

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

        public string Message { get; set; }
        public int Status { get; set; }
        public DateTime Timestamp { get; set; }
    }
}