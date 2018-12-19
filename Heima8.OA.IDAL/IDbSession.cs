using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heima8.OA.IDAL
{
    public interface IDbSession
    { 

        IUserInfoDal UserInfoDal { get; }
        IOrderInfoDal OrderInfoDal { get; }

        /// <summary>
    /// Get the current DbContext and commit the whole entity
    /// </summary>
    /// <returns></returns>
        int SaveChanges();

    }
}
