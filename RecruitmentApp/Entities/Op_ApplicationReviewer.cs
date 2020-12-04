using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentApp.Entities
{
    public class Op_ApplicationReviewer
    {   
        [Column(Order =0), ForeignKey("Op_Application")]
        public int ApplicationId { get; set; }
        [Column(Order = 1), ForeignKey("Op_Employee")]
        public int ReviewerId { get; set; }
        [Column(Order = 2), ForeignKey("Sys_Phase")]
        public int PhaseId { get; set; }
        //both are PK & FK

        public Op_Application Op_Application { get; set; }
        public Op_Employee Op_Employee { get; set; }
        public Sys_Phase Sys_Phase { get; set; }
    }
}
