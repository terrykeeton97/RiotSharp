using RiotSharp.Services;

namespace RiotForm;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void Button1_Click(object sender, EventArgs e)
    {
        var s = new RiotApiClient();
        var response = s.GetCurrentFriendsListAsync();
        foreach (var friend in response.Result)
        {
            Console.WriteLine(friend.GameName);
        }

    }
}
