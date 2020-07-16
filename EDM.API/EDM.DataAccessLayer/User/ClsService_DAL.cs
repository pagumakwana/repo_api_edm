using EDM.Models.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EDM.DataAccessLayer.User
{
    public class ClsService_DAL : IDisposable
    {
        public List<ClsArtistBranding> GetArtistBrandingList()
        {
            try
            {
                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet("[dbo].[GetArtistBrandingList]",  CommandType.StoredProcedure);
                List<ClsArtistBranding> objUserMasterData = new List<ClsArtistBranding>();

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        IList<ClsArtistBranding> List = ds.Tables[0].AsEnumerable().Select(Row =>
                            new ClsArtistBranding
                            {
                                Ref_Service_ID = Row.Field<Int64>("Ref_Service_ID"),
                                CategoryName = Row.Field<string>("CategoryName"),
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
