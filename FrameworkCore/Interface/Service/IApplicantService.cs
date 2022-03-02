using FrameworkCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.Interface.Service
{
    public interface IApplicantService
    {
        IEnumerable<Applicant> GetApplicants();
        void InsertApplicant(Applicant app);
        void GenerateIdforExperiences(Applicant applicant);
        Applicant GetApplicantById(string Id);

        void UpdateApplicant(Applicant applicant);

        void Dispose();
    }
}
