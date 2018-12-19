using Heima8.OA.DALFactory;
using Heima8.OA.EFDAL;
using Heima8.OA.IBLL;
using Heima8.OA.IDAL;
using Heima8.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heima8.OA.BLL
{

    
    // 模块内高内聚 模块间低耦合

    // 变化点: 1. 跨数据库. 
    // 变化点: 2. 访问驱动层变化
    public class UserInfoService : BaseService<UserInfo>, IUserInfoService
    {
        #region old
        // 让一个菜鸟到一个一般水平的开发: 依赖接口编程
        // IUserInfoDal userInfoDal = new UserInfoDal();

        // 稍微高级点的开发人员会用简单工厂
        // private IUserInfoDal userInfoDal = StaticDalFactory.GetUserInfoDal();

        // 再高一点的用IOC, DI 依赖注入, Sprint.Net, Ninject, Unity


        // 以下为初级程序员直接new一个DbSession
        // DbSession dbSession = new DbSession();

        // 高一点的程序员会尽量使用少的DbSession和上下文


        #endregion

        #region old2
        //public UserInfo Add(UserInfo userInfo)  // 单元工作模式
        //{
        //    // return userInfoDal.Add(userInfo);

        //    dbSession.UserInfoDal.Add(userInfo);
        //    if (dbSession.SaveChanges() > 0)
        //    {
        //        // 操作成功！
        //    }
        //    dbSession.UserInfoDal.Add(new UserInfo());
        //    dbSession.UserInfoDal.Delete(new UserInfo());

        //    dbSession.SaveChanges(); // 数据提交的权力从DAL提到了业务逻辑层BLL
        //    return userInfo;
        //    // return dbSession.UserInfoDal.Add(userInfo);
        //}
        #endregion

        // private IDbSession DbSession = DbSessionFactory.GetCurrentDbSession();
        public override void SetCurrentDal()
        {
            // 父类的dbSession里的UserInfoDal赋值给子类当前Dal
            CurrentDal = this.DbSession.UserInfoDal;
        }
        
    }
} 
