using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Repository.Interface
{
    public interface IGenericRepository<TEntity> where TEntity:class
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter=null ,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> OrderBy = null,
            string includeProperties= "",
            bool isNoTracking = false);

        TEntity GetById( params object[] id);

        void Insert(TEntity entity);
        void Update(TEntity entityToUpdate, params string[] excludedColumns);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        void SetCurrentValue(TEntity oldentity, TEntity currentEntity);

        }
}
