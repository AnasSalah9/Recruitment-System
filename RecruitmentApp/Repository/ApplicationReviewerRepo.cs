using RecruitmentApp.Container;
using RecruitmentApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentApp.Repository
{
    public class ApplicationReviewerRepo : IApplicationReviewerRepo
    {
        private readonly dbContainer db;

        public ApplicationReviewerRepo(dbContainer db)
        {
            this.db = db;
        }

        public bool AddApplicationReviewer(Op_ApplicationReviewer applicationReviewer)
        {
            try
            {
                db.ApplicationReviewers.Add(applicationReviewer);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
