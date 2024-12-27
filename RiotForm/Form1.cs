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
            var errorList = await clientService.GetAllClientErrorsAsync();

            foreach (var error in errorList)
            {
                await clientService.RemoveClientErrorById(error.Id);
            }

            errorList = await clientService.GetAllClientErrorsAsync();
        }
    }
}