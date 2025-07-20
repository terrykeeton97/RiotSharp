using Newtonsoft.Json;

namespace RiotSharp.Models
{
    public class SearchState
    {
        public class Error
        {
            [JsonProperty("errorType")]
            public string? ErrorType { get; set; }

            [JsonProperty("id")]
            public int? Id { get; set; }

            [JsonProperty("message")]
            public string? Message { get; set; }

            [JsonProperty("penalizedSummonerId")]
            public long? PenalizedSummonerId { get; set; }

            [JsonProperty("penaltyTimeRemaining")]
            public double? PenaltyTimeRemaining { get; set; }
        }

        public class LowPriorityData
        {
            [JsonProperty("bustedLeaverAccessToken")]
            public string? BustedLeaverAccessToken { get; set; }

            [JsonProperty("penalizedSummonerIds")]
            public List<object>? PenalizedSummonerIds { get; set; }

            [JsonProperty("penaltyTime")]
            public double? PenaltyTime { get; set; }

            [JsonProperty("penaltyTimeRemaining")]
            public double? PenaltyTimeRemaining { get; set; }

            [JsonProperty("reason")]
            public string? Reason { get; set; }
        }

        public class Root
        {
            [JsonProperty("errors")]
            public List<Error>? Errors { get; set; }

            [JsonProperty("lowPriorityData")]
            public LowPriorityData? LowPriorityData { get; set; }

            [JsonProperty("searchState")]
            public string? SearchState { get; set; }
        }
    }
}
