using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentApp.Entities
{
    public class Sys_EmployeeStatus
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string StatusName { get; set; }
    }
}
