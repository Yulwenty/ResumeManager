using FrameworkCore.Interface.Repository;
using FrameworkCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Repository
{
    public class AppAutoNumberLastRepository: IAppAutoNumberLastRepository
    {
        public AppAutoNumberLast GetAppAutoLastNumberById(AppAutoNumber appAutoNumber)
        {
            using (var db = new ResumeContext())
            {                
               var obj= db.AppAutoNumberLasts
                .Where(x => x.SRAutoNumber == appAutoNumber.SRAutoNumber
                && x.EffectiveDate == appAutoNumber.EffectiveDate
                && x.YearNo == DateTime.Now.Year).SingleOrDefault();

                return obj;
            }
        }

        public void Insert(AppAutoNumberLast appANL)
        {
            using (var db = new ResumeContext())
            {
                db.AppAutoNumberLasts.Add(appANL);
                db.SaveChanges();
            }

           
        }

        public void Update(AppAutoNumberLast appANL)
        {
            using (var db = new ResumeContext())
            {
                db.Entry(appANL).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

         
        }
    }
}
