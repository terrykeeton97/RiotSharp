using Newtonsoft.Json;

namespace RiotSharp.Models
{
    public class BlockedSummoners
    {
        [JsonProperty("gameName")]
        public string GameName;

        [JsonProperty("gameTag")]
        public string GameTag;

        [JsonProperty("icon")]
        public int? Icon;

        [JsonProperty("id")]
        public string Id;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("pid")]
        public string Pid;

        [JsonProperty("puuid")]
        public string Puuid;

        [JsonProperty("summonerId")]
        public int? SummonerId;
    }
}
