using Newtonsoft.Json;

namespace RiotSharp.Models
{
    public class Invites
    {
        public class Invite
        {
            [JsonProperty("canAcceptInvitation")]
            public bool? CanAcceptInvitation;

            [JsonProperty("fromSummonerId")]
            public int? FromSummonerId;

            [JsonProperty("fromSummonerName")]
            public string? FromSummonerName;

            [JsonProperty("gameConfig")]
            internal GameConfig? GameConfig;

            [JsonProperty("invitationId")]
            public string? InvitationId;

            [JsonProperty("invitationType")]
            public string? InvitationType;

            [JsonProperty("restrictions")]
            public List<object>? Restrictions;

            [JsonProperty("state")]
            public string? State;

            [JsonProperty("timestamp")]
            public string? Timestamp;
        }

        internal class GameConfig
        {
            [JsonProperty("gameMode")]
            public string? GameMode;

            [JsonProperty("inviteGameType")]
            public string? InviteGameType;

            [JsonProperty("mapId")]
            public int? MapId;

            [JsonProperty("queueId")]
            public int? QueueId;
        }

        internal class Root
        {
            [JsonProperty("MyArray")]
            public List<Invite>? MyArray;
        }
    }
}