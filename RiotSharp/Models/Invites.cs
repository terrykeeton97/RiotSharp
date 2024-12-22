namespace RiotSharp.Models
{
    public class Invites
    {
        public class LobbyInvitationResponse
        {
            public int Id { get; set; }
            public TaskStatus Status { get; set; }
            public string? Method { get; set; }
            public List<LobbyInvitation>? Result { get; set; }
        }

        public class LobbyInvitation
        {
            public bool CanAcceptInvitation { get; set; }
            public long FromSummonerId { get; set; }
            public string? FromSummonerName { get; set; }
            public GameConfig? GameConfig { get; set; }
            public string? InvitationId { get; set; }
            public string? InvitationType { get; set; }
            public List<object>? Restrictions { get; set; }
            public string? State { get; set; }
            public string? Timestamp { get; set; }
        }

        public class GameConfig
        {
            public string? GameMode { get; set; }
            public string? InviteGameType { get; set; }
            public int MapId { get; set; }
            public int QueueId { get; set; }
        }
    }
}