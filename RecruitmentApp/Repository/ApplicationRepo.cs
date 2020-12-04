using RecruitmentApp.Container;
using RecruitmentApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RecruitmentApp.Repository
{
    public class ApplicationRepo : IApplicationRepo
    {
        private readonly dbContainer db;

        public ApplicationRepo(dbContainer db)
        {
            this.db = db;
        }

        public bool AddApplication(Op_Application application)
        {
            try
            {
                db.Applications.Add(application);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool EditApplication(Op_Application newApplication)
        {
            try
            {
                var oldData = db.Applications.Find(newApplication.Id);
                oldData = newApplication;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

 
        public IEnumerable<Op_Application> GetCompanyRunningApplications(int companyId)
        {

            var companyJobs = db.Jobs.Where(a => a.CompanyId == companyId);

            var allApplications = db.Applications.Where(a => a.ApplicationStatusId == 1 || a.ApplicationStatusId == 4); // running Applications

            var innerJoin = allApplications.Join(
                                                    companyJobs,
                                                    app => app.JobId,
                                                    job => job.Id,
                                                    (app, job) => app
                                                 );
            return innerJoin;
        }

        public bool SetApplicationStartDate(Op_Application application)
        {
            try
            {
                application = db.Applications.Find(application.Id);
                application.StartDate = DateTime.Today;
                db.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool SetApplicationEndDate(Op_Application application)
        {
            try
            {
                application = db.Applications.Find(application.Id);
                application.EndDate = DateTime.Today;
                db.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool ApplicatonChecker(int candidateId, int jobId)
        {
            var app = db.Applications.SingleOrDefault(a => a.CandidateId == candidateId && a.JobId == jobId);
            if (app == default(Op_Application)) return false;
            else return true;
        }

        public string GetApplicationStatusName(int statusId)
        {
            var status = db.ApplicationStatuses.SingleOrDefault(a => a.Id == statusId);
            return status.StatusName;
        }

        public string GetPhaseName(int PhaseId)
        {
            var phase = db.Phases.SingleOrDefault(a => a.Id == PhaseId);
            return phase.Name;
        }
    }
}
