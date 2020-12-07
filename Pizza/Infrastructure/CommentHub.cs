using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Infrastructure
{
    public class CommentHub : Hub
    {
        public async Task Comment(string pizzaId, string message, string username)
        {
            await Clients.All.SendAsync("Comment", pizzaId, message, username);
        }
    }
}
