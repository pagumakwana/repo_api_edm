using EDM.DataAccessLayer.User;
using System;

namespace EDM.BusinessAccessLayer.User
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
