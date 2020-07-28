using EDM.Models.Admin.ServiceManagement;
using EDM.Models.Common;
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
            string Response = "";
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@Flag", ObjServiceDetails.Flag, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Ref_Service_ID", ObjServiceDetails.Ref_Service_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Ref_Category_ID", ObjServiceDetails.Ref_Category_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@AliasName", ObjServiceDetails.AliasName, DbType.String);
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
                objDBParameter = new DBParameter("@Revision", ObjServiceDetails.Revision, DbType.Int16);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Ref_User_ID", ObjServiceDetails.Ref_User_ID, DbType.Int32);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@CreatedName", ObjServiceDetails.CreatedName, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@MetaTitle", ObjServiceDetails.MetaTitle, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@MetaKeywords", ObjServiceDetails.MetaKeywords, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@MetaDescription", ObjServiceDetails.MetaDescription, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet(Constant.AddModifyServiceDetails, ObJParameterCOl, CommandType.StoredProcedure);
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ObjServiceDetails.Flag.Equals("ADDSERVICE") || ObjServiceDetails.Flag.Equals("MODIFYSERVICE"))
                        {
                            Response = ds.Tables[0].Rows[0]["Response"].ToString();
                            var Res = Response.Split('~');
                            ObjServiceDetails.Ref_Service_ID = Convert.ToInt64(Res[1].ToString());
                            if (ObjServiceDetails.Ref_Service_ID > 0)
                            {
                                ObjServiceDetails.FAQDetails.ForEach(FAQ =>
                                {
                                    DBParameterCollection ObJParameterCOl1 = new DBParameterCollection();
                                    DBParameter objDBParameter1 = new DBParameter("@Ref_Service_ID", ObjServiceDetails.Ref_Service_ID, DbType.Int64);
                                    ObJParameterCOl1.Add(objDBParameter1);
                                    objDBParameter1 = new DBParameter("@Question", FAQ.Questions, DbType.String);
                                    ObJParameterCOl1.Add(objDBParameter1);
                                    objDBParameter1 = new DBParameter("@Answer", FAQ.Answer, DbType.String);
                                    ObJParameterCOl1.Add(objDBParameter1);
                                    objDBParameter1 = new DBParameter("@Ref_User_ID", ObjServiceDetails.Ref_User_ID, DbType.Int64);
                                    ObJParameterCOl1.Add(objDBParameter1);
                                    objDBParameter1 = new DBParameter("@CreatedName", ObjServiceDetails.CreatedName, DbType.String);
                                    ObJParameterCOl1.Add(objDBParameter1);

                                    objDbHelper.ExecuteScalar(Constant.AddModifyServiceFAQ, ObJParameterCOl1, CommandType.StoredProcedure);
                                });
                            }
                            if (ObjServiceDetails.Ref_Service_ID > 0 && (ObjServiceDetails.FileUrls != null && ObjServiceDetails.FileUrls.Count > 0))
                            {
                                ObjServiceDetails.FileUrls.ForEach(image =>
                                {
                                    DBParameterCollection ObJParameterCOl1 = new DBParameterCollection();
                                    DBParameter objDBParameter1 = new DBParameter("@FileName", image.FileName, DbType.String);
                                    ObJParameterCOl1.Add(objDBParameter1);
                                    objDBParameter1 = new DBParameter("@FilePath", image.FilePath, DbType.String);
                                    ObJParameterCOl1.Add(objDBParameter1);
                                    objDBParameter1 = new DBParameter("@FileExtension", image.FileExtension, DbType.String);
                                    ObJParameterCOl1.Add(objDBParameter1);
                                    objDBParameter1 = new DBParameter("@FileSize", image.FileSize, DbType.Int64);
                                    ObJParameterCOl1.Add(objDBParameter1);
                                    objDBParameter1 = new DBParameter("@Ref_User_ID", ObjServiceDetails.Ref_User_ID, DbType.Int64);
                                    ObJParameterCOl1.Add(objDBParameter1);
                                    objDBParameter1 = new DBParameter("@CreatedName", ObjServiceDetails.CreatedName, DbType.String);
                                    ObJParameterCOl1.Add(objDBParameter1);
                                    objDBParameter1 = new DBParameter("@Ref_ID", ObjServiceDetails.Ref_Service_ID, DbType.Int64);
                                    ObJParameterCOl1.Add(objDBParameter1);
                                    objDBParameter1 = new DBParameter("@ModuleName", image.ModuleName, DbType.String);
                                    ObJParameterCOl1.Add(objDBParameter1);
                                    objDBParameter1 = new DBParameter("@FileType", image.FileType, DbType.String);
                                    ObJParameterCOl1.Add(objDBParameter1);
                                    objDBParameter1 = new DBParameter("@FileIdentifier", image.FileIdentifier, DbType.String);
                                    ObJParameterCOl1.Add(objDBParameter1);
                                    objDBParameter1 = new DBParameter("@DisplayOrder", image.DisplayOrder, DbType.Int64);
                                    ObJParameterCOl1.Add(objDBParameter1);
                                    DBHelper objDbHelper1 = new DBHelper();
                                    objDbHelper1.ExecuteScalar(Constant.AddMasterFile, ObJParameterCOl1, CommandType.StoredProcedure);

                                });
                            }
                            Response = Res[0].ToString();
                        }
                        else
                        {
                            Response = ds.Tables[0].Rows[0]["Response"].ToString();
                        }
                    }
                }
                return Response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClsServiceDetails> GetServiceDetails(string Flag, Int64 Ref_Service_ID, string AliasName)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@Flag", Flag, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Ref_Service_ID", Ref_Service_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@AliasName", AliasName, DbType.String);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet(Constant.GetServiceDetails, ObJParameterCOl, CommandType.StoredProcedure);
                List<ClsServiceDetails> objServiceList = new List<ClsServiceDetails>();
                List<ClsFileInfo> fileList = new List<ClsFileInfo>();
                List<ClsFAQDetails> lstFAQ = new List<ClsFAQDetails>();

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        fileList = ds.Tables[0].AsEnumerable().Select(Row =>
                          new ClsFileInfo
                          {
                              Ref_ID = Row.Field<Int64>("Ref_ID"),
                              Ref_File_ID = Row.Field<Int64>("Ref_File_ID"),
                              FileName = Row.Field<string>("FileName"),
                              FilePath = Row.Field<string>("FilePath"),
                              FileExtension = Row.Field<string>("FileExtension"),
                              FileSize = Row.Field<long>("FileSize"),
                              ModuleName = Row.Field<string>("ModuleName"),
                              FileIdentifier= Row.Field<string>("FileIdentifier"),
                              DisplayOrder = Row.Field<Int64>("DisplayOrder"),
                          }).ToList();
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        lstFAQ = ds.Tables[1].AsEnumerable().Select(Row1 =>
                                   new ClsFAQDetails
                                   {
                                       Ref_Service_ID = Row1.Field<Int64>("Ref_Service_ID"),
                                       Questions = Row1.Field<string>("Question"),
                                       Answer = Row1.Field<string>("Answer")
                                   }).ToList();
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        objServiceList = ds.Tables[2].AsEnumerable().Select(Row =>
                            new ClsServiceDetails
                            {
                                Ref_Service_ID = Row.Field<Int64>("Ref_Service_ID"),
                                Ref_Category_ID = Row.Field<Int64>("Ref_Category_ID"),
                                ServiceTitle = Row.Field<string>("ServiceTitle"),
                                AliasName = Row.Field<string>("AliasName"),
                                Description = Row.Field<string>("Description"),
                                //BigImageUrl = Row.Field<string>("BigImageUrl"),
                                Price = Row.Field<decimal>("Price"),
                                PriceWithProjectFiles = Row.Field<decimal>("PriceWithProjectFiles"),
                                //ServiceVideoUrl = Row.Field<string>("ServiceVideoUrl"),
                                //ProjectFilesUrl = Row.Field<string>("ProjectFilesUrl"),
                                //ThumbnailImageUrl = Row.Field<string>("ThumbnailImageUrl"),
                                Revision = Row.Field<int>("Revision"),
                                DeliveryDate = Row.Field<string>("DeliveryDate"),                                
                                FAQDetails = (from obj in lstFAQ
                                              where obj.Ref_Service_ID == Row.Field<Int64>("Ref_Service_ID")
                                              select obj).ToList(),
                                FileUrls = (from obj in fileList
                                            where obj.Ref_ID == Row.Field<Int64>("Ref_Service_ID")
                                            select obj).ToList(),
                                IsActive = Row.Field<Boolean>("IsActive"),
                                IsDeleted = Row.Field<Boolean>("IsDeleted"),
                                CreatedBy = Row.Field<Int64>("CreatedBy"),
                                CreatedName = Row.Field<string>("CreatedName"),
                                CreatedDateTime = Row.Field<DateTime?>("CreatedDateTime"),
                                UpdatedBy = Row.Field<Int64>("UpdatedBy"),
                                UpdatedName = Row.Field<string>("UpdatedName"),
                                UpdatedDateTime = Row.Field<DateTime?>("UpdatedDateTime"),
                                MetaTitle = Row.Field<string>("MetaTitle"),
                                MetaKeywords = Row.Field<string>("MetaKeywords"),
                                MetaDescription = Row.Field<string>("MetaDescription"),

                            }).ToList();
                    }
                }
                return objServiceList;
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