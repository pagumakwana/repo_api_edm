using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.Models.User
{
    public class ClsUserAction
    {
        public Int64 UserID { get; set; }
        public Int64 ObjectID { get; set; }
        public string ObjectType { get; set; }
        public string Action { get; set; }
    }
    public class ClsUserActionList
    {
        public Int64 ObjectID { get; set; }
        public string ObjectName { get; set; }
        public string Thumbnail { get; set; }
        public string Action { get; set; }
    }

    public class ClsUserOrder
    {
        public List<ClsOrderObjectList> ObjectList { get; set; }

    }
    public class ClsOrderObjectList
    {
        public Int64 UserID { get; set; }
        public Int64 OrderID { get; set; }
        public Int64 ObjectID { get; set; }
        public string ObjectType { get; set; }
        public string OrderStatus { get; set; }
    }
    public class ClsUserOrderList
    {
        public Int64 OrderID { get; set; }
        public string OrderCode { get; set; }
        public Int64 ObjectID { get; set; }
        public string ObjectName { get; set; }
        public string Thumbnail { get; set; }
        public string OrderDate { get; set; }
        public string OrderStatus { get; set; }
    }
}
