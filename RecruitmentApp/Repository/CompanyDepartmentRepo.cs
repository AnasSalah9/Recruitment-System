using RecruitmentApp.Container;
using RecruitmentApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentApp.Repository
{
    public class CompanyDepartmentRepo : ICompanyDepartmentRepo
    {
        private readonly dbContainer db;

        public CompanyDepartmentRepo(dbContainer db)
        {
            this.db = db;
        }

        public bool AddCompanyDepartment(Lk_Company_Department companyDepartment)
        {
            try
            {
                db.CompanyDepartments.Add(companyDepartment);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool DeleteCompanyDepartment(Lk_Company_Department companyDepartment)
        {
            try
            {
                db.CompanyDepartments.Remove(companyDepartment);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool EditCompanyDepartment(int compId, string oldDepName, string newDepName)
        {
            try
            {

                var cd = db.CompanyDepartments.Find(compId, oldDepName);
                db.CompanyDepartments.Remove(cd);
                db.SaveChanges();

                Lk_Company_Department cd2 = new Lk_Company_Department(); 
                cd2.CompanyId = compId;
                cd2.DepartmentName = newDepName;
                db.CompanyDepartments.Add(cd2);
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
