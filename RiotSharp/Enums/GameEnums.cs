namespace RiotSharp.Enums
{
    public enum QueueId
    {
        CustomPvP = 512677,
        DraftPick = 400,
        SoloDuo = 420,
        BlindPick = 430,
        Flex = 440,
        Aram = 450,
    }

    public enum Role
    {
        Unselected = 0,
        Top = 1,
        Jungle = 2,
        Middle = 3,
        Bottom = 4,
        Utility = 5,
        Fill = 6,
    }

    public enum SummonerSpell
    {
        Cleanse = 1,
        Exhaust = 3,
        Flash = 4,
        Ghost = 6,
        Heal = 7,
        Smite = 11,
        Teleport = 12,
        Clarity = 13,
        Ignite = 14,
        Barrier = 21,
    }

    public enum QueueType
    {
        Search,
        Cancel
    }
}