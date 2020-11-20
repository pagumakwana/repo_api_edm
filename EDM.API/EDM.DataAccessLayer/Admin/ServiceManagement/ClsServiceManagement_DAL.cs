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
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@Ref_Service_ID", ObjServiceDetails.Ref_Service_ID, DbType.Int64);
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
                Int64 Ref_Service_ID = Convert.ToInt64(objDbHelper.ExecuteScalar(Constant.AddModifyServiceDetails, ObJParameterCOl, CommandType.StoredProcedure));

                if (Ref_Service_ID > 0)
                {
                    ObjServiceDetails.FAQDetails.ForEach(FAQ =>
                    {
                        DBParameterCollection ObJParameterCOl1 = new DBParameterCollection();
                        DBParameter objDBParameter1 = new DBParameter("@Ref_Service_ID", Ref_Service_ID, DbType.Int64);
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

                    ObjServiceDetails.FileManager.ForEach(File =>
                    {
                        DBParameterCollection ObJParameterCOl1 = new DBParameterCollection();
                        DBParameter objDBParameter1 = new DBParameter("@FileManagerID", File.FileManagerID, DbType.Int64);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@ModuleID", Ref_Service_ID, DbType.Int64);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@ModuleType", File.ModuleType, DbType.String);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@FileIdentifier", File.FileIdentifier, DbType.String);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@FileName", File.FileName, DbType.String);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@FilePath", File.FilePath, DbType.String);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@FileExtension", File.FileExtension, DbType.String);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@FileType", File.FileType, DbType.String);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@FileSize", File.FileSize, DbType.Int64);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@FileSequence", File.Sequence, DbType.Int32);
                        ObJParameterCOl1.Add(objDBParameter1);

                        objDbHelper.ExecuteScalar(Constant.SaveModuleFile, ObJParameterCOl1, CommandType.StoredProcedure).ToString();
                    });

                }

                if (Ref_Service_ID > 0 && ObjServiceDetails.Ref_Service_ID == 0)
                {
                    return "SERVICEADDED";
                }
                else if (Ref_Service_ID > 0 && ObjServiceDetails.Ref_Service_ID > 0)
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

        public List<ClsServiceDetails> GetServiceDetails(Int64 Ref_Service_ID, string AliasName)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@Ref_Service_ID", Ref_Service_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@AliasName", AliasName, DbType.String);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet(Constant.GetServiceDetails, ObJParameterCOl, CommandType.StoredProcedure);
                List<ClsServiceDetails> objServiceList = new List<ClsServiceDetails>();

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objServiceList = ds.Tables[0].AsEnumerable().Select(Row =>
                            new ClsServiceDetails
                            {
                                Ref_Service_ID = Row.Field<Int64>("Ref_Service_ID"),
                                Ref_Category_ID = Row.Field<Int64>("Ref_Category_ID"),
                                ServiceTitle = Row.Field<string>("ServiceTitle"),
                                AliasName = Row.Field<string>("AliasName"),
                                Description = Row.Field<string>("Description"),
                                Price = Row.Field<decimal>("Price"),
                                PriceWithProjectFiles = Row.Field<decimal>("PriceWithProjectFiles"),
                                Revision = Row.Field<int>("Revision"),
                                DeliveryDate = Row.Field<string>("DeliveryDate"),
                                IsActive = Row.Field<Boolean>("IsActive"),
                                IsDeleted = Row.Field<Boolean>("IsDeleted"),
                                CreatedBy = Row.Field<Int64>("CreatedBy"),
                                CreatedName = Row.Field<string>("CreatedName"),
                                CreatedDateTime = Row.Field<DateTime?>("CreatedDateTime"),
                                MetaTitle = Row.Field<string>("MetaTitle"),
                                MetaKeywords = Row.Field<string>("MetaKeywords"),
                                MetaDescription = Row.Field<string>("MetaDescription"),
                                FAQDetails = ds.Tables[1].AsEnumerable().Where(x => x.Field<Int64>("Ref_Service_ID") == Row.Field<Int64>("Ref_Service_ID")).Select(Row1 =>
                                 new ClsFAQDetails
                                 {
                                     Ref_Service_ID = Row1.Field<Int64>("Ref_Service_ID"),
                                     Questions = Row1.Field<string>("Question"),
                                     Answer = Row1.Field<string>("Answer")
                                 }).ToList(),
                                FileManager = ds.Tables[2].AsEnumerable().Where(x => x.Field<Int64>("ModuleID") == Row.Field<Int64>("Ref_Service_ID")).Select(Row2 =>
                                new ClsFileManager
                                {
                                    FileManagerID = Row2.Field<Int64>("Ref_FileManager_ID"),
                                    FileIdentifier = Row2.Field<string>("FileIdentifier"),
                                    FileName = Row2.Field<string>("FileName"),
                                    FilePath = Row2.Field<string>("FilePath"),
                                    FileExtension = Row2.Field<string>("FileExtension"),
                                    FileSize = Row2.Field<Int64>("FileSize"),
                                    FileType = Row2.Field<string>("FileType"),
                                    Sequence = Row2.Field<int>("Sequence"),
                                }).ToList(),
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
                return Convert.ToString(objDbHelper.ExecuteScalar(Constant.ManageService, ObJParameterCOl, CommandType.StoredProcedure));
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