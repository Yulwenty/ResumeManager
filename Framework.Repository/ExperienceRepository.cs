using FrameworkCore.Interface.Repository;
using FrameworkCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Repository
{
    public class ExperienceRepository: IExperienceRepository
    {

        public void DeleteExperience(Experience exp)
        {
            using (var db = new ResumeContext())
            {
                db.Experiences.Remove(exp);
            }
        }

        public Experience GetExperienceById(string applicantId, string experienceId )
        {
            using (var db = new ResumeContext())
            {
               return db.Experiences.SingleOrDefault(x => x.ApplicantId == applicantId && x.ExperienceId == experienceId);
            }
        }
    }
}
