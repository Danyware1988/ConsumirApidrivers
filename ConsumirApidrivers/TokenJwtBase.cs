using Newtonsoft.Json;


namespace AM.Integration.Clients.Core.RestClient.JwtService
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
