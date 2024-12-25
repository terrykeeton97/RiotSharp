using Newtonsoft.Json;
using RiotSharp.Enums;
using RiotSharp.Interfaces;
using RiotSharp.Models;
using RiotSharp.Utilities;

namespace RiotSharp.Services
{
    public class VanguardService : IVanguardService
    {
        private HttpClientFactory _httpClient = new();

        public async Task<bool> IsVanguardEnabled()
        {
            var response = await _httpClient.MakeApiRequest(RequestMethod.Get, "lol-vanguard/v1/config/enabled");
            return JsonConvert.DeserializeObject<bool>(response);
        }

        public async Task<Vanguard.MachineSpecs?> MachineSpecs()
        {
            var response = await _httpClient.MakeApiRequest(RequestMethod.Get, "/lol-vanguard/v1/machine-specs");
            return JsonConvert.DeserializeObject<Vanguard.MachineSpecs?>(response);
        }
    }
}