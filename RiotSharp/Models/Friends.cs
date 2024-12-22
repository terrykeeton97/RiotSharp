using Newtonsoft.Json;

namespace RiotSharp.Models
{
    public class Friends
    {
        [JsonProperty("availability")]
        public string? Availability { get; set; }

        [JsonProperty("displayGroupId")]
        public int DisplayGroupId { get; set; }

        [JsonProperty("displayGroupName")]
        public string? DisplayGroupName { get; set; }

        [JsonProperty("gameName")]
        public string? GameName { get; set; }

        [JsonProperty("gameTag")]
        public string? GameTag { get; set; }

        [JsonProperty("groupId")]
        public int GroupId { get; set; }

        [JsonProperty("groupName")]
        public string? GroupName { get; set; }

        [JsonProperty("icon")]
        public int Icon { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("isP2PConversationMuted")]
        public bool IsP2PConversationMuted { get; set; }

        [JsonProperty("lastSeenOnlineTimestamp")]
        public object? LastSeenOnlineTimestamp { get; set; }
    }
}
