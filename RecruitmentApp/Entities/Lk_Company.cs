using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentApp.Entities
{
    public class Lk_Company
    {

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string CompanyName { get; set; }
    }
}
