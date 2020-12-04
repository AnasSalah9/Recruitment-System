using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentApp.Entities
{
    public class Op_Application
    {
        public int Id { get; set; }
        [ForeignKey("Op_Candidates")]
        public int CandidateId { get; set; }
        [ForeignKey("Op_Jobs")]
        public int JobId { get; set; }
        //FK
        [ForeignKey("Sys_Phase")]
        public int CurrentPhaseId { get; set; }
        [ForeignKey("Sys_ApplicationStatus")]
        public int ApplicationStatusId { get; set; }
 
        //khaleehpm type date 3ashan database
        //https://entityframework.net/knowledge-base/31912326/how-to-use-date-only-as-data-type-in-entity-framework
        [Column(TypeName ="Date")]
        public DateTime StartDate  { get; set; }
        [Column(TypeName = "Date")]
        public DateTime EndDate { get; set; }

        public Sys_Phase Sys_Phase { get; set; }
        public Op_Candidates Op_Candidates { get; set; }
        public Op_Jobs Op_Jobs { get; set; }
        public Sys_ApplicationStatus Sys_ApplicationStatus { get; set; }
    }
}
