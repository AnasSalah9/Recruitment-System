using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Internal;
using RecruitmentApp.Container;
using RecruitmentApp.Entities;

namespace RecruitmentApp.Controllers
{
    public class RecruiterOperations : Controller
    {
        private readonly dbContainer _context;
        public RecruiterOperations(dbContainer context)
        {
            _context = context;
        }
        public IActionResult addemp()
        {
            ViewBag.CompanyId = new SelectList(_context.Companies, "Id", "CompanyName");
            ViewBag.EmployeeStatusId = new SelectList(_context.EmployeeStatuses, "Id", "StatusName");
            ViewBag.EmployeeTypeId = new SelectList(_context.EmployeeTypes, "Id", "TypeName");
            ViewBag.DepartmentName= new SelectList(_context.CompanyDepartments, "DepartmentName", "DepartmentName");
            return View();
        }
        [HttpPost]
        public  IActionResult addemp(Op_Employee Op_Employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(Op_Employee);
                _context.SaveChanges();
                return RedirectToAction("Login", "Account");
            }
            return View(Op_Employee);
        }
        public IActionResult EditEmp(int? Id)
        {
            if (Id!=null)
            {
                ViewBag.CompanyId = new SelectList(_context.Companies, "Id", "CompanyName");
                ViewBag.EmployeeStatusId = new SelectList(_context.EmployeeStatuses, "Id", "StatusName");
                ViewBag.EmployeeTypeId = new SelectList(_context.EmployeeTypes, "Id", "TypeName");
                ViewBag.DepartmentName = new SelectList(_context.CompanyDepartments, "DepartmentName", "DepartmentName");

                var emp = _context.Employees.Find(Id);
                return View(emp);
            }
            return View();
        }
        [HttpPost]
        public IActionResult EditEmp(Op_Employee op_Employee)
        {
            if(op_Employee != null)
            {
            _context.Employees.Update(op_Employee);
                _context.SaveChanges();
                return RedirectToAction("FindEmployees", "RecruiterOperations");
            }
            return View();

        }
        public IActionResult FindEmployees()
        {
            return View();
        }
        public string test()
        {

            return (_context.Companies.FirstOrDefault().CompanyName);
        }
        public JsonResult getEmpData(string searchWord)
        {
            var data = (from emp in _context.Employees
                        join comp in _context.Companies on emp.CompanyId equals comp.Id
                        join status in _context.EmployeeStatuses on emp.EmployeeStatusId equals status.Id
                        join empType in _context.EmployeeTypes on emp.EmployeeTypeId equals empType.Id
                        where emp.Name.Contains(searchWord) || emp.PhoneNumber.Contains(searchWord)||emp.Email.Contains(searchWord)||comp.CompanyName.Contains(searchWord)
                        select new
                        {
                            empType="Employee",
                            empId=emp.Id,
                            empName=emp.Name,
                            empPos=emp.EmployeePosition,
                            empComm=emp.Comment,
                            empPhone=emp.PhoneNumber,
                            empComp=comp.CompanyName,
                            empStatus=status.StatusName
                        });
            return Json(data);
        }
        public IActionResult FindCandidate()
        {
            return View();
        }
        public JsonResult getCandData(string searchWord)
        {
            var data = (from cand in _context.Candidates                      
                        where cand.Name.Contains(searchWord) || cand.Phone.Contains(searchWord) || cand.Email.Contains(searchWord) 
                        select new
                        {
                            candId = cand.Id,
                            candName = cand.Name,
                            candPhone = cand.Phone,
                            candEmail = cand.Email,
                            candLinkedIn = cand.LinkedInAccount

                        });
            return Json(data);
        }
        public JsonResult getAllCandData()
        {
            var data = (from cand in _context.Candidates
                        select new
                        {
                            candId = cand.Id,
                            candName = cand.Name,
                            candPhone = cand.Phone,
                            candEmail = cand.Email,
                            candLinkedIn = cand.LinkedInAccount

                        });
            return Json(data);
        }

        public IActionResult ViewApplication(int candId)
        {
            ViewBag.candId = candId;
            ViewBag.phases = _context.Phases.ToList();
            if (_context.Applications.Where(a => a.CandidateId == candId).Count() == 0)
            {
                
                return RedirectToAction("FindCandidate", "RecruiterOperations");
            }

            return View();
        }
        public JsonResult getApplicationData(int candId)
        {
            var data = (from app in _context.Applications
                        join job in _context.Jobs on app.JobId equals job.Id
                        join phase in _context.Phases on app.CurrentPhaseId equals phase.Id
                        where app.CandidateId.Equals(candId)                        
                        select new
                        {
                            appId = app.Id,
                            jobPos = job.Position,
                            jobDesc=job.JobDescribtion,
                            jobDepart=job.DepartmentName,
                            phaseName = phase.Name

                        });
            return Json(data);
        }
        public string addPhase(string phaseTask,string phaseComment,int phaseId,int appId)
        {
            try
            {
                Op_ApplicationPhaseComment phComm = new Op_ApplicationPhaseComment();
                phComm.ApplicationId = appId;
                phComm.PhaseId = phaseId;
                phComm.PhaseTask = phaseTask;
                phComm.Comment = phaseComment;

                _context.ApplicationPhaseComments.Add(phComm);
                _context.Applications.Where(a => a.Id == appId).FirstOrDefault().CurrentPhaseId = phaseId;
                _context.SaveChanges();
                return "Phase has been added";

            }
            catch (Exception)
            {
                return "Phase is already found for this application";

            }

        }

        public JsonResult getPhasesForApp(int appId)
        {
            var data = (from phasecom in _context.ApplicationPhaseComments
                        join phase in _context.Phases on phasecom.PhaseId equals phase.Id
                        where phasecom.ApplicationId.Equals(appId)
                        select new
                        {
                            phaseName = phase.Name,
                            phaseTask = phasecom.PhaseTask,
                            phaseComm = phasecom.Comment
                        });
            return Json(data);
        }
        public IActionResult Home()
        {
            return View();
        }
    }
}
