using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Heima8.OA.IBLL
{
    public interface IBaseService<T> where T : class,  new()
    {
        IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda);


        IQueryable<T> GetPageEntities<S>(int pageSize, int pageIndex, out int total,
                   Expression<Func<T, bool>> whereLamba,
                   Expression<Func<T, S>> orderbyLambda, bool isAsc
           );

        #region Cud
        T Add(T entity);

        bool Update(T entity);

        bool Delete(T entity);
        #endregion
    }
}
