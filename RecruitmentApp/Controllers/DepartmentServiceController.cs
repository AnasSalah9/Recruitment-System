using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecruitmentApp.Repository;

namespace RecruitmentApp.Controllers
{
    [Route("api/department")]
    [ApiController]
    public class DepartmentServiceController : ControllerBase
    {
        private readonly ICompanyRepo compRep;

        public DepartmentServiceController(ICompanyRepo compRep)
        {
            this.compRep = compRep;
        }


        [HttpGet("{id}")]
        public IActionResult GetCompanyDepartments(int id)
        {
            return Ok(compRep.GetCompanyDepartments(id));

        }



    }
}
