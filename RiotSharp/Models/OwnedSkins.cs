using Newtonsoft.Json;

namespace RiotSharp.Models
{
    public class OwnedSkins
    {
        public class Payload
        {
            [JsonProperty("isVintage")]
            public bool? IsVintage;
        }

        public class Root
        {
            [JsonProperty("expirationDate")]
            public string ExpirationDate;

            [JsonProperty("f2p")]
            public bool? F2p;

            [JsonProperty("inventoryType")]
            public string InventoryType;

            [JsonProperty("itemId")]
            public int? ItemId;

            [JsonProperty("loyalty")]
            public bool? Loyalty;

            [JsonProperty("loyaltySources")]
            public List<object> LoyaltySources;

            [JsonProperty("owned")]
            public bool? Owned;

            [JsonProperty("ownershipType")]
            public string OwnershipType;

            [JsonProperty("payload")]
            public Payload Payload;

            [JsonProperty("purchaseDate")]
            public string PurchaseDate;

            [JsonProperty("quantity")]
            public int? Quantity;

            [JsonProperty("rental")]
            public bool? Rental;

            [JsonProperty("uuid")]
            public string Uuid;

            [JsonProperty("wins")]
            public int? Wins;
        }


    }
}
