using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentApp.Entities
{
    public class Lk_Company_Department
    {   //PK FK
        [Column(Order = 0), ForeignKey("Lk_Company")]
        public int CompanyId { get; set; }
        //PK FK
        [Column(Order = 1)]
        public string DepartmentName { get; set; }

        public Lk_Company Lk_Company { get; set; }
        

    }
}
