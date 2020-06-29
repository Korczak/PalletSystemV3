using Microsoft.AspNetCore.SignalR;
using PalletSystem.Core.VirtualPallet.Constants;
using System.Threading.Tasks;

namespace PalletSystem.Core.VirtualPallet.StatusHub
{
    public class VirtualPalletStatusHub : Hub
    {
        public async Task ActualVirtualStatusUpdate(VirtualPalletStatus status)
        {
            if (Clients == null) return;
            await Clients.All.SendAsync(nameof(ActualVirtualStatusUpdate), status);
        }
    }
}