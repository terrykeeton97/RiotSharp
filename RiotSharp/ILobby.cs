using RiotSharp.Enums;

namespace RiotSharp
{
    public interface ILobby
    {
        Task CreateLobbyAsync(QueueId queueId);
        Task QueueAsync(QueueType queueType);
        Task AcceptQueueAsync();
        Task SelectRoleAsync(string? primaryRole, string? secondaryRole);
    }
}
