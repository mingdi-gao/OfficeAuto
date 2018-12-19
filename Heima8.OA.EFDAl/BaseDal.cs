using Heima8.OA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Heima8.OA.EFDAL
{
    /// <summary>
    /// Encapsulation the common CRUD method of all DAL class
    /// </summary>
    public class BaseDal<T> where T:class, new ()
    {
        // 一次请求共用一次上下文实例
        // db这个并不能算是共有的crud方法 所以应该抽象出来, 消除new 关键字
        // DataModelContainer db = new DataModelContainer();
        public DbContext Db
        {
            get
            {
                return DbContextFactory.GetCurrentDbContext();
            }
        }
            

        // crud

        public IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda)
        {
            // db.UserInfo.Where(u => u.Id > 0); 此处用泛型， 希望把这个条件从外部传回来
            // 下列代码已经包含了上面两种代码
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            return Db.Set<T>().Where(whereLambda).AsQueryable();

        }

        public IQueryable<T> GetPageEntities<S>(int pageSize, int pageIndex, out int total,
                    Expression<Func<T, bool>> whereLamba,
                    Expression<Func<T, S>> orderbyLambda, bool isAsc
            )
        {
            total = Db.Set<T>().Where(whereLamba).Count();

            if (isAsc)
            {
                var temp = Db.Set<T>().Where(whereLamba)
                                .OrderBy<T, S>(orderbyLambda)
                                .Skip(pageSize * (pageIndex - 1))
                                .Take(pageSize).AsQueryable();
                return temp;
            }
            else
            {
                var temp = Db.Set<T>().Where(whereLamba)
                                .OrderByDescending<T, S>(orderbyLambda)
                                .Skip(pageSize * (pageIndex - 1))
                                .Take(pageSize).AsQueryable();
                return temp;
            }


        }
        #region Cud
        public T Add(T entity)
        {
            Db.Set<T>().Add(entity);
            // Db.SaveChanges();
            return entity;
        }

        public bool Update(T entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            // return Db.SaveChanges() > 0;
            return true;
        }

        public bool Delete(T entity)
        {
            Db.Entry(entity).State = EntityState.Deleted;
            // return Db.SaveChanges() > 0;
            return true;
        }
        #endregion

    }
}
