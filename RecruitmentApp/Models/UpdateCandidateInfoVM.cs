using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentApp.Models
{
    public class UpdateCandidateInfoVM
    {
        public string Name { set; get; }

        public string Email { set; get; }

        public string Password { set; get; }

        public string UniversityName { get; set; }
        public string Major { get; set; }
        public int GraduationYear { get; set; }
        public string Phone { get; set; }
        public string LinkedIn { get; set; }
        public string Address { get; set; }

    }
}
