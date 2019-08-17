using System;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Mvc;


namespace Ctf.Areas.Admin
{
	public class AdminChatHub : Hub
	{
		public AdminChatHub(IUrlHelper url) => Url = url;
		private readonly IUrlHelper Url;
		public const string ReceiveMessage = "ReceiveMessage";
		public const string AdminOnline = "SignalAdminOnline";

		// Admin signals
		public const string ClientConnected = "ClientConnected";
		public const string ClientDisconnected = "ClientDisconnected";

		public async Task SendMessage(string message)
		{
			await Clients.Group("Admin").SendAsync(ReceiveMessage, Context.UserIdentifier, message);
		}
		public async Task ReplyFromAdmin(string connectionId, string message)
		{
			if (Context.User.FindFirstValue(ClaimTypes.Role) == "Admin")
			{
				await Clients.Client(connectionId).SendAsync(ReceiveMessage, "Admin", message);
			}
		}
		public async Task SignalAdminOnline()
		{
			if (Context.User.FindFirstValue(ClaimTypes.Role) == "Admin")
				await Clients.All.SendAsync(AdminOnline);
		}
		public override async Task OnConnectedAsync()
		{
			if (Context.User.FindFirstValue(ClaimTypes.Role) == "Admin")
			{
				await Groups.AddToGroupAsync(Context.ConnectionId, "Admin");
				await Clients.Caller.SendAsync(ReceiveMessage, "", "Du ble koblet til som Admin");
			}
			else
			{
				var iframeSrc = Url.Action("Admin", "Admin", new { Area = "Admin" });
				await Clients.Group("Admin").SendAsync(ClientConnected, iframeSrc, Context.ConnectionId);
			}

		}
		public override async Task OnDisconnectedAsync(Exception e)
		{
			await Clients.Group("Admin").SendAsync(ClientDisconnected, Context.ConnectionId);
		}
	}
}