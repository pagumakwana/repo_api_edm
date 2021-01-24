using EDM.DataAccessLayer.Common;
using EDM.Models.Common;
using EDM.Models.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.DataAccessLayer.User
{
    public class ClsOrder_DAL : IDisposable
    {
        public string AddModifyUserAction(ClsUserAction ObjUserAction)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@UserID", ObjUserAction.UserID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@ObjectID", ObjUserAction.ObjectID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@ObjectType", ObjUserAction.ObjectType, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Action", ObjUserAction.Action, DbType.String);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                return Convert.ToString(objDbHelper.ExecuteScalar(Constant.AddModifyUserAction, ObJParameterCOl, CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClsUserActionList> GetUserActionDetails(Int64 UserID, string Action)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@UserID", UserID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Action", Action, DbType.String);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataSet Ds = objDbHelper.ExecuteDataSet(Constant.GetUserActionDetails, ObJParameterCOl, CommandType.StoredProcedure);

                List<ClsUserActionList> objUserAction = new List<ClsUserActionList>();

                if (Ds != null)
                {
                    if (Ds.Tables.Count > 0)
                    {
                        if (Ds.Tables[0].Rows.Count > 0)
                        {
                            IList<ClsUserActionList> List = Ds.Tables[0].AsEnumerable().Select(Row =>
                                new ClsUserActionList
                                {
                                    ObjectID = Row.Field<Int64>("Ref_Object_ID"),
                                    ObjectName = Row.Field<string>("ObjectName"),
                                    ObjectType = Row.Field<string>("ObjectType"),
                                    ObjectCategory = Row.Field<string>("ObjectCategory"),
                                    Thumbnail = Row.Field<string>("Thumbnail"),
                                    Price = Row.Field<decimal>("Price"),
                                    Favourite = Row.Field<string>("Favourite"),
                                    PlayUrl = Row.Field<string>("PlayUrl"),
                                    Action = Row.Field<string>("Action"),
                                    SoldOut = Row.Field<string>("SoldOut"),
                                }).ToList();
                            objUserAction.AddRange(List);
                        }
                    }
                }
                return objUserAction;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string AddModifyUserOrder(ClsUserOrder ObjUserOrder)
        {
            try
            {
                ClsCommon_DAL objCommon = new ClsCommon_DAL();
                DBHelper objDbHelper = new DBHelper();
                string Action = "", OrderCode = "";

                if (ObjUserOrder.ObjectList[0].OrderID == 0)
                    OrderCode = objCommon.RandomString(10);

                ObjUserOrder.ObjectList.ForEach(Object =>
                {
                    DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                    DBParameter objDBParameter = new DBParameter("@UserID", Object.UserID, DbType.Int64);
                    ObJParameterCOl.Add(objDBParameter);
                    objDBParameter = new DBParameter("@OrderID", Object.OrderID, DbType.Int64);
                    ObJParameterCOl.Add(objDBParameter);
                    objDBParameter = new DBParameter("@OrderCode", OrderCode, DbType.String);
                    ObJParameterCOl.Add(objDBParameter);
                    objDBParameter = new DBParameter("@ObjectID", Object.ObjectID, DbType.Int64);
                    ObJParameterCOl.Add(objDBParameter);
                    objDBParameter = new DBParameter("@ObjectType", Object.ObjectType, DbType.String);
                    ObJParameterCOl.Add(objDBParameter);
                    objDBParameter = new DBParameter("@IncludeProjectFile", Object.IncludeProjectFile, DbType.Boolean);
                    ObJParameterCOl.Add(objDBParameter);
                    objDBParameter = new DBParameter("@OrderStatus", Object.OrderStatus, DbType.String);
                    ObJParameterCOl.Add(objDBParameter);

                    Action = Convert.ToString(objDbHelper.ExecuteScalar(Constant.AddModifyUserOrder, ObJParameterCOl, CommandType.StoredProcedure));
                });
                return Action;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ClsUserOrderList> GetUserOrderDetails(Int64 UserID, string OrderStatus)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@UserID", UserID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@OrderStatus", OrderStatus, DbType.String);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataSet Ds = objDbHelper.ExecuteDataSet(Constant.GetUserOrderDetails, ObJParameterCOl, CommandType.StoredProcedure);
                List<ClsUserOrderList> objUserOrder = new List<ClsUserOrderList>();

                if (Ds != null)
                {
                    if (Ds.Tables.Count > 0)
                    {
                        if (Ds.Tables[0].Rows.Count > 0)
                        {
                            IList<ClsUserOrderList> List = Ds.Tables[0].AsEnumerable().Select(Row =>
                                new ClsUserOrderList
                                {
                                    OrderID = Row.Field<Int64>("Ref_Order_ID"),
                                    OrderCode = Row.Field<string>("OrderCode"),
                                    ObjectID = Row.Field<Int64>("Ref_Object_ID"),
                                    ObjectType = Row.Field<string>("ObjectType"),
                                    ObjectName = Row.Field<string>("ObjectName"),
                                    ObjectCategory = Row.Field<string>("ObjectCategory"),
                                    Thumbnail = Row.Field<string>("Thumbnail"),
                                    Price = Row.Field<string>("Price"),
                                    IncludeProjectFile = Row.Field<Boolean>("IncludeProjectFile"),
                                    OrderDate = Row.Field<string>("OrderDate"),
                                    OrderStatus = Row.Field<string>("OrderStatus"),
                                }).ToList();
                            objUserOrder.AddRange(List);
                        }
                    }
                }
                return objUserOrder;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string RemoveUserOrderObject(Int64 UserID, Int64 OrderID, Int64 ObjectID,string ObjectType)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@UserID", UserID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@OrderID", OrderID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@ObjectID", ObjectID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@ObjectType", ObjectType, DbType.String);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();

                return Convert.ToString(objDbHelper.ExecuteScalar(Constant.RemoveUserOrderObject, ObJParameterCOl, CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string SetUserOrderStatus(Int64 UserID, Int64 OrderID, string OrderStatus)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@UserID", UserID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@OrderID", OrderID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@OrderStatus", OrderStatus, DbType.String);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                return Convert.ToString(objDbHelper.ExecuteScalar(Constant.SetUserOrderStatus, ObJParameterCOl, CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ClsApplyCouponCode> ApplyCouponCode(Int64 UserID, Int64 OrderID, string CouponCode)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@UserID", UserID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@OrderID", OrderID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@CouponCode", CouponCode, DbType.String);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataTable dt = objDbHelper.ExecuteDataTable(Constant.ApplyCouponCode, ObJParameterCOl, CommandType.StoredProcedure);
                List<ClsApplyCouponCode> objCoupon = new List<ClsApplyCouponCode>();

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        IList<ClsApplyCouponCode> List = dt.AsEnumerable().Select(Row =>
                            new ClsApplyCouponCode
                            {
                                ObjectIDs = Row.Field<string>("ObjectIDs"),
                                DiscountInMax = Row.Field<decimal>("DiscountInMax"),
                                DiscountInPercentage = Row.Field<decimal>("DiscountInPercentage"),
                                CouponStatus = Row.Field<string>("CouponStatus")
                            }).ToList();
                        objCoupon.AddRange(List);
                    }
                }
                return objCoupon;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {

        }
    }
}
