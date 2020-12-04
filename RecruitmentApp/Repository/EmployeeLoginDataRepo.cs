using RecruitmentApp.Container;
using RecruitmentApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentApp.Repository
{
    public class EmployeeLoginDataRepo : IEmployeeLoginDataRepo
    {
        private readonly dbContainer db;

        public EmployeeLoginDataRepo(dbContainer db)
        {
            this.db = db;
        }

        public bool AddEmployeeLoginData(Op_EmployeeLoginData eld)
        {
            try
            {
                db.EmployeeLoginDatas.Add(eld);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public Op_Employee EmployeeLoginChecker(string email, string password)
        {
            try
            {
                var eld = db.EmployeeLoginDatas.SingleOrDefault(a => a.LoginEmail == email && a.EmployeePassword == password);
                if (eld == default(Op_EmployeeLoginData)) return default(Op_Employee);
                else return db.Employees.SingleOrDefault(a => a.Id == eld.Id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return default(Op_Employee);
            }

        }
    }
}
