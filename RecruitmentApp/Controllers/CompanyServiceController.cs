using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecruitmentApp.Entities;
using RecruitmentApp.Models;
using RecruitmentApp.Repository;

namespace RecruitmentApp.Controllers
{


    [Route("api/company")]
    [ApiController]
    public class CompanyServiceController : ControllerBase
    {
        private readonly ICompanyRepo compRep;

        public CompanyServiceController(ICompanyRepo compRep)
        {
            this.compRep = compRep;
        }


        [HttpGet]
        public IActionResult GetAllCompanies()
        {
            return Ok(compRep.GetAllCompanies());

        }

        [HttpGet("{id}")]
        public IActionResult GetCompany(int id)
        {
            return Ok(compRep.GetCompany(id));

        }

    }
}
