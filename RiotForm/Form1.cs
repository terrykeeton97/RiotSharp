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
            var clientService = new ClientService(HttpClientFactory.Instance.Value);
            var queues = await clientService.GetGameQueuesAsync();

            foreach (var queue in queues)
            {
                Console.WriteLine(queue.Name);
                Console.WriteLine(queue.Description);
                Console.WriteLine(queue.ChampionsRequiredToPlay);
                Console.WriteLine(queue.ShortName);
            }
        }
    }
}