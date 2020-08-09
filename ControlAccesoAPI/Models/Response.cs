using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlAccesoAPI.Models
{
    public class Response
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }

        public object Data { get; set; }

        public Response()
        {
            this.IsSuccessful = false;
        }
    }
}
