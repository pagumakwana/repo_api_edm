using EDM.DataAccessLayer.User;
using EDM.Models.User;
using System;
using System.Collections.Generic;

namespace EDM.BusinessAccessLayer.User
{
    public class ClsOrder_BAL : IDisposable
    {
        public String AddModifyUserAction(ClsUserAction ObjUserAction)
        {
            using (ClsOrder_DAL obj = new ClsOrder_DAL())
            {
                return obj.AddModifyUserAction(ObjUserAction);
            }
        }

        public List<ClsUserActionList> GetUserActionDetails(Int64 UserID, string Action)
        {
            using (ClsOrder_DAL obj = new ClsOrder_DAL())
            {
                return obj.GetUserActionDetails(UserID, Action);
            }
        }

        public String AddModifyUserOrder(ClsUserOrder ObjUserOrder)
        {
            using (ClsOrder_DAL obj = new ClsOrder_DAL())
            {
                return obj.AddModifyUserOrder(ObjUserOrder);
            }
        }

        public List<ClsUserOrderList> GetUserOrderDetails(Int64 UserID, string OrderStatus)
        {
            using (ClsOrder_DAL obj = new ClsOrder_DAL())
            {
                return obj.GetUserOrderDetails(UserID, OrderStatus);
            }
        }

        public void Dispose()
        {

        }
    }
}
