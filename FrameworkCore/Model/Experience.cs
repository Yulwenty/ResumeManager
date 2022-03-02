using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.Model
{
    public class Experience
    {
        [Key,Column(Order =0)]
        [StringLength(3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ExperienceId { get; set; }

        [Key,Column(Order =1)]
        [ForeignKey("Applicant")]
        public string ApplicantId { get; set; } // important

        [StringLength(30)]
        public string CompanyName { get; set; }

        [StringLength(50)]
        public string Designation { get; set; }

        [Required]
        public int YearsWorked { get; set; }

        public virtual Applicant Applicant { get; set; } //important

    }
}
