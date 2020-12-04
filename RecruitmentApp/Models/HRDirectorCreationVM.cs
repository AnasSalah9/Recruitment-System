using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentApp.Models
{
    public class HRDirectorCreationVM
    {
        public string Name { set; get; }

        public string Email { set; get; }

        public string Password { set; get; }

        public string ConfirmPassword { set; get; }

        public string CompanyName { set; get; }

    }
}
