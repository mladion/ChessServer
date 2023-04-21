using System.Net.Http.Json;
using Microsoft.AspNetCore.SignalR.Client;

namespace Client.Pages
{
	public partial class Index
	{
        HubConnection hubConnection = new HubConnectionBuilder().WithUrl("https://localhost:7197/connect").Build();

        bool inGame = false;

        List<string>? tables = new List<string>();

        protected override async Task OnInitializedAsync()
        {
            await RefreshTables();
        }

        public async Task RefreshTables()
        {
            tables = await Http.GetFromJsonAsync<List<string>>("/table/getTables");
        }

        public async Task CreateGame()
        {
            await hubConnection.StartAsync();

            string tableId = Guid.NewGuid().ToString();
            await hubConnection.SendAsync("JoinTable", tableId);
            inGame = true;
        }

        public async Task JoinGame(string gameId)
        {
            await hubConnection.StartAsync();

            await hubConnection.SendAsync("JoinTable", gameId);
            inGame = true;
        }
    }
}

