using FrameworkCore.Interface.Service;
using FrameworkCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Service
{
    public class ObjServiceExtension
    {

        public static IApplicantService CreateInstanceApplicantService()
        {
            return new ApplicantService();
        }

        public static IAppAutoNumberLastService CreateInstanceAppAutoNumberLastService()
        {
            return new AppAutoNumberLastService();
        }

        public static IUserService CreateInstanceUserService()
        {
            return new UserService();
        }

      public static IMenuListService CreateInstanceMenuListService()
        {
            return new MenuListService();
        }
    }
}
