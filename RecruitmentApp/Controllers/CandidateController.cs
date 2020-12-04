using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecruitmentApp.Entities;
using RecruitmentApp.Models;
using RecruitmentApp.Repository;

namespace RecruitmentApp.Controllers
{
    public class CandidateController : Controller
    {
        private readonly ICandidateRepo candRep;
        private readonly IApplicationRepo appRep;
        private readonly IJobsRepo jobsRepo;
        public CandidateController(ICandidateRepo candRep, IApplicationRepo appRep , IJobsRepo jobsRepo)
        {
            this.candRep = candRep;
            this.appRep = appRep;
            this.jobsRepo = jobsRepo;
        }

        public IActionResult Index()
        {
            ViewBag.id = HttpContext.Session.GetInt32("uid");

            return View();
        }

        public IActionResult UpdateCandidateInfo()
        {
            return View();
        
        }
        [HttpPost]
        public IActionResult UpdateCandidateInfo(UpdateCandidateInfoVM cand)
        {
            ViewBag.id = HttpContext.Session.GetInt32("uid");
            candRep.EditCandidate(ViewBag.id, cand.Name, cand.Email, cand.Password, cand.UniversityName, cand.Major, cand.GraduationYear, cand.Phone, cand.LinkedIn, cand.Address);
             
            return RedirectToAction("index", "candidate");

        }
        [HttpPost]
        public void CreateApplication(int id, int jobId) 
        {
            


            if (!(appRep.ApplicatonChecker(id, jobId)))
            {
                Op_Application app = new Op_Application();
                app.CandidateId = id;
                //System.Diagnostics.Debug.WriteLine(app.CandidateId);
                app.JobId = jobId;
                //System.Diagnostics.Debug.WriteLine(app.JobId);
                app.CurrentPhaseId = 1;
                //System.Diagnostics.Debug.WriteLine(app.CurrentPhaseId);
                app.ApplicationStatusId = 1;
                //System.Diagnostics.Debug.WriteLine(app.ApplicationStatusId);
                app.StartDate = DateTime.Today;
                //System.Diagnostics.Debug.WriteLine(app.StartDate);
                app.EndDate = DateTime.Today;
                //System.Diagnostics.Debug.WriteLine(app.EndDate);
                appRep.AddApplication(app);
            }
            

            //return RedirectToAction("ViewApplications", "candidate");
        }
        
        [HttpGet]
        public string GetJobDescribtion(int id)
        {
           
            
            return jobsRepo.GetJobDescription(id);

        }
        [HttpPost]
        public Op_Candidates GetCandidateInfo(int id)
        {
            return candRep.GetCandidate(id);
        }


        public IActionResult ViewApplications()
        {
            ViewBag.id = HttpContext.Session.GetInt32("uid");
            return View();
        }

    }
}
