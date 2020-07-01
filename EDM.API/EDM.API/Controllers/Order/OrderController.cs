using EDM.BusinessAccessLayer.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;


namespace EDM.API.Controllers.Order
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Order")]
    public class OrderController : ApiController
    {

        [Route("UserOrder/AddToCart")]
        [HttpGet]
        public string AddToCart(Int64 ObjectID, Int64 ObjectType, string Action)
        {
            using (ClsOrder_BAL obj = new ClsOrder_BAL())
            {
                return obj.AddToCart(ObjectID, ObjectType, Action);
            }
        }

        //[Route("UserOrder/AddToCart")]
        //[HttpGet]
        //public string AddToCart(Int64 ObjectID, Int64 ObjectType, string Action)
        //{
        //    using (ClsOrder_BAL obj = new ClsOrder_BAL())
        //    {
        //        return obj.AddToCart(ObjectID, ObjectType, Action);
        //    }
        //}
    }
}