using Newtonsoft.Json;

namespace RiotSharp.Models
{
    public class ClientErrors
    {
        [JsonProperty("code")]
        public int? Code;

        [JsonProperty("from")]
        public string From;

        [JsonProperty("id")]
        public int? Id;

        [JsonProperty("message")]
        public string Message;

        [JsonProperty("text")]
        public string Text;
    }
}
