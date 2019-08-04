using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ctf.Models.BusinessModels;

namespace Ctf.Repositories{
    public class FlagRepository{
        public FlagRepository()
        {
            
        }
        public Task<string> GetFlag(Quest quest){
            return GetFlag(quest.Id);
        }
        public Task<string> GetFlag(string id){
            return GetFlag(Guid.Parse(id));
        }
        public Task<string> GetFlag(Guid id){
            return Task.FromResult("CTF{Det_har_ikke_blitt_satt_noe_flagg_ennå}");
        }
    }
}