using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Ctf.Models;
using Ctf.Repositories;

namespace Ctf.Areas.Todo
{
	[Area("Todo")]
	public class TodoController : Controller
	{
		public TodoController(TodoRepository todoRepository)
		{
			_todoRepository = todoRepository;
		}
		private readonly TodoRepository _todoRepository;
		public async Task<IActionResult> Index()
		{
			return View(new TodoViewModel(await _todoRepository.GetTodos((User.Identity.IsAuthenticated ? User.Identity.Name : null) ?? "Public")));
		}
		[Authorize]
		[HttpPost]
		public async Task<IActionResult> Todo(TodoDto todo)
		{
			if (ModelState.IsValid)
			{
				await _todoRepository.CreateTodo(new Todo(0, todo.Description ?? "", User.Identity.Name!));
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Show(int id)
		{
			return View(await _todoRepository.GetTodo(id));
		}
	}
}