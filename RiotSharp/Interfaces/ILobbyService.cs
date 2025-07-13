using RiotSharp.Enums;

namespace RiotSharp.Interfaces
{
    public interface ILobbyService
    {
        public Task CreateLobbyAsync(QueueId queueId);

        public Task QueueAsync(QueueType queueType);

        public Task SelectRoleAsync(string? primaryRole, string? secondaryRole);

        public Task AcceptQueueAsync();
    }
}
