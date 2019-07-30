using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ctf.Models.BuisinesModels;

namespace Ctf.Repositories{
    public abstract class FlagRepository{
        public Task<string> GetFlag(Quest quest){
            return GetFlag(quest.Id);
        }
        public Task<string> GetFlag(string id){
            return GetFlag(Guid.Parse(id));
        }
        public abstract Task<string> GetFlag(Guid id);
    }

    public class LocalFlagRepository: FlagRepository{
        public override Task<string> GetFlag(Guid id){
            return Task.FromResult("CTF{Det_har_ikke_blitt_satt_noe_flagg_ennå}");
        }
    }
    public class AzureKeyVaultFlagRepository : FlagRepository
    {
        public override Task<string> GetFlag(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}