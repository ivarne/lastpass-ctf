using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ctf.Models;

namespace Ctf.Areas.Admin{
    [Area("Admin")]
    public class AdminController : Controller{
        public IActionResult Index(){
            return View(new AdminViewModel( "this_is_your_first_flag"));
        }
    }
}