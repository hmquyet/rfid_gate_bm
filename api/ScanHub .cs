using Microsoft.AspNetCore.SignalR;

namespace api
{
    public class ScanHub : Hub
    {
        public async Task TriggerScan()
        {
            await Clients.All.SendAsync("ReceiveMessage", "StartScan");
        }
        public async Task TriggerStopScan()
        {
            await Clients.All.SendAsync("ReceiveMessage", "StopScan");
        }
        public async Task TriggerRefresh()
        {
            await Clients.All.SendAsync("ReceiveMessage", "Refresh");
        }
        public async Task Request()
        {
            await Clients.All.SendAsync("ReceiveMessage", "Request");
        }

    }
}
