using Newtonsoft.Json;
using RiotSharp.Constants;
using RiotSharp.Enums;
using RiotSharp.Models;
using RiotSharp.Utilities;

namespace RiotSharp.Services
{
    public class VanguardService : IVanguard
    {
        private readonly HttpClientFactory _httpClientFactory;

        public VanguardService()
        {
            _httpClientFactory = HttpClientFactory.Instance;
        }

        public async Task<bool> IsVanguardEnabledAsync()
        {
            return await _httpClientFactory.GetAsync<bool>(ApiEndpoints.VanguardEnabled);
        }

        public async Task<Vanguard.MachineSpecs?> MachineSpecsAsync()
        {
            return await _httpClientFactory.GetAsync<Vanguard.MachineSpecs?>(ApiEndpoints.VanguardMachineSpecs);
        }
    }
}
