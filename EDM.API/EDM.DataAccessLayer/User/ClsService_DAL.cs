using EDM.Models.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EDM.DataAccessLayer.User
{
    public class ClsService_DAL : IDisposable
    {
        public List<ClsCustomServiceList> GetServiceListByCategory(int StartCount, int EndCount, string CategoryName)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@StartCount", StartCount, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@EndCount", EndCount, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@CategoryName", CategoryName, DbType.String);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet("[dbo].[GetServiceListByCategory]", ObJParameterCOl, CommandType.StoredProcedure);
                List<ClsCustomServiceList> objServiceList = new List<ClsCustomServiceList>();

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        IList<ClsCustomServiceList> List = ds.Tables[0].AsEnumerable().Select(Row =>
                            new ClsCustomServiceList
                            {
                                Ref_Service_ID = Row.Field<Int64>("Ref_Service_ID"),
                                CategoryName = Row.Field<string>("CategoryName"),
                                ServiceTitle = Row.Field<string>("ServiceTitle"),
                                Description = Row.Field<string>("Description"),
                                Price = Row.Field<decimal>("Price"),
                                ThumbnailImageUrl = Row.Field<string>("ThumbnailImageUrl"),
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
                DataSet ds = objDbHelper.ExecuteDataSet("[dbo].[GetCustomServiceDetails]", ObJParameterCOl, CommandType.StoredProcedure);
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
                                BigImageUrl = Row.Field<string>("BigImageUrl"),
                                Price = Row.Field<decimal>("Price"),
                                PriceWithProjectFiles = Row.Field<decimal>("PriceWithProjectFiles"),
                                ServiceVideoUrl = Row.Field<string>("ServiceVideoUrl"),
                                ProjectFilesUrl = Row.Field<string>("ProjectFilesUrl"),
                                ThumbnailImageUrl = Row.Field<string>("ThumbnailImageUrl"),
                                Revision = Row.Field<int>("Revision"),
                                FAQList = ds.Tables[1].AsEnumerable().Where(x => x.Field<Int64>("Ref_Service_ID") == Row.Field<Int64>("Ref_Service_ID")).Select(Row1 =>
                                    new ClsFAQList
                                    {
                                        Questions = Row1.Field<string>("Question"),
                                        Answer = Row1.Field<string>("Answer")
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
