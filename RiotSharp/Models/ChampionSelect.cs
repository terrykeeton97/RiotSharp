using Newtonsoft.Json;

namespace RiotSharp.Models
{
    public class ChampionSelect
    {
        [JsonProperty("actions")]
        public List<List<Action>>? Actions { get; set; }

        [JsonProperty("allowBattleBoost")]
        public bool? AllowBattleBoost { get; set; }

        [JsonProperty("allowDuplicatePicks")]
        public bool? AllowDuplicatePicks { get; set; }

        [JsonProperty("allowLockedEvents")]
        public bool? AllowLockedEvents { get; set; }

        [JsonProperty("allowRerolling")]
        public bool? AllowRerolling { get; set; }

        [JsonProperty("allowSkinSelection")]
        public bool? AllowSkinSelection { get; set; }

        [JsonProperty("bans")]
        public Bans? Bans { get; set; }

        [JsonProperty("benchChampions")]
        public List<object>? BenchChampions { get; set; }

        [JsonProperty("benchEnabled")]
        public bool? BenchEnabled { get; set; }

        [JsonProperty("boostableSkinCount")]
        public int? BoostableSkinCount { get; set; }

        [JsonProperty("chatDetails")]
        public ChatDetails? ChatDetails { get; set; }

        [JsonProperty("counter")]
        public int? Counter { get; set; }

        [JsonProperty("gameId")]
        public long? GameId { get; set; }

        [JsonProperty("hasSimultaneousBans")]
        public bool? HasSimultaneousBans { get; set; }

        [JsonProperty("hasSimultaneousPicks")]
        public bool? HasSimultaneousPicks { get; set; }

        [JsonProperty("isCustomGame")]
        public bool? IsCustomGame { get; set; }

        [JsonProperty("isSpectating")]
        public bool? IsSpectating { get; set; }

        [JsonProperty("localPlayerCellId")]
        public int? LocalPlayerCellId { get; set; }

        [JsonProperty("lockedEventIndex")]
        public int? LockedEventIndex { get; set; }

        [JsonProperty("myTeam")]
        public List<TeamMember>? MyTeam { get; set; }
    }

    public class Action
    {
        [JsonProperty("actorCellId")]
        public int? ActorCellId { get; set; }

        [JsonProperty("championId")]
        public int? ChampionId { get; set; }

        [JsonProperty("completed")]
        public bool? Completed { get; set; }

        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("isAllyAction")]
        public bool? IsAllyAction { get; set; }

        [JsonProperty("isInProgress")]
        public bool? IsInProgress { get; set; }

        [JsonProperty("pickTurn")]
        public int? PickTurn { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }
    }

    public class Bans
    {
        [JsonProperty("myTeamBans")]
        public List<object>? MyTeamBans { get; set; }

        [JsonProperty("numBans")]
        public int? NumBans { get; set; }

        [JsonProperty("theirTeamBans")]
        public List<object>? TheirTeamBans { get; set; }
    }

    public class ChatDetails
    {
        [JsonProperty("mucJwtDto")]
        public MucJwtDto? MucJwtDto { get; set; }

        [JsonProperty("multiUserChatId")]
        public string? MultiUserChatId { get; set; }

        [JsonProperty("multiUserChatPassword")]
        public string? MultiUserChatPassword { get; set; }
    }

    public class MucJwtDto
    {
        [JsonProperty("channelClaim")]
        public string? ChannelClaim { get; set; }

        [JsonProperty("domain")]
        public string? Domain { get; set; }

        [JsonProperty("jwt")]
        public string? Jwt { get; set; }

        [JsonProperty("targetRegion")]
        public string? TargetRegion { get; set; }
    }

    public class TeamMember
    {
        [JsonProperty("assignedPosition")]
        public string? AssignedPosition { get; set; }

        [JsonProperty("cellId")]
        public int? CellId { get; set; }

        [JsonProperty("championId")]
        public int? ChampionId { get; set; }

        [JsonProperty("championPickIntent")]
        public int? ChampionPickIntent { get; set; }

        [JsonProperty("nameVisibilityType")]
        public string? NameVisibilityType { get; set; }

        [JsonProperty("obfuscatedPuuid")]
        public string? ObfuscatedPuuid { get; set; }

        [JsonProperty("obfuscatedSummonerId")]
        public long? ObfuscatedSummonerId { get; set; }
    }
}
