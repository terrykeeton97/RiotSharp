using RiotSharp.Models;

namespace RiotSharp.Interfaces
{
    internal interface IVanguardService
    {
        public Task<bool> IsVanguardEnabled();

        public Task<Vanguard.MachineSpecs> MachineSpecs();
    }
}