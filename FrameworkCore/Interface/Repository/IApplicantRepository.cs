using FrameworkCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.Interface.Repository
{
    public interface IApplicantRepository
    {

        IEnumerable<Applicant> GetApplicants();
        Applicant GetApplicantById(string Id);
        void InsertApplicant(Applicant app);
        void UpdateApplicant(Applicant app);
       
    }
}
