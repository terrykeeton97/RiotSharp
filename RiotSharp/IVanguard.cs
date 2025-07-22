using RiotSharp.Models;

namespace RiotSharp
{
    public interface IVanguard
    {
        Task<bool> IsVanguardEnabledAsync();
        Task<Vanguard.MachineSpecs?> MachineSpecsAsync();
    }
}
