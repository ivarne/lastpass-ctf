using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ctf.Models;
using Ctf.Repositories;

namespace Ctf.Areas.Todo{
    [Area("Todo")]
    public class TodoController : Controller{
        public TodoController(TodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }
        private readonly TodoRepository _todoRepository;
        public IActionResult Index(){
            return View(new TodoViewModel( new Todo[]{}));
        }
        [HttpPost]
        public IActionResult Todo(TodoDto todo){
            
            return RedirectToAction("Index");
        }
    }
}