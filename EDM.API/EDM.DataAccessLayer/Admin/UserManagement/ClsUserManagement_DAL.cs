using EDM.Models.Admin.UserManagement;
using EDM.Models.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace EDM.DataAccessLayer.Admin.UserManagement
{
    public class ClsUserManagement_DAL : IDisposable
    {
        public List<ClsProducersDetails> GetAllProducersList(Int64 UserID, string AccountStatus, int StartCount, int EndCount)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@UserID", UserID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@AccountStatus", AccountStatus, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@StartCount", StartCount, DbType.Int16);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@EndCount", EndCount, DbType.Int16);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataTable User = objDbHelper.ExecuteDataTable(Constant.GetAllProducersList, ObJParameterCOl, CommandType.StoredProcedure);
                List<ClsProducersDetails> objUserDetails = new List<ClsProducersDetails>();

                if (User != null)
                {
                    if (User.Rows.Count > 0)
                    {
                        objUserDetails = User.AsEnumerable().Select(Row =>
                            new ClsProducersDetails
                            {
                                Ref_User_ID = Row.Field<Int64>("Ref_User_ID"),
                                UserCode = Row.Field<string>("UserCode"),
                                FullName = Row.Field<string>("FullName"),
                                EmailID = Row.Field<string>("EmailID"),
                                MobileNumber = Row.Field<string>("MobileNumber"),
                                Bio = Row.Field<string>("Bio"),
                                ProfilePhoto = Row.Field<string>("ProfilePhoto"),
                                TrackCount = Row.Field<int>("TrackCount"),
                                BeatCount = Row.Field<int>("BeatCount"),
                                Earning = Row.Field<string>("Earning"),
                                AccountStatus = Row.Field<string>("AccountStatus"),
                            }).ToList();
                    }
                }
                return objUserDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ProducerApproveAndRejact(ClsProducersApproveAndRejact ObjApproveAndRejact)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@ProducerIDs", ObjApproveAndRejact.ProducerIDs, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Action", ObjApproveAndRejact.Action, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Reason", ObjApproveAndRejact.Reason, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@ActionBy", ObjApproveAndRejact.ActionBy, DbType.String);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                return Convert.ToString(objDbHelper.ExecuteScalar(Constant.ProducerApproveAndRejact, ObJParameterCOl, CommandType.StoredProcedure));
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
