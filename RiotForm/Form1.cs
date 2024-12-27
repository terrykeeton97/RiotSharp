using RiotSharp.Enums;
using RiotSharp.Services;
using RiotSharp.Utilities;

namespace RiotForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var accountService = new AccountService(HttpClientFactory.Instance.Value);
            await accountService.GetSummonerAsync();

            var lobbyService = new LobbyService(HttpClientFactory.Instance.Value);
            await lobbyService.QueueAsync(QueueType.Search);
        }
    }
}