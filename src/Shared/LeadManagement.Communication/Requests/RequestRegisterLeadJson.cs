using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeadManagement.Communication.Requests
{
    public class RequestRegisterLeadJson
    {
        public string ContactFirstName { get; set; } = string.Empty;
        public string ContactFullName { get; set; } = string.Empty;
        public string ContactPhoneNumber { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;

    }
}
