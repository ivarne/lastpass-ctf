using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ctf.Models;

namespace Ctf.Areas.Todo{
    [Area("Todo")]
    public class TodoController : Controller{
        public IActionResult Index(){
            return View(new TodoViewModel( new Todo[]{}));
        }
    }
}