using RecruitmentApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentApp.Repository
{
     public interface IApplicationPhaseCommentRepo
    {
        bool AddApplicationPhaseComment(Op_ApplicationPhaseComment apc);

        bool EditApplicationPhaseComment(Op_ApplicationPhaseComment newApc);

        bool DeleteApplicationPhaseComment(Op_ApplicationPhaseComment apc);

    }
}
