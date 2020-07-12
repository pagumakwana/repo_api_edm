using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using EDM.Models.User;

namespace EDM.DataAccessLayer.User
{
    public class ClsTrack_DAL : IDisposable
    {
        public List<ClsFeaturedTrack> GetFeaturedTrackList()
        {
            try
            {
                DBHelper objDbHelper = new DBHelper();
                DataTable DT = objDbHelper.ExecuteDataTable("[dbo].[GetFeaturedTrackList]", CommandType.StoredProcedure);

                List<ClsFeaturedTrack> objUserMasterData = new List<ClsFeaturedTrack>();

                if (DT != null)
                {
                    if (DT.Rows.Count > 0)
                    {
                        IList<ClsFeaturedTrack> List = DT.AsEnumerable().Select(Row =>
                            new ClsFeaturedTrack
                            {
                                Ref_Track_ID = Row.Field<Int64>("Ref_Track_ID"),
                                CategoryName = Row.Field<string>("CategoryName"),
                                TrackName = Row.Field<string>("TrackName"),
                                TrackType = Row.Field<string>("TrackType"),
                                Bio = Row.Field<string>("Bio"),
                                Mood = Row.Field<string>("Mood"),
                                Key = Row.Field<string>("TrackKey"),
                                Tag = Row.Field<string>("Tag"),
                                ThumbnailImageUrl = Row.Field<string>("ThumbnailImageUrl"),
                                BigImageUrl = Row.Field<string>("BigImageUrl"),
                                Duration = Row.Field<int>("Duration"),
                                Price = Row.Field<decimal>("Price"),
                                IsTrack = Row.Field<Boolean>("IsTrack"),
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
