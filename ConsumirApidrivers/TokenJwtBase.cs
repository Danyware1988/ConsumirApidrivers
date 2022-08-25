using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumirApidrivers
{
    public class TokenJwtBase<t>
    {
        [JsonProperty("endPoint")]
        public String EndPoint { get; set; }

        [JsonProperty("tokenBody")]
        public t TokenBody;

        public TokenJwtBase(String endPoint, t tokenBody)
        {
            this.EndPoint = endPoint;
            this.TokenBody = tokenBody;

        }
    }
}
