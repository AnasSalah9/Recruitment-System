using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentApp.Entities
{
    public class Op_ApplicationPhaseComment
    {
        [Column(Order =0) , ForeignKey("Op_Application")]
        public int ApplicationId { get; set; }
        [Column(Order =1), ForeignKey("Sys_Phase")]
        public int PhaseId { get; set; }
        [StringLength(100)]
        public string PhaseTask { get; set; }
        [StringLength(100)]
        public string Comment { get; set; }

        
        public Op_Application Op_Application { get; set; }
        public Sys_Phase Sys_Phase { get; set; }
    }
}
