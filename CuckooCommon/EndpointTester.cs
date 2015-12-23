using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuckooCommon
{
    public class EndpointTester
    {
        public bool WasSuccess { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public EndpointTester(bool success, int statusCode)
        {
            this.WasSuccess = success;
            this.StatusCode = statusCode;
        }

        public EndpointTester(bool success, int statusCode, string message)
        {
            this.WasSuccess = success;
            this.StatusCode = statusCode;
            this.Message = message;
        }

    }

}
