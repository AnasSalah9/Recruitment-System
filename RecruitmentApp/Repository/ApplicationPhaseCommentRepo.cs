using RecruitmentApp.Container;
using RecruitmentApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentApp.Repository
{
    public class ApplicationPhaseCommentRepo : IApplicationPhaseCommentRepo
    {
        private readonly dbContainer db;

        public ApplicationPhaseCommentRepo(dbContainer db)
        {
            this.db = db;
        }

        public bool AddApplicationPhaseComment(Op_ApplicationPhaseComment apc)
        {
            try
            {
                db.ApplicationPhaseComments.Add(apc);
                db.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        
        public bool DeleteApplicationPhaseComment(Op_ApplicationPhaseComment apc)
        {
            try
            {
                db.ApplicationPhaseComments.Remove(apc);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        
        public bool EditApplicationPhaseComment(Op_ApplicationPhaseComment newApc)
        {
            try
            {
                var oldData = db.ApplicationPhaseComments.Find(newApc.ApplicationId, newApc.PhaseId);
                oldData = newApc;
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
