using Heima8.OA.EFDAL;
using Heima8.OA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Heima8.OA.DALFactory
{ 
    /// <summary>
    /// 由简单工厂创建了抽象工厂
    /// 抽象工厂不需要重新生成 没有new
    /// </summary>
    public class StaticDalFactory
    {
        private static string assemblyName = System.Configuration.ConfigurationManager.AppSettings["DalAssemblyName"];

        public static IUserInfoDal GetUserInfoDal()
        {
            // return new UserInfoDal();

            // Remove the "new" keyword by using reflection
            // Now the changing point is the assembly name in parenthesis
            // so move them into config file

            return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".UserInfoDal")
                    as IUserInfoDal;

        }           

        public static IOrderInfoDal GetOrderInfoDal()
        {
            return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".OrderInfoDal")
                    as IOrderInfoDal;
        }
    }
}
