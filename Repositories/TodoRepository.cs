using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ctf.Areas.Todo;

namespace Ctf.Repositories
{
	public class TodoRepository
	{

		public TodoRepository(FlagRepository flagRepository)
		{
			_flagRepository = flagRepository;
			_todos = new List<Todo>();
		}
		private List<Todo> _todos;
		private FlagRepository _flagRepository;
		private async Task InitTodos()
		{
			if (_todos.Count() < 1)
			{
				_todos.Add(
					new Todo(1, await _flagRepository.GetFlag("49bdf307-510b-4429-8539-a62c6a415efc"), "")
				);
			}
		}
		public async Task<IEnumerable<Todo>> GetTodos(string team)
		{
			await InitTodos();
			return _todos.Where(t => t.Team == team);
		}
		public async Task<Todo> GetTodo(int id)
		{
			await InitTodos();
			return _todos.FirstOrDefault(t => t.Id == id);
		}
		public async Task<bool> CreateTodo(Todo todo)
		{
			await InitTodos();
			todo.Id = _todos.Count() + 1;
			_todos.Add(todo);
			return true;
		}
	}

}