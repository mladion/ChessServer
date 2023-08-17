using System.Net.Http.Json;
using Microsoft.AspNetCore.SignalR.Client;

namespace Client.Pages
{
	public partial class Index
	{
        HubConnection hubConnection = new HubConnectionBuilder().WithUrl("https://localhost:7197/connect").Build();

        bool inGame = false;
        bool isWhitePlayer = true;
        string tableId = "";

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

            tableId = Guid.NewGuid().ToString();
            await hubConnection.SendAsync("JoinTable", tableId);
            inGame = true;
        }

        public async Task JoinGame(string gameId)
        {
            await hubConnection.StartAsync();
            this.tableId = gameId;
            isWhitePlayer = false;
            await hubConnection.SendAsync("JoinTable", gameId);
            inGame = true;
        }
    }
}

