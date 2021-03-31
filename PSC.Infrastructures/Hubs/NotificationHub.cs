using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace PSC.Infrastructures.Hubs
{
    /// <summary>
    /// Class NotificationHub.
    /// Implements the <see cref="Microsoft.AspNetCore.SignalR.Hub" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.SignalR.Hub" />
    public class NotificationHub : Hub
    {
        /// <summary>
        /// Sends the specified user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="message">The message.</param>
        public async Task Send(string userId, string title, string message)
        {
            await Clients.All.SendAsync("Send", userId, title, message);
        }
    }
}