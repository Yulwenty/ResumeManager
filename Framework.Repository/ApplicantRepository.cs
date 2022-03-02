using FrameworkCore.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameworkCore.Model;
using System.Data.Entity;
using Framework.Repository;

namespace Framework.Repository
{
    public class ApplicantRepository : IApplicantRepository
    {
        public IEnumerable<Applicant> GetApplicants()
        {
            using (var db = new ResumeContext())
            {
              return   db.Applicants.ToList(); 
            }
        }

        public Applicant GetApplicantById(string Id)
        {
            using(var db = new ResumeContext())
            {
                var app = new Applicant();
                app = db.Applicants.Include(x=>x.Experiences).FirstOrDefault(x => x.Id == Id);

                return app;
            }
        }
      public void InsertApplicant(Applicant app)
        {
            using (var db = new ResumeContext())
            {
                db.Applicants.Add(app);
                db.SaveChanges();
            }
        }

        public void UpdateApplicant(Applicant app)
        {
            using (var db = new ResumeContext())
            {
                var existingExp = GetApplicantById(app.Id);
                if(existingExp !=null)
                {
                    db.Entry(existingExp).CurrentValues.SetValues(app);
                    db.SaveChanges();
                }
                
            }
        }

    }
}
