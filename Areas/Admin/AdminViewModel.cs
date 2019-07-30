using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ctf.Models;

namespace Ctf.Areas.Admin{
    public class AdminViewModel{
        public AdminViewModel(string flag)
        {
            Flag = flag;
        }
        public string Flag { get; set; }
    }
}