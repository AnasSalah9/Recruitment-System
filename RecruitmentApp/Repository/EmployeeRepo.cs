using RecruitmentApp.Container;
using RecruitmentApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentApp.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly dbContainer db;

        public EmployeeRepo(dbContainer db)
        {
            this.db = db;
        }

        public bool AddEmployee(Op_Employee emp)
        {
            try
            {
                db.Employees.Add(emp);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool EditEmployee(Op_Employee newEmp)
        {
            try
            {
                var oldData = db.Employees.Find(newEmp.Id);
                oldData = newEmp;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public Op_Employee GetEmployee(string email, string phone, string linkedInAccount)
        {
            return db.Employees.Where(a => a.Email == email || a.PhoneNumber == phone || a.LinkedInAccount == linkedInAccount).SingleOrDefault();
        }

        public Op_Employee GetEmployeeById(int id)
        {
            return db.Employees.Where(a => a.Id == id).SingleOrDefault();
            
        }

        public IEnumerable<Op_Employee> GetAllHRDirectors()
        {
            return db.Employees.Where(a => a.EmployeeTypeId == 2);
        }

        public bool UpdateEmployeeType(int empId, int type)
        {
            try
            {
                var emp = db.Employees.Find(empId);
                emp.EmployeeTypeId = type;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }


        public bool DeleteEmployeeLoginData(int empId)
        {
            try
            {
                var ld = db.EmployeeLoginDatas.Find(empId);
                db.EmployeeLoginDatas.Remove(ld);
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
