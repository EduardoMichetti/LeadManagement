using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadManagement.Communication.Responses
{
    public class ResponseRegisteredLeadJson
    {
        public long Id { get; set; }
        public string ContactFirstName { get; set; } = string.Empty;
    }
}
