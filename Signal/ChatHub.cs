using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rc_tutors.Signal
{
    public class ChatHub : Hub
    {
        // This is the collection you'll use to track connected users
        private static ConcurrentDictionary<string, bool> _connectedUsers = new ConcurrentDictionary<string, bool>();

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task UpdateUserList(List<string> users)
        {
            await Clients.All.SendAsync("UpdateUserList", users);
        }

        public override async Task OnConnectedAsync()
        {
            _connectedUsers[Context.UserIdentifier] = true;
            await UpdateUserList(GetConnectedUsers());
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            bool removed;
            _connectedUsers.TryRemove(Context.UserIdentifier, out removed);
            await UpdateUserList(GetConnectedUsers());
            await base.OnDisconnectedAsync(exception);
        }

        private List<string> GetConnectedUsers()
        {
            // Get the user identifier associated with the current connection
            var currentUserId = Context.UserIdentifier;

            // Get all user identifiers
            var allUserIds = _connectedUsers.Keys;

            // Exclude the current user identifier
            var otherUserIds = allUserIds.Where(id => id != currentUserId);

            return otherUserIds.ToList();
        }
    }
}
