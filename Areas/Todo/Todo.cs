namespace Ctf.Areas.Todo{
    public class Todo{
        public Todo(int Id, string Description)
        {
            this.Id = Id;
            this.Description = Description;
        }
        public int Id { get; set; }
        public string Description { get; set; }
    }
}