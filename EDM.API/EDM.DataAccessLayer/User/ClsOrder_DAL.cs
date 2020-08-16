using EDM.DataAccessLayer.Common;
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
                return Convert.ToString(objDbHelper.ExecuteScalar("[dbo].[AddModifyUserAction]", ObJParameterCOl, CommandType.StoredProcedure));
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
                DataSet Ds = objDbHelper.ExecuteDataSet("[dbo].[GetUserActionDetails]", ObJParameterCOl, CommandType.StoredProcedure);

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
                                    Action = Row.Field<string>("Action"),
                                    Thumbnail = Row.Field<string>("Thumbnail")
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

                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@UserID", ObjUserOrder.UserID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@OrderID", ObjUserOrder.OrderID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@OrderCode", objCommon.RandomString(10), DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@ObjectID", ObjUserOrder.ObjectID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@ObjectType", ObjUserOrder.ObjectType, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@OrderStatus", ObjUserOrder.OrderStatus, DbType.String);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                return Convert.ToString(objDbHelper.ExecuteScalar("[dbo].[AddModifyUserOrder]", ObJParameterCOl, CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClsUserOrderList> GetUserOrderDetails(Int64 UserID, string Action)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@UserID", UserID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Action", Action, DbType.String);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataSet Ds = objDbHelper.ExecuteDataSet("[dbo].[GetUserOrderDetails]", ObJParameterCOl, CommandType.StoredProcedure);

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
                                    ObjectName = Row.Field<string>("ObjectName"),
                                    OrderDate = Row.Field<string>("OrderDate"),
                                    OrderStatus = Row.Field<string>("OrderStatus"),
                                    Thumbnail = Row.Field<string>("Thumbnail"),
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

        public void Dispose()
        {

        }
    }
}
