using RecruitmentApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentApp.Repository
{
    public interface IEmployeeLoginDataRepo
    {
        bool AddEmployeeLoginData(Op_EmployeeLoginData eld);

        Op_Employee EmployeeLoginChecker(string email, string password);
    }
}
