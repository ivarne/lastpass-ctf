using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ctf.Models;

namespace Ctf.Areas.Admin
{
	public class AdminViewModel
	{
		public AdminViewModel(string flag, string connectionId)
		{
			Flag = flag;
			ConnectionId = connectionId;
		}
		public string Flag { get; set; }
		public string ConnectionId { get; set; }
	}
}