using System;
using System.ComponentModel.DataAnnotations;

namespace Ctf.Models.ViewModels{
    public class SubmitFlagViewModel{
        [Required]
        public Guid QuestId { get; set; }
        [Required]
        [RegularExpression(@"CTF\{\w*\}")]
        public string Flag { get; set; } = null!;
    }
}