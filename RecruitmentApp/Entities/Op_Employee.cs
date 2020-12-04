using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentApp.Entities
{

    public class Op_Employee
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string Address { get; set; }
        [StringLength(100)]
        public string UniversityName { get; set; }
        [StringLength(100)]
        public string UniversityMajor { get; set; }
        public int GraduationYear { get; set; }
        [StringLength(150)]
        public string LinkedInAccount { get; set; }
        //FK

        public int CompanyId { get; set; }
        //FK
        
        public string DepartmentName { get; set; }
        [Required]
        [StringLength(100)]
        public string EmployeePosition { get; set; }
        [Column(TypeName = "Date")]
        [Required]
        public DateTime HiringDate { get; set; }
        //FK
        [ForeignKey("Sys_EmployeeStatus")]
        public int EmployeeStatusId { get; set; }
        [StringLength(100)]
        public string Comment { get; set; }
        [ForeignKey("Sys_EmployeeType")]
        public int EmployeeTypeId { get; set; }

        [ForeignKey("CompanyId,DepartmentName")]
        public Lk_Company_Department Lk_Company_Department { get; set; }
        public Sys_EmployeeStatus Sys_EmployeeStatus { get; set; }

        public Sys_EmployeeType Sys_EmployeeType { get; set; }
    }
}
