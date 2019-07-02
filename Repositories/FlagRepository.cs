using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ctf.Models.BuisinesModels;

namespace Ctf.Repositories{
    public class FlagRepository{
        public string GetFlag(Quest quest){
            return "CTF{Det_har_ikke_blitt_satt_noe_flagg_ennå}";
       }
    }
}