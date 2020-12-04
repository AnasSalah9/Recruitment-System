using RecruitmentApp.Container;
using RecruitmentApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RecruitmentApp.Repository
{
    public class CompanyRepo : ICompanyRepo
    {
        private readonly dbContainer db;

        public CompanyRepo(dbContainer db)
        {
            this.db = db;
        }

        public bool AddCompany(Lk_Company company)
        {
            try
            {
                db.Companies.Add(company);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool DeleteCompany(Lk_Company company)
        {
            try
            {
                db.Companies.Remove(company);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }


        public bool EditCompay(int id, string newCompName)
        {
            try
            {
                var oldData = db.Companies.SingleOrDefault(a => a.Id == id);
                oldData.CompanyName = newCompName;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }


        public int GetCompanyId(string companyName)
        {
            var comp = db.Companies.SingleOrDefault(a => a.CompanyName == companyName);
            return comp.Id;
        }

        public IEnumerable<Lk_Company> GetAllCompanies()
        {
            return db.Companies.Select(a => a);
        }

        public Lk_Company GetCompany(int Id)
        {
            return db.Companies.Find(Id);
        }


        public IEnumerable<string> GetCompanyDepartments(int id)
        {
            return db.CompanyDepartments.Where(a => a.CompanyId == id).Select(a => a.DepartmentName);

        }

        public string GetCompanyName(int companyId)
        {
            var comp = db.Companies.SingleOrDefault(a => a.Id == companyId);
            return comp.CompanyName;
        }
    }
}
