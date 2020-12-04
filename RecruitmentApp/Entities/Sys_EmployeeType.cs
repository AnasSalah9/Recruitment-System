using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace RecruitmentApp.Entities
{
    public class Sys_EmployeeType
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string TypeName { get; set; }
    }
}
