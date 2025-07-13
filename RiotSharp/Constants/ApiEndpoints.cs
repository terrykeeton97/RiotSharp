namespace RiotSharp.Constants
{
    public static class ApiEndpoints
    {
        // Account endpoints
        public const string AccountSession = "/lol-login/v1/session";
        public const string CurrentSummoner = "/lol-summoner/v1/current-summoner";
        public const string CurrentRankedStats = "/lol-ranked/v1/current-ranked-stats";
        public const string RpWallet = "/lol-inventory/v1/wallet/RP";
        public const string OwnedSkins = "/lol-inventory/v2/inventory/CHAMPION_SKIN";
        public const string PlayerLootMap = "/lol-loot/v1/player-loot-map";
        public const string SaveAlias = "/lol-summoner/v1/save-alias";

        // Champion Select endpoints
        public const string ChampionSelectSession = "/lol-champ-select/v1/session";
        public const string CurrentChampion = "/lol-champ-select/v1/current-champion";
        public const string ChampionSelectActions = "/lol-champ-select/v1/session/actions";
        public const string ChampionSelectMySelection = "/lol-champ-select/v1/session/my-selection";
        public const string CurrentRunePage = "/lol-perks/v1/currentpage";
        public const string DodgeGame = "/lol-login/v1/session/invoke?destination=lcdsServiceProxy&method=call&args=[\"\",\"teambuilder-draft\",\"quitV2\",\"\"]";

        // Champion endpoints
        public const string OwnedChampions = "/lol-champions/v1/owned-champions-minimal";
        public const string AllChampions = "/lol-champions/v1/champions-minimal";

        // Client endpoints
        public const string SearchState = "/lol-matchmaking/v1/search";
        public const string Invites = "/lol-lobby/v2/received-invitations";
        public const string GameQueues = "/lol-game-queues/v1/queues";
        public const string ClientErrors = "/lol-client-config/v3/client-config";

        // Friend endpoints
        public const string FriendRequests = "/lol-chat/v2/friend-requests";
        public const string Friends = "/lol-chat/v1/friends";
        public const string BlockedPlayers = "/lol-chat/v1/blocked-players";

        // Lobby endpoints
        public const string Lobby = "/lol-lobby/v2/lobby";
        public const string MatchmakingSearch = "/lol-matchmaking/v1/search";
        public const string ReadyCheck = "/lol-matchmaking/v1/ready-check/accept";

        // Riot Client endpoints
        public const string GameSettings = "/lol-game-settings/v1/game-settings";
        public const string QuitClient = "/process-control/v1/process/quit";
        public const string RestartUx = "/riotclient/kill-and-restart-ux";

        // Store endpoints
        public const string StoreCatalog = "/lol-store/v1/catalog";
        public const string StoreUrl = "/lol-store/v1/getStoreUrl";
        public const string WalletJwt = "/lol-store/v1/wallet";
        public const string StoreBearerToken = "/lol-store/v1/getAuthToken";

        // Vanguard endpoints
        public const string VanguardEnabled = "/lol-vanguard/v1/config/enabled";
        public const string VanguardMachineSpecs = "/lol-vanguard/v1/machine-specs";

        // External endpoints
        public const string ProfileIconsData = "https://ddragon.leagueoflegends.com/cdn/14.24.1/data/en_US/profileicon.json";
    }
}
