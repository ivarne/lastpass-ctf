using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ctf.Models;

namespace Ctf.Areas.Intro{
    [Area("Intro")]
    public class HomeController : Controller{
        public IActionResult Index(){
            return View(new IndexViewModel( "this_is_your_first_flag"));
        }
    }
}