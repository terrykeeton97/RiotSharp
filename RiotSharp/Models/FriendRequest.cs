using Newtonsoft.Json;

namespace RiotSharp.Models
{
    public class FriendRequest
    {
        [JsonProperty("direction")]
        public string? Direction { get; set; }

        [JsonProperty("gameName")]
        public string? GameName { get; set; }

        [JsonProperty("icon")]
        public int Icon { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("note")]
        public string? Note { get; set; }

        [JsonProperty("pid")]
        public string? Pid { get; set; }

        [JsonProperty("puuid")]
        public string? Puuid { get; set; }

        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }

        [JsonProperty("tagLine")]
        public string? TagLine { get; set; }
    }
}