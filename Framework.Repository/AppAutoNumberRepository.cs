using FrameworkCore.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameworkCore.Model;
using System.Data.Entity;

namespace Framework.Repository
{
    public class AppAutoNumberRepository : IAppAutoNumberRepository
    {
        public AppAutoNumber GetAppAutoNumberById(string srAutoNumber)
        {
            using (var db = new ResumeContext())
            {
            
                var appAutoNumber = db.AppAutoNumbers.Where(x => x.SRAutoNumber == srAutoNumber &&
                DbFunctions.TruncateTime(x.EffectiveDate) <= DbFunctions.TruncateTime(DateTime.Now))
                .OrderByDescending(x=>x.EffectiveDate)
                .SingleOrDefault();

                return appAutoNumber;
            }
        }

    }
}
