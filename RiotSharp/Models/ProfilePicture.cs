using Newtonsoft.Json;

namespace RiotSharp.Models
{
    public class ProfilePicture
    {
        [JsonProperty("id")]
        public int? Id;

        [JsonProperty("image")]
        public Image Image;
    }

    public class Image
    {
        [JsonProperty("full")]
        public string Full;

        [JsonProperty("sprite")]
        public string Sprite;

        [JsonProperty("group")]
        public string Group;

        [JsonProperty("x")]
        public int? X;

        [JsonProperty("y")]
        public int? Y;

        [JsonProperty("w")]
        public int? W;

        [JsonProperty("h")]
        public int? H;
    }
}
