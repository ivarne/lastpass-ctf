using System;

namespace Ctf.Models.BuisinesModels{

    public class Quest{
        public Quest(Guid Id, string Name, int Points, string Description, string Area, string Controller = "Home")
        {
            this.Id = Id;
            this.Name = Name;
            this.Points = Points;
            this.Description = Description;
            this.Area = Area;
            this.Controller = Controller;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public string Description {get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
    }
}