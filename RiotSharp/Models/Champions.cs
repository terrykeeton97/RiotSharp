namespace RiotSharp.Models
{
    public class Champions
    {
        public bool Active { get; set; }
        public string? Alias { get; set; }
        public string? BanVoPath { get; set; }
        public string? BaseLoadScreenPath { get; set; }
        public string? BaseSplashPath { get; set; }
        public bool BotEnabled { get; set; }
        public string? ChooseVoPath { get; set; }
        public bool FreeToPlay { get; set; }
        public int Id { get; set; }
        public string? Name { get; set; }
        public Ownership? Ownership { get; set; }
        public ulong Purchased { get; set; }
        public bool RankedPlayEnabled { get; set; }
        public List<string>? Roles { get; set; }
        public string? SquarePortraitPath { get; set; }
        public string? StingerSfxPath { get; set; }
        public string? Title { get; set; }
    }

    public class Ownership
    {
        public bool LoyaltyReward { get; set; }
        public bool Owned { get; set; }
        public Rental? Rental { get; set; }
        public bool XboxGPReward { get; set; }
    }

    public class Rental
    {
        public ulong EndDate { get; set; }
        public ulong PurchaseDate { get; set; }
        public bool Rented { get; set; }
        public int WinCountRemaining { get; set; }
    }
}
