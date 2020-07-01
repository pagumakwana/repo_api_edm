using EDM.DataAccessLayer.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.BusinessAccessLayer.Order
{
    public class ClsOrder_BAL : IDisposable
    {
        public String AddToCart(Int64 ObjectID, Int64 ObjectType, string Action)
        {
            using (ClsOrder_DAL obj = new ClsOrder_DAL())
            {
                return obj.AddToCart(ObjectID, ObjectType, Action);
            }
        }

        public void Dispose()
        {

        }
    }
}
