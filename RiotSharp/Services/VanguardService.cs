using Newtonsoft.Json;
using RiotSharp.Constants;
using RiotSharp.Enums;
using RiotSharp.Models;
using RiotSharp.Utilities;

namespace RiotSharp.Services
{
    internal class VanguardService(HttpClientFactory httpClientFactory) : IVanguardService
    {
        public async Task<bool> IsVanguardEnabledAsync()
        {
            return await httpClientFactory.MakeApiRequest<bool>(RequestMethod.Get, ApiEndpoints.VanguardEnabled);
        }

        public async Task<Vanguard.MachineSpecs?> MachineSpecsAsync()
        {
            return await httpClientFactory.MakeApiRequest<Vanguard.MachineSpecs?>(RequestMethod.Get, ApiEndpoints.VanguardMachineSpecs);
        }
    }
}
