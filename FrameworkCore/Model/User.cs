using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.Model
{
    public class User
    {
        [Key]
        [StringLength(25)]
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
