using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace PalletSystem.Core.Devices.UpdateConnections
{
    public class UpdateConnectionsHub : Hub
    {
        public async Task ConnectionUpdate()
        {
            if (Clients == null) return;
            await Clients.All.SendAsync(nameof(ConnectionUpdate));
        }
    }
}
