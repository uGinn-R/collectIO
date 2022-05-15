using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace collectIO
{
    internal class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message, string itemId)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message, itemId);
        }
        public Task tryAddGroup(int itemId)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, itemId.ToString());
        }

    }
}