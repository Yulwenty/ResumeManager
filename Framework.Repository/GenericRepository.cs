using Framework.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal ResumeContext _context;
        internal DbSet<TEntity> _dbSet;

        public GenericRepository(ResumeContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();

        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> OrderBy = null,
            string includeProperties = "",
            bool isNoTracking = false)
        {
            IQueryable<TEntity> query = _dbSet;

            if(isNoTracking)
            {
                query = query.AsNoTracking();
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var stringProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(stringProperty);
            }

            if (OrderBy != null)
            {
                return OrderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetById(params object[] id)
        {
            return _dbSet.Find(id);
        }


        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

      
        public virtual void SetCurrentValue(TEntity oldentity, TEntity currentEntity)
        {
            _context.Entry(oldentity).CurrentValues.SetValues(currentEntity);
        }

        public virtual void Update(TEntity entityToUpdate, params string[] excludedColumns )
        {
            if (_context.Entry(entityToUpdate).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToUpdate);
            }
           
                _context.Entry(entityToUpdate).State = EntityState.Modified;
           
                foreach(string item in excludedColumns)
                {
                _context.Entry(entityToUpdate).Property(item).IsModified = false;
                }
          
        
            //  _dbSet.AddOrUpdate(entityToUpdate);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }
    }
}
