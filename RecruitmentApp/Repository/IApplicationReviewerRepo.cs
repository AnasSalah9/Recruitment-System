using RecruitmentApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentApp.Repository
{
    public interface IApplicationReviewerRepo
    {
        bool AddApplicationReviewer(Op_ApplicationReviewer applicationReviewer);

    }
}
