using EDM.Models.Admin.ServiceManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.DataAccessLayer.Admin.ServiceManagement
{
    public class ClsServiceManagement_DAL : IDisposable
    {
        public string AddModifyServiceDetails(ClsServiceDetails ObjServiceDetails)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@Ref_Service_ID", ObjServiceDetails.Ref_Service_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Ref_Category_ID", ObjServiceDetails.Ref_Category_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@ServiceTitle", ObjServiceDetails.ServiceTitle, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Description", ObjServiceDetails.Descripation, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@DeliveryDate", ObjServiceDetails.DeliveryDate, DbType.DateTime);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@ServiceVideoUrl", ObjServiceDetails.ServiceVideoUrl, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@ThumbnailImageUrl", ObjServiceDetails.ThumbnailImageUrl, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@BigImageUrl", ObjServiceDetails.BigImageUrl, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@IsActive", ObjServiceDetails.IsActive, DbType.Boolean);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@CreatedBy", ObjServiceDetails.CreatedBy, DbType.String);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                return Convert.ToString(objDbHelper.ExecuteScalar("[dbo].[AddModifyServiceDetails]", ObJParameterCOl, CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClsServiceDetails> GetServiceDetails(Int64 ServiceID)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@ServiceID", ServiceID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet("[dbo].[GetServiceDetails]", ObJParameterCOl, CommandType.StoredProcedure);
                List<ClsServiceDetails> objUserMasterData = new List<ClsServiceDetails>();

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        IList<ClsServiceDetails> List = ds.Tables[0].AsEnumerable().Select(Row =>
                            new ClsServiceDetails
                            {
                                Ref_Service_ID = Row.Field<Int64>("Ref_Service_ID"),
                                Ref_Category_ID = Row.Field<Int64>("Ref_Category_ID"),
                                ServiceTitle = Row.Field<string>("ServiceTitle"),
                                Descripation = Row.Field<string>("Descripation"),
                                BigImageUrl = Row.Field<string>("BigImageUrl"),
                                ServiceVideoUrl = Row.Field<string>("ServiceVideoUrl"),
                                ThumbnailImageUrl = Row.Field<string>("ThumbnailImageUrl"),
                                Price = Row.Field<decimal>("Price"),
                                DeliveryDate = Row.Field<string>("DeliveryDate"),
                                IsActive = Row.Field<Boolean>("IsActive"),

                            }).ToList();
                        objUserMasterData.AddRange(List);
                    }
                }
                return objUserMasterData;
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