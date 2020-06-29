using Microsoft.AspNetCore.SignalR;
using PalletSystem.Core.Pallet.Constant;
using System.Threading.Tasks;

namespace PalletSystem.Core.Pallet.StatusHub
{
    public class PalletStatusHub : Hub
    {
        public async Task ActualStatusUpdate(PalletStatus status)
        {
            if (Clients == null) return;
            await Clients.All.SendAsync(nameof(ActualStatusUpdate), status);
        }
    }
}