using Newtonsoft.Json;
using System;

namespace Consumir 
{
    public class TokenBody
    {
        [JsonProperty("usuario")]
        public String User { get; set; }

        [JsonProperty("contrasena")]
        public String Password { get; set; }

    }
}
