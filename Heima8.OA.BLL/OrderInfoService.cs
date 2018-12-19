using Heima8.OA.EFDAL;
using Heima8.OA.IDAL;
using Heima8.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heima8.OA.BLL
{
    public class OrderInfoService : BaseService<OrderInfo>
    {
        //public OrderInfo Add(OrderInfo orderInfo)
        //{
        //    IOrderInfoDal orderInfoDal = new OrderInfoDal();
        //    return orderInfoDal.Add(orderInfo);
        //}
        public override void SetCurrentDal()
        {
            CurrentDal = this.DbSession.OrderInfoDal;
        }
    }
}
