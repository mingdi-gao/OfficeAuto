using Heima8.OA.DALFactory;
using Heima8.OA.IDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Heima8.OA.BLL
{
    /// <summary>
    /// 父类逼迫子类在创建时给DAL赋值
    /// 赋值必须在父类方法调用前执行
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseService<T> where T: class, new()
    {
        public IBaseDal<T> CurrentDal { get; set; }

        public IDbSession DbSession
        {
            get
            {
                return DbSessionFactory.GetCurrentDbSession();
            }
        }

        public abstract void SetCurrentDal();

        public BaseService()
        {
            SetCurrentDal();
         }

        public IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda)
        {
            return CurrentDal.GetEntities(whereLambda);

        }

        public IQueryable<T> GetPageEntities<S>(int pageSize, int pageIndex, out int total,
                    Expression<Func<T, bool>> whereLamba,
                    Expression<Func<T, S>> orderbyLambda, bool isAsc
            )
        {
            return CurrentDal.GetPageEntities(pageSize, pageIndex, out total, whereLamba, orderbyLambda, isAsc);
        }

        #region Cud
        public T Add(T entity)
        {
            CurrentDal.Add(entity);
            DbSession.SaveChanges();
            return entity;
        }

        public bool Update(T entity)
        {
            CurrentDal.Update(entity);
            return DbSession.SaveChanges() > 0;
        }

        public bool Delete(T entity)
        {
            CurrentDal.Delete(entity);
            return DbSession.SaveChanges() > 0;
        }
        #endregion
    }
}
