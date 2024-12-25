using RiotSharp.Services;

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
            var accountService = new AccountService();

            await accountService.GetAllProfilePictureIds();
        }
    }
}
