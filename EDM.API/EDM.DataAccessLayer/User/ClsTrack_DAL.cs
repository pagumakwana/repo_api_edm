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

                List<ClsFeaturedTrack> objTrack = new List<ClsFeaturedTrack>();

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
                                Bio = Row.Field<string>("Bio"),
                                ThumbnailImageUrl = Row.Field<string>("ThumbnailImageUrl"),
                                Duration = Row.Field<int>("Duration"),
                                Price = Row.Field<decimal>("Price"),
                                IsTrack = Row.Field<string>("IsTrack"),
                            }).ToList();
                        objTrack.AddRange(List);
                    }
                }
                return objTrack;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClsTrackAndBeatDetails> GetTrackAndBeatDetails(Int64 TrackID)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@TrackID", TrackID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataTable DT = objDbHelper.ExecuteDataTable("[dbo].[GetTrackAndBeatDetails]", ObJParameterCOl, CommandType.StoredProcedure);

                List<ClsTrackAndBeatDetails> objTrackAndBeatDetails = new List<ClsTrackAndBeatDetails>();

                if (DT != null)
                {
                    if (DT.Rows.Count > 0)
                    {
                        IList<ClsTrackAndBeatDetails> List = DT.AsEnumerable().Select(Row =>
                            new ClsTrackAndBeatDetails
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
                                IsTrack = Row.Field<string>("IsTrack"),
                            }).ToList();
                        objTrackAndBeatDetails.AddRange(List);
                    }
                }
                return objTrackAndBeatDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClsTrackAndBeatList> GetTrackAndBeatList(int StartCount, int EndCount)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@StartCount", StartCount, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@EndCount", EndCount, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataTable DT = objDbHelper.ExecuteDataTable("[dbo].[GetTrackAndBeatList]", ObJParameterCOl, CommandType.StoredProcedure);

                List<ClsTrackAndBeatList> objTrackAndBeat = new List<ClsTrackAndBeatList>();

                if (DT != null)
                {
                    if (DT.Rows.Count > 0)
                    {
                        IList<ClsTrackAndBeatList> List = DT.AsEnumerable().Select(Row =>
                            new ClsTrackAndBeatList
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
                                Duration = Row.Field<int>("Duration"),
                                Price = Row.Field<decimal>("Price"),
                                IsTrack = Row.Field<string>("IsTrack"),
                            }).ToList();
                        objTrackAndBeat.AddRange(List);
                    }
                }
                return objTrackAndBeat;
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
