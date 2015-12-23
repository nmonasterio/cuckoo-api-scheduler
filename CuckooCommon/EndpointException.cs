using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuckooCommon
{
    public class EndpointException : Exception
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public EndpointException(int statusCode, string message)
            : base(message)
        {
            this.StatusCode = statusCode;
            this.Message = message;
        }
    }
}
