using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentApp.Entities
{
    public class Op_Jobs
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string DepartmentName { get; set; }
        [Required]
        [StringLength(50)]
        public string Position { get; set; }
        [StringLength(500)]
        public string JobDescribtion { get; set; }


        [ForeignKey("CompanyId,DepartmentName")]
        public Lk_Company_Department Lk_Company_Department { get; set; }
    }
}
