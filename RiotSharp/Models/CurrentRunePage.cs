using Newtonsoft.Json;

namespace RiotSharp.Models
{
    public class CurrentRunePage
    {
        public class PageKeystone
        {
            [JsonProperty("iconPath")]
            public string IconPath;

            [JsonProperty("id")]
            public int? Id;

            [JsonProperty("name")]
            public string Name;

            [JsonProperty("slotType")]
            public string SlotType;

            [JsonProperty("styleId")]
            public int? StyleId;
        }

        public class Root
        {
            [JsonProperty("autoModifiedSelections")]
            public List<object> AutoModifiedSelections;

            [JsonProperty("current")]
            public bool? Current;

            [JsonProperty("id")]
            public int? Id;

            [JsonProperty("isActive")]
            public bool? IsActive;

            [JsonProperty("isDeletable")]
            public bool? IsDeletable;

            [JsonProperty("isEditable")]
            public bool? IsEditable;

            [JsonProperty("isRecommendationOverride")]
            public bool? IsRecommendationOverride;

            [JsonProperty("isTemporary")]
            public bool? IsTemporary;

            [JsonProperty("isValid")]
            public bool? IsValid;

            [JsonProperty("lastModified")]
            public long? LastModified;

            [JsonProperty("name")]
            public string Name;

            [JsonProperty("order")]
            public int? Order;

            [JsonProperty("pageKeystone")]
            public PageKeystone PageKeystone;

            [JsonProperty("primaryStyleIconPath")]
            public string PrimaryStyleIconPath;

            [JsonProperty("primaryStyleId")]
            public int? PrimaryStyleId;

            [JsonProperty("primaryStyleName")]
            public string PrimaryStyleName;

            [JsonProperty("quickPlayChampionIds")]
            public List<object> QuickPlayChampionIds;

            [JsonProperty("recommendationChampionId")]
            public int? RecommendationChampionId;

            [JsonProperty("recommendationIndex")]
            public int? RecommendationIndex;

            [JsonProperty("runeRecommendationId")]
            public string RuneRecommendationId;

            [JsonProperty("secondaryStyleIconPath")]
            public string SecondaryStyleIconPath;

            [JsonProperty("secondaryStyleName")]
            public string SecondaryStyleName;

            [JsonProperty("selectedPerkIds")]
            public List<int?> SelectedPerkIds;

            [JsonProperty("subStyleId")]
            public int? SubStyleId;

            [JsonProperty("tooltipBgPath")]
            public string TooltipBgPath;

            [JsonProperty("uiPerks")]
            public List<UiPerk> UiPerks;
        }

        public class UiPerk
        {
            [JsonProperty("iconPath")]
            public string IconPath;

            [JsonProperty("id")]
            public int? Id;

            [JsonProperty("name")]
            public string Name;

            [JsonProperty("slotType")]
            public string SlotType;

            [JsonProperty("styleId")]
            public int? StyleId;
        }


    }
}
