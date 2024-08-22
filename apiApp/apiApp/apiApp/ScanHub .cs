using Microsoft.AspNetCore.SignalR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace apiApp
{
    public class ScanHub : Hub
    {
        public async Task Lamp(string lampId, string time)
        {
            await Clients.All.SendAsync("ReceiveMessage", $"Lamp:{lampId}:{time}");
        }
        public async Task Buzzer(string time)
        {
            await Clients.All.SendAsync("ReceiveMessage", $"buzzer:{time}");
        }
        public async Task Mode(string selectMode)
        {
            await Clients.All.SendAsync("ReceiveMessage", $"mode:{selectMode}");
        }
        public async Task RemoveData(string epc)
        {
            await Clients.All.SendAsync("ReceiveMessage", $"removeData:{epc}");
        }
        public async Task Request()
        {
            await Clients.All.SendAsync("ReceiveMessage", "request");
        }
        public async Task ClearAllData()
        {
            await Clients.All.SendAsync("ReceiveMessage", "clearAllData");
        }
        public async Task StartScan()
        {
            await Clients.All.SendAsync("ReceiveMessage", "StartScan");
        }
        public async Task StopScan()
        {
            await Clients.All.SendAsync("ReceiveMessage", "StopScan");
        }


    }
}
