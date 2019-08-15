using System;

namespace Ctf.Models.BusinessModels
{

	public class Quest
	{
		public Quest(Guid Id, string Name, int Points, string Description, string Area, string Controller = "Home", bool HasFlag = true)
		{
			this.Id = Id;
			this.Name = Name;
			this.Points = Points;
			this.Description = Description;
			this.Area = Area;
			this.Controller = Controller;
			this.HasFlag = HasFlag;
		}

		public Guid Id { get; }
		public string Name { get; }
		public int Points { get; }
		public string Description { get; }
		public string Area { get; }
		public string Controller { get; }
		public bool HasFlag { get; }
	}
}