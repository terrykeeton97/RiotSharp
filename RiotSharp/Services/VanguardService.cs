using Newtonsoft.Json;
using RiotSharp.Enums;
using RiotSharp.Interfaces;
using RiotSharp.Models;
using RiotSharp.Utilities;

namespace RiotSharp.Services
{
    public class VanguardService(HttpClientFactory httpClientFactory) : IVanguardService
    {
        public async Task<bool> IsVanguardEnabledAsync()
        {
            return await httpClientFactory.MakeApiRequest<bool>(RequestMethod.Get, "/lol-vanguard/v1/config/enabled");
        }

        public async Task<Vanguard.MachineSpecs?> MachineSpecsAsync()
        {
            return await httpClientFactory.MakeApiRequest<Vanguard.MachineSpecs?>(RequestMethod.Get, "/lol-vanguard/v1/machine-specs");
        }
    }
}