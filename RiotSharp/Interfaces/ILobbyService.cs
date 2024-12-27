using RiotSharp.Enums;

namespace RiotSharp.Interfaces
{
    internal interface ILobbyService
    {
        public Task CreateLobby(QueueId queueId);

        public Task QueueAsync(QueueType queueType);

        public Task SelectRoleAsync(string? primaryRole, string? secondaryRole);

        public Task AcceptQueue();
    }
}