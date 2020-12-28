using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace e_Shop_Demo.Hubs
{
    public class ChatHub : Hub
    {
        public async Task Send(string name, string message)
        {
            await Clients.All.SendAsync("broadcastMessage", name, message);
        }

        [HubMethodName("SendMessageToUser")]
        public void NewContosoChatMessage(string userName, string message)
        {
            System.Console.WriteLine($"user:{userName},message:{message}");
            Clients.All.SendAsync("broadcastMessage", message);
        }
    }
}
