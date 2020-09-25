using EDM.Models.Common;
using EDM.Models.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EDM.DataAccessLayer.User
{
    public class ClsService_DAL : IDisposable
    {
        public List<ClsServiceList> GetServiceList(int StartCount, int EndCount)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@StartCount", StartCount, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@EndCount", EndCount, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet(Constant.GetServiceList, ObJParameterCOl, CommandType.StoredProcedure);
                List<ClsServiceList> objServiceList = new List<ClsServiceList>();

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        IList<ClsServiceList> List = ds.Tables[0].AsEnumerable().Select(Row =>
                            new ClsServiceList
                            {
                                Ref_Service_ID = Row.Field<Int64>("Ref_Service_ID"),
                                CategoryName = Row.Field<string>("CategoryName"),
                                ServiceTitle = Row.Field<string>("ServiceTitle"),
                                Description = Row.Field<string>("Description"),
                                Price = Row.Field<decimal>("Price"),
                                Thumbnail = Row.Field<string>("Thumbnail"),
                            }).ToList();
                        objServiceList.AddRange(List);
                    }
                }
                return objServiceList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ClsServiceList> GetServiceListByCategory(int StartCount, int EndCount, string AliasName)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@StartCount", StartCount, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@EndCount", EndCount, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@AliasName", AliasName, DbType.String);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet(Constant.GetServiceListByCategory, ObJParameterCOl, CommandType.StoredProcedure);
                List<ClsServiceList> objServiceList = new List<ClsServiceList>();

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        IList<ClsServiceList> List = ds.Tables[0].AsEnumerable().Select(Row =>
                            new ClsServiceList
                            {
                                Ref_Service_ID = Row.Field<Int64>("Ref_Service_ID"),
                                CategoryName = Row.Field<string>("CategoryName"),
                                ServiceTitle = Row.Field<string>("ServiceTitle"),
                                Description = Row.Field<string>("Description"),
                                Price = Row.Field<decimal>("Price"),
                                Thumbnail = Row.Field<string>("Thumbnail"),
                            }).ToList();
                        objServiceList.AddRange(List);
                    }
                }
                return objServiceList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ClsCustomServiceDetails> GetCustomServiceDetails(Int64 ServiceID)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@ServiceID", ServiceID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet(Constant.GetCustomServiceDetails, ObJParameterCOl, CommandType.StoredProcedure);
                List<ClsCustomServiceDetails> objService = new List<ClsCustomServiceDetails>();

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        IList<ClsCustomServiceDetails> List = ds.Tables[0].AsEnumerable().Select(Row =>
                            new ClsCustomServiceDetails
                            {
                                Ref_Service_ID = Row.Field<Int64>("Ref_Service_ID"),
                                CategoryName = Row.Field<string>("CategoryName"),
                                ServiceTitle = Row.Field<string>("ServiceTitle"),
                                Description = Row.Field<string>("Description"),
                                Revision = Row.Field<int>("Revision"),
                                Price = Row.Field<decimal>("Price"),
                                PriceWithProjectFiles = Row.Field<decimal>("PriceWithProjectFiles"),
                                FAQList = ds.Tables[1].AsEnumerable().Select(Row1 =>
                                    new ClsFAQList
                                    {
                                        Questions = Row1.Field<string>("Question"),
                                        Answer = Row1.Field<string>("Answer")
                                    }).ToList(),
                                FileManager = ds.Tables[2].AsEnumerable().Select(Row2 =>
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
                        objService.AddRange(List);
                    }
                }
                return objService;
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
