using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.Model
{
    public class Menu_List
    {
        [Key]
        public int M_CODE { get; set; }
        public int? M_PARENT_CODE { get; set; }

        [StringLength(50)]
        public string M_NAME { get; set; }


        [StringLength(50)]
        public string CONTROLLER_NAME { get; set; }


        [StringLength(50)]
        public string ACTION_NAME { get; set; }

    }
}
