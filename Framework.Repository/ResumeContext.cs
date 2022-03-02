
using FrameworkCore.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Framework.Repository
{
    public class ResumeContext: DbContext
    {

        public ResumeContext() : base("name=ResumeContext")
        {
            Database.SetInitializer<ResumeContext>(new CreateDatabaseIfNotExists<ResumeContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
       public  DbSet<Applicant> Applicants { get; set; }
       public  DbSet<Experience> Experiences { get; set; }
        public DbSet<AppAutoNumber> AppAutoNumbers { get; set; }
        public DbSet<AppAutoNumberLast> AppAutoNumberLasts { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Menu_List> Menu_Lists { get; set; }
    }
}
