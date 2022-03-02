using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.Model
{
    public class AppAutoNumber
    {
        [Key,Column(Order=0)]
        [StringLength(20)]
        public string SRAutoNumber { get; set; }
        [Key, Column(Order = 1)]
        public System.DateTime EffectiveDate { get; set; }

        [StringLength(5)]
        public string Prefik { get; set; }

        [StringLength(1)]
        public string SeparatorAfterPrefik { get; set; }
      
        public Nullable<int> YearDigit { get; set; }

        [StringLength(20)]
        public string SeparatorAfterYear { get; set; }
        public Nullable<int> NumberLength { get; set; }
        public Nullable<System.DateTime> LastUpdateDateTime { get; set; }


        [StringLength(30)]
        public string LastUpdateByUser { get; set; }
    }
}
