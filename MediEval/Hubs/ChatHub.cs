using MediEval.Data;
using MediEval.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Globalization;

namespace MediEval.Hubs
{
    public class ChatHub:Hub
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _context;
        private static Dictionary<String,Int32> _connectedUsers = new();

        public ChatHub(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        /***** Broadcast from Client *****/
        public async Task BroadcastFromClient(string message)
        {
            try
            {
                var currentUser = await _userManager.GetUserAsync(Context.User);

                //Message m = new Message()
                //{
                //    MessageBody = message,
                //    MessageDtTm = DateTime.Now,
                //    FromUser = currentUser
                //};

                //_context.Messages.Add(m);
                //await _context.SaveChangesAsync();

                await Clients.All.SendAsync(
                    "Broadcast",
                    new
                    {
                        messageBody = message,
                        fromUser = currentUser.Email,
                        messageDtTm = DateTime.Now.ToString(
                                "hh:mm tt MMM dd", CultureInfo.InvariantCulture
                            )
                    });
            }
            catch (Exception ex)
            {
                await Clients.Caller.SendAsync("HubError", new { error = ex.Message });
            }
        }
        /***** Broadcast from Client *****/

        /***Client Side Info (Connected)***/
        public override async Task OnConnectedAsync()
        {
            var user = Context.UserIdentifier;
            if(_connectedUsers.ContainsKey(user) == false)
            {

                _connectedUsers.Add(user, 1);

                await Clients.All.SendAsync(
               "UserConnected",
               new
               {
                   connectionId = user,
                   userName = Context.User.Identity.Name,
                   connectionDtTm = DateTime.Now,
                   messageDtTm = DateTime.Now.ToString(
                               "hh:mm tt MMM dd", CultureInfo.InvariantCulture
                           )
               });
            }
            else
            {
                _connectedUsers[user] += 1;
            }
        }

           
        /***Client Side Info (connected)***/


        /** Client Side Info (Disconnected) **/
        public override async Task OnDisconnectedAsync(Exception ex)
        {
            var user = Context.UserIdentifier;

            if (_connectedUsers.ContainsKey(user) == true)
            {
                var numberofCoonections = _connectedUsers[user];
                if(numberofCoonections == 1)
                {
                    await Clients.All.SendAsync("UserDisconnected",
               $"User disconnected, ConnectionId: {user}");
                    _connectedUsers.Remove(user);
                }
                else
                {
                    _connectedUsers[user] -= 1;

                }
            }

               
        }
        /** Client Side Info (Disconnected) **/

    }
}
















//private readonly AppDbContext _db;
//public ChatHub(AppDbContext db)
//{
//    _db = db;
//}

//public async Task SendMessageToAll(string user, string message)
//{
//    await Clients.All.SendAsync("MessageReceived", user, message);
//}
//[Authorize]
//public async Task SendMessageToReceiver(string sender, string receiver, string message)
//{
//    var userId = _db.Users.FirstOrDefault(u => u.Email.ToLower() == receiver.ToLower()).Id;

//    if (!string.IsNullOrEmpty(userId))
//    {
//        await Clients.User(userId).SendAsync("MessageReceived", sender, message);
//    }

//}