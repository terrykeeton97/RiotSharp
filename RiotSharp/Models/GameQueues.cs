using Newtonsoft.Json;

namespace RiotSharp.Models
{
    public class GameQueues
    {
        public class GameTypeConfig
        {
            [JsonProperty("advancedLearningQuests")]
            public bool? AdvancedLearningQuests;

            [JsonProperty("allowTrades")]
            public bool? AllowTrades;

            [JsonProperty("banMode")]
            public string BanMode;

            [JsonProperty("banTimerDuration")]
            public int? BanTimerDuration;

            [JsonProperty("battleBoost")]
            public bool? BattleBoost;

            [JsonProperty("crossTeamChampionPool")]
            public bool? CrossTeamChampionPool;

            [JsonProperty("deathMatch")]
            public bool? DeathMatch;

            [JsonProperty("doNotRemove")]
            public bool? DoNotRemove;

            [JsonProperty("duplicatePick")]
            public bool? DuplicatePick;

            [JsonProperty("exclusivePick")]
            public bool? ExclusivePick;

            [JsonProperty("gameModeOverride")]
            public object GameModeOverride;

            [JsonProperty("id")]
            public int? Id;

            [JsonProperty("learningQuests")]
            public bool? LearningQuests;

            [JsonProperty("mainPickTimerDuration")]
            public int? MainPickTimerDuration;

            [JsonProperty("maxAllowableBans")]
            public int? MaxAllowableBans;

            [JsonProperty("name")]
            public string Name;

            [JsonProperty("numPlayersPerTeamOverride")]
            public object NumPlayersPerTeamOverride;

            [JsonProperty("onboardCoopBeginner")]
            public bool? OnboardCoopBeginner;

            [JsonProperty("pickMode")]
            public string PickMode;

            [JsonProperty("postPickTimerDuration")]
            public int? PostPickTimerDuration;

            [JsonProperty("reroll")]
            public bool? Reroll;

            [JsonProperty("teamChampionPool")]
            public bool? TeamChampionPool;
        }

        public class QueueRewards
        {
            [JsonProperty("isChampionPointsEnabled")]
            public bool? IsChampionPointsEnabled;

            [JsonProperty("isIpEnabled")]
            public bool? IsIpEnabled;

            [JsonProperty("isXpEnabled")]
            public bool? IsXpEnabled;

            [JsonProperty("partySizeIpRewards")]
            public List<object> PartySizeIpRewards;
        }

        public class Root
        {
            [JsonProperty("allowablePremadeSizes")]
            public List<int?> AllowablePremadeSizes;

            [JsonProperty("areFreeChampionsAllowed")]
            public bool? AreFreeChampionsAllowed;

            [JsonProperty("assetMutator")]
            public string AssetMutator;

            [JsonProperty("category")]
            public string Category;

            [JsonProperty("championsRequiredToPlay")]
            public int? ChampionsRequiredToPlay;

            [JsonProperty("description")]
            public string Description;

            [JsonProperty("detailedDescription")]
            public string DetailedDescription;

            [JsonProperty("gameMode")]
            public string GameMode;

            [JsonProperty("gameSelectCategory")]
            public string GameSelectCategory;

            [JsonProperty("gameSelectModeGroup")]
            public string GameSelectModeGroup;

            [JsonProperty("gameSelectPriority")]
            public int? GameSelectPriority;

            [JsonProperty("gameTypeConfig")]
            public GameTypeConfig GameTypeConfig;

            [JsonProperty("id")]
            public int? Id;

            [JsonProperty("isRanked")]
            public bool? IsRanked;

            [JsonProperty("isSkillTreeQueue")]
            public bool? IsSkillTreeQueue;

            [JsonProperty("isTeamBuilderManaged")]
            public bool? IsTeamBuilderManaged;

            [JsonProperty("isVisible")]
            public bool? IsVisible;

            [JsonProperty("lastToggledOffTime")]
            public int? LastToggledOffTime;

            [JsonProperty("lastToggledOnTime")]
            public int? LastToggledOnTime;

            [JsonProperty("mapId")]
            public int? MapId;

            [JsonProperty("maxDivisionForPremadeSize2")]
            public string MaxDivisionForPremadeSize2;

            [JsonProperty("maxTierForPremadeSize2")]
            public string MaxTierForPremadeSize2;

            [JsonProperty("maximumParticipantListSize")]
            public int? MaximumParticipantListSize;

            [JsonProperty("minLevel")]
            public int? MinLevel;

            [JsonProperty("minimumParticipantListSize")]
            public int? MinimumParticipantListSize;

            [JsonProperty("name")]
            public string Name;

            [JsonProperty("numPlayersPerTeam")]
            public int? NumPlayersPerTeam;

            [JsonProperty("queueAvailability")]
            public string QueueAvailability;

            [JsonProperty("queueRewards")]
            public QueueRewards QueueRewards;

            [JsonProperty("removalFromGameAllowed")]
            public bool? RemovalFromGameAllowed;

            [JsonProperty("removalFromGameDelayMinutes")]
            public int? RemovalFromGameDelayMinutes;

            [JsonProperty("shortName")]
            public string ShortName;

            [JsonProperty("showPositionSelector")]
            public bool? ShowPositionSelector;

            [JsonProperty("showQuickPlaySlotSelection")]
            public bool? ShowQuickPlaySlotSelection;

            [JsonProperty("spectatorEnabled")]
            public bool? SpectatorEnabled;

            [JsonProperty("type")]
            public string Type;
        }


    }
}
