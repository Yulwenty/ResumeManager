using Framework.Repository.Interface;
using FrameworkCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Repository
{
    public class UnitOfWork : IDisposable
    {
        public ResumeContext context = new ResumeContext();
        private IGenericRepository<Applicant> applicantRepository;
        private IGenericRepository<Experience> experienceRepository;
        private IGenericRepository<AppAutoNumber> appAutoNumberRepository;
        private IGenericRepository<AppAutoNumberLast> appAutoNumberLastRepository;
        private IGenericRepository<User> userRepository;
        private IGenericRepository<Menu_List> menuListRepository;

        public IGenericRepository<Applicant> ApplicantRepository
        {
            get
            {
                if(this.applicantRepository == null)
                {
                    this.applicantRepository = new GenericRepository<Applicant>(context);
                }
                return this.applicantRepository;
            }
        }

        public IGenericRepository<Experience> ExperienceRepository
        {
            get
            {
                if(this.experienceRepository == null)
                {
                    this.experienceRepository = new GenericRepository<Experience>(context);
                }
                return this.experienceRepository;
            }
        }

        public IGenericRepository<AppAutoNumber> AppAutoNumberRepository
        {
            get
            {
                if (this.appAutoNumberRepository == null)
                {
                    this.appAutoNumberRepository = new GenericRepository<AppAutoNumber>(context);
                }
                return this.appAutoNumberRepository;
            }
        }

        public IGenericRepository<AppAutoNumberLast> AppAutoNumberLastRepository
        {
            get
            {
                if (this.appAutoNumberLastRepository == null)
                {
                    this.appAutoNumberLastRepository = new GenericRepository<AppAutoNumberLast>(context);
                }
                return this.appAutoNumberLastRepository;
            }
        }

        public IGenericRepository<User> UserRepository
        {
            get
            {
                if(this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(context);
                }
                return this.userRepository;
            }
        }

        public IGenericRepository<Menu_List> MenuListRepository
        {
            get
            {
                if(this.menuListRepository == null)
                {
                    this.menuListRepository = new GenericRepository<Menu_List>(context);
                }
                return this.menuListRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    context.Dispose();
                }
            }

            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
