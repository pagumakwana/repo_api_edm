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
                objDBParameter = new DBParameter("@Description", ObjServiceDetails.Description, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@DeliveryDate", ObjServiceDetails.DeliveryDate, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Price", ObjServiceDetails.Price, DbType.Decimal);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@PriceWithProjectFiles", ObjServiceDetails.PriceWithProjectFiles, DbType.Decimal);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@ServiceVideoUrl", ObjServiceDetails.ServiceVideoUrl, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@ProjectFilesUrl", ObjServiceDetails.ProjectFilesUrl, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@ThumbnailImageUrl", ObjServiceDetails.ThumbnailImageUrl, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@BigImageUrl", ObjServiceDetails.BigImageUrl, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Revision", ObjServiceDetails.Revision, DbType.Int16);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@IsActive", ObjServiceDetails.IsActive, DbType.Boolean);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@CreatedBy", ObjServiceDetails.CreatedBy, DbType.String);
                ObJParameterCOl.Add(objDBParameter);

                Int64 Ref_Service_ID = 0;
                DBHelper objDbHelper = new DBHelper();
                Ref_Service_ID = Convert.ToInt64(objDbHelper.ExecuteScalar("[dbo].[AddModifyServiceDetails]", ObJParameterCOl, CommandType.StoredProcedure));

                if (Ref_Service_ID > 0)
                {
                    ObjServiceDetails.FAQDetails.ForEach(FAQ =>
                    {
                        DBParameterCollection ObJParameterCOl1 = new DBParameterCollection();
                        DBParameter objDBParameter1 = new DBParameter("@Ref_Service_ID", @Ref_Service_ID, DbType.Int64);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@Question", FAQ.Questions, DbType.String);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@Answer", FAQ.Answer, DbType.String);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@CreatedBy", ObjServiceDetails.CreatedBy, DbType.String);
                        ObJParameterCOl1.Add(objDBParameter1);

                        objDbHelper.ExecuteScalar("[dbo].[AddModifyServiceFAQ]", ObJParameterCOl1, CommandType.StoredProcedure);
                    });
                }

                if (Ref_Service_ID > 0 && ObjServiceDetails.Ref_Service_ID == 0)
                {
                    return "SERVICEADDED";
                }
                else if (Ref_Service_ID > 0 && ObjServiceDetails.Ref_Service_ID == 0)
                {
                    return "SERVICEUPDATED";
                }
                else
                {
                    return "SERVICEEXISTS";
                }
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
                                Description = Row.Field<string>("Description"),
                                BigImageUrl = Row.Field<string>("BigImageUrl"),
                                Price = Row.Field<decimal>("Price"),
                                PriceWithProjectFiles = Row.Field<decimal>("PriceWithProjectFiles"),
                                ServiceVideoUrl = Row.Field<string>("ServiceVideoUrl"),
                                ProjectFilesUrl = Row.Field<string>("ProjectFilesUrl"),
                                ThumbnailImageUrl = Row.Field<string>("ThumbnailImageUrl"),
                                Revision = Row.Field<int>("Revision"),
                                DeliveryDate = Row.Field<string>("DeliveryDate"),
                                IsActive = Row.Field<Boolean>("IsActive"),
                                FAQDetails = ds.Tables[1].AsEnumerable().Where(x => x.Field<Int64>("Ref_Service_ID") == Row.Field<Int64>("Ref_Service_ID")).Select(Row1 =>
                                    new ClsFAQDetails
                                    {
                                        Questions = Row1.Field<string>("Question"),
                                        Answer = Row1.Field<string>("Answer")
                                    }).ToList()
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

        public string ManageService(string ServiceIDs, string Action)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@ServiceIDs", ServiceIDs, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Action", Action, DbType.String);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                return Convert.ToString(objDbHelper.ExecuteScalar("[dbo].[ManageService]", ObJParameterCOl, CommandType.StoredProcedure));

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