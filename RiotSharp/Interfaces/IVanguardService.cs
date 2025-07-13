using RiotSharp.Models;

namespace RiotSharp.Interfaces
{
    public interface IVanguardService
    {
        public Task<bool> IsVanguardEnabledAsync();

        public Task<Vanguard.MachineSpecs?> MachineSpecsAsync();
    }
}
