using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.Model
{
   public class Applicant
    {
        [Key]
        [StringLength(20)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; }

        [Required]
        [Range(25, 55, ErrorMessage = "Currently, We have no vacant position for your age")]
        [Display(Name = "Age in Years")]
        public int Age { get; set; }

        [Required]
        [StringLength(50)]
        public string Qualification { get; set; }

       // [Required]
      //  [Range(1, 25, ErrorMessage = "Currently, We have no vacant position for your experience")]
        [Display(Name = "Total Experience in Years")]
        public int TotalExperience { get; set; }

        public virtual List<Experience> Experiences { get; set; }
   

        //public string PhotoUrl { get; set; }

        //[Required(ErrorMessage = "Please upload the photo")]
        //[Display(Name = "Profile photo")]
        //[NotMapped]
        //public IFormFile ProfilePhoto { get; set; }
    }
}
