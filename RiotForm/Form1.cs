using RiotSharp.Models;
using RiotSharp.Services;

namespace RiotForm;

public partial class Form1 : Form
{
    private RiotApiClient riotClient = new RiotApiClient();
    public Form1()
    {
        InitializeComponent();


    }

    private async void Button1_Click(object sender, EventArgs e)
    {
        var response = await riotClient.GetAccountSessionAsync();
    }

    private async void button2_Click(object sender, EventArgs e)
    {
        var response = await riotClient.GetUsernameAsync();
    }

    private async void button3_Click(object sender, EventArgs e)
    {
        var response = await riotClient.GetSummonerId();
    }

    private async void button4_Click(object sender, EventArgs e)
    {
        var response = await riotClient.GetAllChampionsAsync();
        foreach (var champ in response)
        {
            listBox1.Items.Add(champ.Name);
        }
    }

    private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        await riotClient.SelectRoleAsync(comboBox1.Text, comboBox2.Text);
    }

    private async void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
        await riotClient.SelectRoleAsync(comboBox1.Text, comboBox2.Text);
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private async void button5_Click(object sender, EventArgs e)
    {
        var friendRequests = await riotClient.GetFriendRequests();
        await riotClient.AcceptFriendRequestAsync(friendRequests);
    }

    private async void button6_Click(object sender, EventArgs e)
    {
        var friendRequests = await riotClient.GetFriendRequests();
        listBox2.Items.Clear();

        foreach (var friend in friendRequests)
        {
            listBox2.Items.Add(friend);
        }
    }

    private async void listBox2_DoubleClick(object sender, EventArgs e)
    {
        var selectedFriend = listBox2.SelectedItem as FriendRequest;

        if (selectedFriend != null)
        {
            await riotClient.AcceptFriendRequestAsync(selectedFriend.Puuid);
        }
    }
}
