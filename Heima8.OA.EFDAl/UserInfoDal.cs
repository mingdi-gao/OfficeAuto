using Heima8.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Heima8.OA.IDAL;

namespace Heima8.OA.EFDAL
{
    public class UserInfoDal: BaseDal<UserInfo>, IUserInfoDal
    {
        //DataModelContainer db = new DataModelContainer();

        //// 封装UserInfo table的crud方法
        ////public UserInfo GetUserInfoById(int id)
        ////{
        ////    // 先封装一个dbcontext实体
        ////    return db.UserInfo.Find(id);
        ////}
        ////public List<UserInfo> GetAllUserInfo(int id)
        ////{
        ////    // 先封装一个dbcontext实体
        ////    return db.UserInfo.ToList();
        ////}

        //public IQueryable<UserInfo> GetUsers(Expression<Func<UserInfo, bool>> whereLambda)
        //{
        //    // db.UserInfo.Where(u => u.Id > 0); 此处用泛型， 希望把这个条件从外部传回来
        //    // 下列代码已经包含了上面两种代码
        //    return db.UserInfo.Where(whereLambda).AsQueryable();
            
        //}

        //public IQueryable<UserInfo> GetPageUsers<S>(int pageSize, int pageIndex, out int total, 
        //            Expression<Func<UserInfo, bool>> whereLamba,
        //            Expression<Func<UserInfo, S>> orderbyLambda, bool isAsc
        //    )
        //{
        //    total = db.UserInfo.Where(whereLamba).Count();

        //    if (isAsc)
        //    {
        //        var temp = db.UserInfo.Where(whereLamba)
        //                        .OrderBy<UserInfo, S>(orderbyLambda)
        //                        .Skip(pageSize * (pageIndex - 1))
        //                        .Take(pageSize).AsQueryable();
        //        return temp;
        //    }
        //    else
        //    {
        //        var temp = db.UserInfo.Where(whereLamba)
        //                        .OrderByDescending<UserInfo, S>(orderbyLambda)
        //                        .Skip(pageSize * (pageIndex - 1))
        //                        .Take(pageSize).AsQueryable();
        //        return temp;
        //    }
            

        //}
        //#region Cud
        //public UserInfo Add(UserInfo userInfo)
        //{
        //    db.UserInfo.Add(userInfo);
        //    db.SaveChanges();
        //    return userInfo;
        //}

        //public bool Update(UserInfo userInfo)
        //{
        //    db.Entry(userInfo).State = EntityState.Modified;
        //    return db.SaveChanges() > 0;
        //}

        //public bool Delete(UserInfo userInfo)
        //{
        //    db.Entry(userInfo).State = EntityState.Deleted;
        //    return db.SaveChanges() > 0;
        //}
        //#endregion



    }
}
