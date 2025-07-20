using Newtonsoft.Json;

namespace RiotSharp.Models
{
    public class Summoner
    {
        public class RerollPoints
        {
            [JsonProperty("currentPoints")]
            public int? CurrentPoints;

            [JsonProperty("maxRolls")]
            public int? MaxRolls;

            [JsonProperty("numberOfRolls")]
            public int? NumberOfRolls;

            [JsonProperty("pointsCostToRoll")]
            public int? PointsCostToRoll;

            [JsonProperty("pointsToReroll")]
            public int? PointsToReroll;
        }

        public class Root
        {
            [JsonProperty("accountId")]
            public double? AccountId;

            [JsonProperty("displayName")]
            public string DisplayName;

            [JsonProperty("gameName")]
            public string GameName;

            [JsonProperty("internalName")]
            public string InternalName;

            [JsonProperty("nameChangeFlag")]
            public bool? NameChangeFlag;

            [JsonProperty("percentCompleteForNextLevel")]
            public int? PercentCompleteForNextLevel;

            [JsonProperty("privacy")]
            public string Privacy;

            [JsonProperty("profileIconId")]
            public int? ProfileIconId;

            [JsonProperty("puuid")]
            public string Puuid;

            [JsonProperty("rerollPoints")]
            public RerollPoints RerollPoints;

            [JsonProperty("summonerId")]
            public double? SummonerId;

            [JsonProperty("summonerLevel")]
            public int? SummonerLevel;

            [JsonProperty("tagLine")]
            public string TagLine;

            [JsonProperty("unnamed")]
            public bool? Unnamed;

            [JsonProperty("xpSinceLastLevel")]
            public int? XpSinceLastLevel;

            [JsonProperty("xpUntilNextLevel")]
            public int? XpUntilNextLevel;
        }
    }
}
