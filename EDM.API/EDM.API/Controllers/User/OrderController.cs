using EDM.BusinessAccessLayer.User;
using EDM.Models.User;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;


namespace EDM.API.Controllers.User
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/UserOrder")]
    public class OrderController : ApiController
    {

        [Route("UserAction")]
        [HttpPost]
        public string AddModifyUserAction(ClsUserAction ObjUserAction)
        {
            using (ClsOrder_BAL obj = new ClsOrder_BAL())
            {
                return obj.AddModifyUserAction(ObjUserAction);
            }
        }

        [Route("UserAction")]
        [HttpGet]
        public List<ClsUserActionList> GetUserActionDetails(Int64 UserID, string Action)
        {
            using (ClsOrder_BAL obj = new ClsOrder_BAL())
            {
                return obj.GetUserActionDetails(UserID, Action);
            }
        }

        [Route("Order")]
        [HttpPost]
        public string AddModifyUserOrder(ClsUserOrder ObjUserOrder)
        {
            using (ClsOrder_BAL obj = new ClsOrder_BAL())
            {
                return obj.AddModifyUserOrder(ObjUserOrder);
            }
        }

        [Route("Order")]
        [HttpGet]
        public List<ClsUserOrderList> GetUserOrderDetails(Int64 UserID, string OrderStatus = null)
        {
            using (ClsOrder_BAL obj = new ClsOrder_BAL())
            {
                return obj.GetUserOrderDetails(UserID, OrderStatus);
            }
        }

        [Route("Remove")]
        [HttpGet]
        public string RemoveUserOrderObject(Int64 UserID, Int64 OrderID, Int64 ObjectID, string ObjectType)
        {
            using (ClsOrder_BAL obj = new ClsOrder_BAL())
            {
                return obj.RemoveUserOrderObject(UserID, OrderID, ObjectID, ObjectType);
            }
        }

        [Route("Status")]
        [HttpGet]
        public string SetUserOrderStatus(Int64 UserID, Int64 OrderID, string OrderStatus = null)
        {
            using (ClsOrder_BAL obj = new ClsOrder_BAL())
            {
                return obj.SetUserOrderStatus(UserID, OrderID, OrderStatus);
            }
        }

        [Route("ApplyCoupon")]
        [HttpGet]
        public List<ClsApplyCouponCode> ApplyCouponCode(Int64 UserID, Int64 OrderID, string CouponCode)
        {
            using (ClsOrder_BAL obj = new ClsOrder_BAL())
            {
                return obj.ApplyCouponCode(UserID, OrderID, CouponCode);
            }
        }

    }
}