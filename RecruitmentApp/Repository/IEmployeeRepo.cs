using RecruitmentApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentApp.Repository
{
    public interface IEmployeeRepo
    {

        bool AddEmployee(Op_Employee emp);
        
        bool EditEmployee(Op_Employee newEmp);
        
        Op_Employee GetEmployeeById(int id);
        
        Op_Employee GetEmployee(string email, string phone, string linkedInAccount);

        IEnumerable<Op_Employee> GetAllHRDirectors();

        bool UpdateEmployeeType(int empId, int type);

        bool DeleteEmployeeLoginData(int empId);
    }
}
