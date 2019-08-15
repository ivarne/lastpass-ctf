using System;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;


namespace Ctf.Areas.Admin{
    public static class AdminChatHubConsts{

    }
    public class AdminChatHub: Hub{
        public const string ReceiveMessage = "ReceiveMessage";
        public const string AdminOnline = "SignalAdminOnline";

        public async Task SendMessageToAdmin(string message)
        {
            await Clients.Group("Admin").SendAsync(ReceiveMessage, Context.UserIdentifier, message);
        }
        public async Task ReplyFromAdmin(string user, string message){
            if(Context.User.FindFirstValue(ClaimTypes.Role) == "Admin"){
                await Clients.Group(user).SendAsync(ReceiveMessage, "Admin", message);
            }
        }
        public async Task SignalAdminOnline(){
            if(Context.User.FindFirstValue(ClaimTypes.Role) == "Admin")
                await Clients.All.SendAsync(AdminOnline);
        }
        public override async Task OnConnectedAsync(){
            if(Context.User.FindFirstValue(ClaimTypes.Role) == "Admin"){
                await Groups.AddToGroupAsync(Context.ConnectionId,"Admin");
                await Clients.Caller.SendAsync(ReceiveMessage, "", "Du ble koblet til som Admin");
            }
            else if(Context.UserIdentifier == "Admin")
            {
                await Clients.Caller.SendAsync(ReceiveMessage,"Du kan ikke bruke denne oppgaven med username Admin");
                Context.Abort();
            }
            else
            {
                await Clients.Caller.SendAsync(ReceiveMessage,"", "Du ble koblet til");
            }

        }
    }
}