using Microsoft.AspNetCore.SignalR;
using Shared.Data;

namespace WebAPI.Hubs
{
    public class MultiplayerHub : Hub
    {
        private readonly TableManager _tableManager;

        public MultiplayerHub(TableManager tableManager)
        {
            _tableManager = tableManager;
        }

        public async Task JoinTable(string tableId)
        {
            if (_tableManager.Tables.ContainsKey(tableId))
            {
                if (_tableManager.Tables[tableId] < 2)
                {
                    await Groups.AddToGroupAsync(Context.ConnectionId, tableId);

                    await Clients.GroupExcept(tableId, Context.ConnectionId).SendAsync("TableJoined");

                    _tableManager.Tables[tableId]++;
                }
            }
            else
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, tableId);
                _tableManager.Tables.Add(tableId, 1);
            }
        }

        public async Task Move(string tableId, int previousRow, int previousColumn, int newRow, int newColumn)
        {
            await Clients.GroupExcept(tableId, Context.ConnectionId).SendAsync("Move", previousRow, previousColumn, newRow, newColumn);
        }
    }
}
