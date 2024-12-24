using System.Diagnostics.CodeAnalysis;
using RiotSharp.Models;
using RiotSharp.Services;

namespace RiotForm;

[SuppressMessage("ReSharper", "AsyncVoidMethod")]
public partial class Form1 : Form
{
    private readonly AccountService _accountService = new();
    private readonly ChampionService _championService = new();
    private readonly LobbyService _lobbyService = new();
    private readonly FriendService _friendService = new();
    private readonly ClientService _clientService = new();

    public Form1()
    {
        InitializeComponent();
    }

    private async void Button1_Click(object sender, EventArgs e)
    {
        var response = await _accountService.GetAccountSessionAsync();
    }

    private async void button2_Click(object sender, EventArgs e)
    {
        var response = await _accountService.GetUsernameAsync();
    }

    private async void button3_Click(object sender, EventArgs e)
    {
        var response = await _accountService.GetSummonerIdAsync();
    }

    private async void button4_Click(object sender, EventArgs e)
    {
        var response = await _championService.GetAllChampionsAsync();
        listBox1.Items.Clear();
        foreach (var champ in response)
        {
            listBox1.Items.Add(champ.Name);
        }
    }

    private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        await _lobbyService.SelectRoleAsync(comboBox1.Text, comboBox2.Text);
    }

    private async void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
        await _lobbyService.SelectRoleAsync(comboBox1.Text, comboBox2.Text);
    }

    private void Form1_Load(object sender, EventArgs e)
    {
    }

    private async void button5_Click(object sender, EventArgs e)
    {
        var friendRequests = await _friendService.GetFriendRequests();
        await _friendService.AcceptAllFriendRequestAsync(friendRequests);
    }

    private async void button6_Click(object sender, EventArgs e)
    {
        var friendRequests = await _friendService.GetFriendRequests();
        listBox2.Items.Clear();

        foreach (var friend in friendRequests)
        {
            listBox2.Items.Add(friend);
        }
    }

    private async void listBox2_DoubleClick(object sender, EventArgs e)
    {
        var selectedFriend = listBox2.SelectedItem as FriendRequest;
        var selectedInvite = listBox2.SelectedItem as Invites.Invite;

        if (selectedFriend is FriendRequest && selectedFriend != null)
        {
            await _friendService.AcceptFriendRequestAsync(selectedFriend.Puuid);
        }

        if (selectedInvite is Invites.Invite && selectedInvite != null)
        {
            await _clientService.AcceptInviteAsync(selectedInvite.InvitationId);
        }
    }

    private async void button7_Click(object sender, EventArgs e)
    {
        var invites = await _clientService.GetInvites();
        listBox2.Items.Clear();

        foreach (var invite in invites)
        {
            listBox2.Items.Add(invite);
        }
    }

    private async void button9_Click(object sender, EventArgs e)
    {
        var response = await riotClient.GetOwnedChampions();
        listBox1.Items.Clear();
        foreach (var champion in response)
        {
            listBox1.Items.Add(champion.Name);
        }
    }

    private async void button10_Click(object sender, EventArgs e)
    {
        var response = await riotClient.GetFreeToPlayChampions();
        foreach (var champion in response)
        {
            listBox1.Items.Add(champion.Name);
        }
    }
}