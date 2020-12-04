using RecruitmentApp.Container;
using RecruitmentApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentApp.Repository
{
    public class JobsRepo : IJobsRepo
    {
        private readonly dbContainer db;

        public JobsRepo(dbContainer db)
        {
            this.db = db;
        }

        public bool AddJob(Op_Jobs job)
        {
            try
            {
                db.Jobs.Add(job);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool DeleteJob(Op_Jobs job)
        {

            try
            {
                db.Jobs.Remove(job);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool EditJob(Op_Jobs newJob)
        {
            try
            {
                var oldData = db.Jobs.Find(newJob.Id);
                oldData = newJob;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public IEnumerable<Op_Jobs> GetAllJobs()
        {
            return db.Jobs.Select(j => j);
        }

        public string GetJobDescription(int jobId)
        {
            var job = db.Jobs.SingleOrDefault(a => a.Id == jobId);

            return job.JobDescribtion;
        }

        public string GetJobName(int jobId)
        {
            var job = db.Jobs.SingleOrDefault(a => a.Id == jobId);
            return job.Position;
        }
    }
}
