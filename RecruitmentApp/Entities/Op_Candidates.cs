using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentApp.Entities
{
    public class Op_Candidates
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        [Required]
        [StringLength(100)]
        public string UniversityName { get; set; }
        [Required]
        [StringLength(100)]
        public string UniversityMajor { get; set; }
        [Required]
        public int GraduationYear { get; set; }
        [Required]
        [StringLength(15)]
        public string Phone { get; set; }
       
        [StringLength(150)]
        public string LinkedInAccount { get; set; }
        [Required]
        [StringLength(100)]
        public string Address { get; set; }
        //FK
        

       

    }
}
