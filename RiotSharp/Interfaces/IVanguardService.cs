using RiotSharp.Models;

namespace RiotSharp.Interfaces
{
    internal interface IVanguardService
    {
        public Task<bool> IsVanguardEnabledAsync();

        public Task<Vanguard.MachineSpecs> MachineSpecsAsync();
    }
}