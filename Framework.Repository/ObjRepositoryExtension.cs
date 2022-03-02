using FrameworkCore.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Repository
{
    public class ObjRepositoryExtension
    {
        public static IApplicantRepository CreateInstanceApplicantRepository()
        {
            return new ApplicantRepository();
        }

        public static IExperienceRepository CreateInstanceExperienceRepository()
        {
            return new ExperienceRepository();
        }

        public static IAppAutoNumberRepository CreateInstanceAppAutoNumberRepository()
        {
            return new AppAutoNumberRepository();
        }

        public static IAppAutoNumberLastRepository CreateInstanceAppAutoNumberLastRepository()
        {
            return new AppAutoNumberLastRepository();
        }
    }
}
