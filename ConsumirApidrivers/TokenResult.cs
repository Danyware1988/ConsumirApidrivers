using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumirApidrivers
{
    public class TokenResult
    {
        [JsonProperty("statusCOde")]
        public String StatusCode { get; set; }

        [JsonProperty("token")]
        public String Token { get; set; }
    }
}