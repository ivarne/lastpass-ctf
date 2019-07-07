using System.Collections.Generic;

namespace Ctf.Areas.Todo{
    public class TodoViewModel{
        public TodoViewModel(IEnumerable<Todo> Todos)
        {
            this.Todos = Todos;
        }
        public IEnumerable<Todo> Todos { get; set; }
    }
}