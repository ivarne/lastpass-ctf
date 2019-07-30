using System;
using System.ComponentModel.DataAnnotations;
using BouvetCtf.Utils;

namespace Ctf.Models.ViewModels{
    public class LoginViewModel{
        [Required]
        [MinLength(4)]
        public string? TeamName { get; set; }
        public string? AdminPassword {get{return "hidden";} set{
            if(value == null) return;
            var ph = new PasswordHasher();
            _isAdmin = ph.VerifyHashedPassword("AQAAAAEAAAPoAAAAEDPdnMnkJWGAbK9HFAwy0YIPCRIA3UV/ItVKeUolRnDKt8CidX0OUAJB5FxogUl/lw==", value);
        }}
        public bool _isAdmin {get; private set;} = false;
        
    }
}