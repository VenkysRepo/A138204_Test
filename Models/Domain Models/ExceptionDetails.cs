using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Models.Domain_Models
{
    public class ExceptionDetails
    {
        public string message { get; set; }

        public HttpStatusCode Status { get; set; }
    }
}
