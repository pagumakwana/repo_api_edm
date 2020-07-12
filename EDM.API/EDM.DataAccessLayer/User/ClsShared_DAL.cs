using EDM.Models.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.DataAccessLayer.User
{
    public class ClsShared_DAL : IDisposable
    {
        public List<ClsGlobalSearch> GlobalSearch()
        {
            try
            {
                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet("[dbo].[GlobalSearch]", CommandType.StoredProcedure);
                List<ClsGlobalSearch> objUserMasterData = new List<ClsGlobalSearch>();

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        IList<ClsGlobalSearch> List = ds.Tables[0].AsEnumerable().Select(Row =>
                            new ClsGlobalSearch
                            {
                                Ref_Service_ID = Row.Field<Int64>("Ref_Service_ID"),
                                ServiceTitle = Row.Field<string>("ServiceTitle"),
                                Description = Row.Field<string>("Description"),
                                Price = Row.Field<decimal>("Price"),
                                ThumbnailImageUrl = Row.Field<string>("ThumbnailImageUrl"),
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
