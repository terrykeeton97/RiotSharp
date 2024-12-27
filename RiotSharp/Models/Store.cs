using Newtonsoft.Json;

namespace RiotSharp.Models
{
    public class Store
    {
        public class EnGB
        {
            [JsonProperty("description")]
            public string Description;

            [JsonProperty("language")]
            public string Language;

            [JsonProperty("name")]
            public string Name;
        }

        public class ItemRequirement
        {
            [JsonProperty("inventoryType")]
            public string InventoryType;

            [JsonProperty("itemId")]
            public int? ItemId;
        }

        public class Localizations
        {
            [JsonProperty("en_GB")]
            public EnGB EnGB;
        }

        public class Price
        {
            [JsonProperty("cost")]
            public int? Cost;

            [JsonProperty("currency")]
            public string Currency;

            [JsonProperty("discount")]
            public double? Discount;
        }

        public class Catalog
        {
            [JsonProperty("active")]
            public bool? Active;

            [JsonProperty("bundled")]
            public object Bundled;

            [JsonProperty("iconUrl")]
            public string IconUrl;

            [JsonProperty("inactiveDate")]
            public object InactiveDate;

            [JsonProperty("inventoryType")]
            public string InventoryType;

            [JsonProperty("itemId")]
            public int? ItemId;

            [JsonProperty("itemInstanceId")]
            public string ItemInstanceId;

            [JsonProperty("itemRequirements")]
            public List<ItemRequirement> ItemRequirements;

            [JsonProperty("localizations")]
            public Localizations Localizations;

            [JsonProperty("maxQuantity")]
            public int? MaxQuantity;

            [JsonProperty("metadata")]
            public object Metadata;

            [JsonProperty("offerId")]
            public string OfferId;

            [JsonProperty("prices")]
            public List<Price> Prices;

            [JsonProperty("releaseDate")]
            public DateTime? ReleaseDate;

            [JsonProperty("sale")]
            public object Sale;

            [JsonProperty("subInventoryType")]
            public string SubInventoryType;

            [JsonProperty("tags")]
            public List<string> Tags;
        }

        public class BearerToken
        {
            [JsonProperty("expiry")]
            public int? Expiry;

            [JsonProperty("scopes")]
            public List<string> Scopes;

            [JsonProperty("token")]
            public string Token;
        }
    }
}
