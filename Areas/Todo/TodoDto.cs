using System;
using System.ComponentModel.DataAnnotations;
namespace Ctf.Areas.Todo{
    public class TodoDto{

        public int Id { get; set; }
        [Required]
        [MinLength(4)]
        public string? Description { get; set; }
    }
}