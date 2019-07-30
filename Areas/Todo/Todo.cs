namespace Ctf.Areas.Todo{
    public class Todo{
        public Todo(int Id, string Description, string Team)
        {
            this.Id = Id;
            this.Description = Description;
            this.Team = Team;
        }
        public int Id { get; set; }
        public string Team{ get; set;}
        public string Description { get; set; }
    }
}