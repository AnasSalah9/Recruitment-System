using RecruitmentApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentApp.Repository
{
    public interface IJobsRepo
    {
        
        bool AddJob(Op_Jobs job);

        bool EditJob(Op_Jobs newJob);
        
        bool DeleteJob(Op_Jobs job);

        string GetJobName(int jobId);

        string GetJobDescription(int jobId);

        IEnumerable<Op_Jobs> GetAllJobs();


    }
}
