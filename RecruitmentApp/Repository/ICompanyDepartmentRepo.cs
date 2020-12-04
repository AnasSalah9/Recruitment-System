using RecruitmentApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentApp.Repository
{
    public interface ICompanyDepartmentRepo
    {
        bool AddCompanyDepartment(Lk_Company_Department companyDepartment);

        bool EditCompanyDepartment(int compId, string oldDepName, string newDepName);


        bool DeleteCompanyDepartment(Lk_Company_Department companyDepartment);
        
    }
}
