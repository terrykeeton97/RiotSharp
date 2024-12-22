using Newtonsoft.Json;

namespace RiotSharp.Models
{
    public class CurrentSession
    {
        [JsonProperty("accountId")]
        public long AccountId { get; set; }

        [JsonProperty("connected")]
        public bool Connected { get; set; }

        [JsonProperty("error")]
        public object? Error { get; set; }

        [JsonProperty("idToken")]
        public string? IdToken { get; set; }
    }
}
