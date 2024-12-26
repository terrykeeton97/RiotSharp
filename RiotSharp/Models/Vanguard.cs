using Newtonsoft.Json;

namespace RiotSharp.Models
{
    public class Vanguard
    {
        public class MachineSpecs
        {
            [JsonProperty("secureBootEnabled")]
            public bool? SecureBootEnabled;

            [JsonProperty("tpm2Enabled")]
            public bool? Tpm2Enabled;
        }

        public class SystemCheck
        {
            [JsonProperty("passedOsCheck")]
            public bool? PassedOsCheck;

            [JsonProperty("passedSecureFeaturesCheck")]
            public bool? PassedSecureFeaturesCheck;
        }
    }
}