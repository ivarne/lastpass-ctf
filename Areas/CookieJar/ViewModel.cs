using System;
namespace Ctf.Areas.CookieJar
{
	public class ViewModel
	{
		public ViewModel(string flag)
		{
			Flag = flag;
		}
		public string Flag { get; set; }
	}
}