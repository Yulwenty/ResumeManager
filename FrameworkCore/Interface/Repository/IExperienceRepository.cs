using FrameworkCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.Interface.Repository
{
    public interface IExperienceRepository
    {
        void DeleteExperience(Experience exp);
        Experience GetExperienceById(string applicantId, string experienceId);
    }
}
