using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecruitmentApp.Entities;
using RecruitmentApp.Models;
using RecruitmentApp.Repository;

namespace RecruitmentApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICompanyRepo compRep;
        private readonly IEmployeeRepo empRep;
        private readonly IEmployeeLoginDataRepo eldRep;
        private readonly ICompanyDepartmentRepo compDepRep;

        public AdminController(ICompanyRepo compRep, IEmployeeRepo empRep,IEmployeeLoginDataRepo eldRep, ICompanyDepartmentRepo compDepRep)
        {
            this.compRep = compRep;
            this.empRep = empRep;
            this.eldRep = eldRep;
            this.compDepRep = compDepRep;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void CompanyNameEdit(int id, string newCompName)  // api
        {

            compRep.EditCompay(id, newCompName);

        }

        public IActionResult HRDirectorCreation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult HRDirectorCreation(HRDirectorCreationVM data)
        {
            
            var compId = compRep.GetCompanyId(data.CompanyName);
            Op_Employee emp = new Op_Employee();

            emp.Name = data.Name;
            emp.PhoneNumber = "0000";
            emp.Email = data.Email;
            emp.Address = "0000";
            emp.UniversityName = "0000";
            emp.UniversityMajor = "0000";
            emp.GraduationYear = 0;
            emp.LinkedInAccount = "0000";
            emp.CompanyId = compId;
            emp.DepartmentName = "HR";
            emp.EmployeePosition = "HR Director";
            emp.HiringDate = DateTime.Today;
            emp.EmployeeStatusId = 1;
            emp.Comment = "0000";
            emp.EmployeeTypeId = 2;

            empRep.AddEmployee(emp);
            emp = empRep.GetEmployee(data.Email, data.Email, data.Email);
            Op_EmployeeLoginData eld = new Op_EmployeeLoginData();
            eld.Id = emp.Id;
            eld.LoginEmail = emp.Email;
            eld.EmployeePassword = data.Password;
            eldRep.AddEmployeeLoginData(eld);

            return RedirectToAction("index", "admin");
        }


        public IActionResult CompanyCreation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CompanyCreation(CompanyCreationVM comp)
        {
            Lk_Company newComp = new Lk_Company();
            newComp.CompanyName = comp.companyName;
            compRep.AddCompany(newComp);
            return RedirectToAction("index", "admin");
        }


       
        
        public IActionResult DepartmentsDisplay()
        {
            return View();
        }


       
        public IActionResult DepartmentCreation()
        {
            return View();
        }


        [HttpPost]
        public void DepartmentNameEdit(int compId, string oldDepName, string newDepName)
        {
            compDepRep.EditCompanyDepartment(compId, oldDepName, newDepName);
        }



        [HttpPost]
        public void DepartmentCreationService(int compId, string depName) // api
        {
            Lk_Company_Department cd = new Lk_Company_Department();
            cd.CompanyId = compId;
            cd.DepartmentName = depName;
            compDepRep.AddCompanyDepartment(cd);
        }


        [HttpPost]
        public void DeleteHRDirctorAccess(int empId)
        {
            empRep.UpdateEmployeeType(empId, 4);
            empRep.DeleteEmployeeLoginData(empId);

        }

    }
}
