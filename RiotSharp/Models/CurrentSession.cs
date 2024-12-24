using Newtonsoft.Json;

namespace RiotSharp.Models
{
    public class CurrentSession
    {
        [JsonProperty("accountId")]
        public long? AccountId;

        [JsonProperty("connected")]
        public bool? Connected;

        [JsonProperty("error")]
        public object? Error;

        [JsonProperty("idToken")]
        public string? IdToken;

        [JsonProperty("isInLoginQueue")]
        public bool? IsInLoginQueue;

        [JsonProperty("isNewPlayer")]
        public bool? IsNewPlayer;

        [JsonProperty("puuid")]
        public string? Puuid;

        [JsonProperty("state")]
        public string? State;

        [JsonProperty("summonerId")]
        public long? SummonerId;

        [JsonProperty("userAuthToken")]
        public string? UserAuthToken;

        [JsonProperty("username")]
        public string? Username;
    }
}