using RecruitmentApp.Container;
using RecruitmentApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentApp.Repository
{
    public class CandidateRepo : ICandidateRepo
    {
        private readonly dbContainer db;

        public CandidateRepo(dbContainer db)
        {
            this.db = db;
        }

        public bool AddCandidate(Op_Candidates candidate)
        {
            try
            {
                db.Candidates.Add(candidate);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public Op_Candidates CandidateLoginChecker(string email, string password)
        {
            try
            {
                var cand = db.Candidates.SingleOrDefault(a => a.Email == email && a.Password == password);
                if (cand == default(Op_Candidates)) return default(Op_Candidates);
                else return cand;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return default(Op_Candidates);
            }

        }

        public bool EditCandidate(Op_Candidates newCandidate)
        {
            try
            {
                var oldData = db.Candidates.Find(newCandidate.Id);
                oldData = newCandidate;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool EditCandidate(int id, string Name, string Email, string Password, string UniversityName, string Major, int GraduationYear, string Phone, string LinkedIn, string Address)
        {
            try
            {
                var oldData = db.Candidates.SingleOrDefault(a => a.Id == id);
                if (!(String.IsNullOrWhiteSpace(Name)))
                    oldData.Name = Name;
                if (!(String.IsNullOrWhiteSpace(Email)))
                    oldData.Email = Email;
                if (!(String.IsNullOrWhiteSpace(Password)))
                    oldData.Password = Password;
                if (!(String.IsNullOrWhiteSpace(UniversityName)))
                    oldData.UniversityName = UniversityName;
                if (!(String.IsNullOrWhiteSpace(Major)))
                    oldData.UniversityMajor = Major;
                if (!(String.IsNullOrWhiteSpace(GraduationYear.ToString())))
                    oldData.GraduationYear = GraduationYear;
                if (!(String.IsNullOrWhiteSpace(Phone)))
                    oldData.Phone = Phone;
                if (!(String.IsNullOrWhiteSpace(LinkedIn)))
                    oldData.LinkedInAccount = LinkedIn;
                if (!(String.IsNullOrWhiteSpace(Address)))
                    oldData.Address = Address;


                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public Op_Candidates GetCandidate(int candidateId)
        {
            return db.Candidates.SingleOrDefault(a => a.Id == candidateId);
        }

        public IEnumerable<Op_Application> GetCandidateApplications(Op_Candidates candidate)
        {
            return db.Applications.Where(a => a.CandidateId == candidate.Id);
        }

        public IEnumerable<Op_Application> GetCandidateApplications(int candidateId)
        {
            return db.Applications.Where(a => a.CandidateId == candidateId);
        }

        public string GetCandidateName(int candidateId)
        {
            var cand = db.Candidates.SingleOrDefault(a => a.Id == candidateId);
            return cand.Name;
        }
    }
}
