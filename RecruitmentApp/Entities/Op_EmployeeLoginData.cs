using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentApp.Entities
{
    public class Op_EmployeeLoginData
    {  
        [ForeignKey("Op_Employee")]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string LoginEmail { get; set; }
        [Required]
        [StringLength(100)]
        public string EmployeePassword { get; set; }

        public Op_Employee Op_Employee { get; set; }

    }
}
