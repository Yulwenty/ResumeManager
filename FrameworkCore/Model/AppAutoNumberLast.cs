using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.Model
{
    public class AppAutoNumberLast
    {
        [Key,Column(Order=0)]
        [StringLength(20)]
   
        public string SRAutoNumber { get; set; }

        [Key, Column(Order = 1)]
        public System.DateTime EffectiveDate { get; set; }

        [Key, Column(Order = 2)]
        public int YearNo { get; set; }
        public Nullable<int> LastNumber { get; set; }


        [StringLength(20)]
        public string LastCompleteNumber { get; set; }
        public Nullable<System.DateTime> LastUpdateDateTime { get; set; }


        [StringLength(40)]
        public string LastUpdateByUserId { get; set; }
    }
}
