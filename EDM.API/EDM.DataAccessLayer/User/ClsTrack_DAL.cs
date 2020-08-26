using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using EDM.Models.Common;
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
                DataTable DT = objDbHelper.ExecuteDataTable(Constant.GetFeaturedTrackList, CommandType.StoredProcedure);

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
                                Thumbnail = Row.Field<string>("Thumbnail"),
                                Duration = Row.Field<string>("Duration"),
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
                DataSet Ds = objDbHelper.ExecuteDataSet("[dbo].[GetTrackAndBeatDetails]", ObJParameterCOl, CommandType.StoredProcedure);

                List<ClsTrackAndBeatDetails> objTrackAndBeatDetails = new List<ClsTrackAndBeatDetails>();

                if (Ds != null)
                {
                    if (Ds.Tables.Count > 0)
                    {
                        if (Ds.Tables[0].Rows.Count > 0)
                        {
                            IList<ClsTrackAndBeatDetails> List = Ds.Tables[0].AsEnumerable().Select(Row =>
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
                                    Duration = Row.Field<string>("Duration"),
                                    Price = Row.Field<decimal>("Price"),
                                    PriceWithProjectFiles = Row.Field<decimal>("PriceWithProjectFiles"),
                                    BMP = Row.Field<int>("BMP"),
                                    DAW = Row.Field<string>("DAW"),
                                    ProjectFilesUrl = Row.Field<string>("ProjectFilesUrl"),
                                    StemsUrl = Row.Field<string>("StemsUrl"),
                                    MIDIFileUrl = Row.Field<string>("MIDIFileUrl"),
                                    MasterFileUrl = Row.Field<string>("MasterFileUrl"),
                                    UnmasteredFileUrl = Row.Field<string>("UnmasteredFileUrl"),
                                    MixdowFileUrl = Row.Field<string>("MixdowFileUrl"),
                                    IsVocals = Row.Field<string>("IsVocals"),
                                    IsTrack = Row.Field<string>("IsTrack"),
                                    RelatedTrack = Ds.Tables[1].AsEnumerable().Select(Row1 =>
                                        new ClsRelatedTrackList
                                        {
                                            Ref_Track_ID = Row.Field<Int64>("Ref_Track_ID"),
                                            CategoryName = Row.Field<string>("CategoryName"),
                                            TrackName = Row.Field<string>("TrackName"),
                                            Bio = Row.Field<string>("Bio"),
                                            ThumbnailImageUrl = Row.Field<string>("ThumbnailImageUrl"),
                                            Price = Row.Field<decimal>("Price"),
                                            IsTrack = Row.Field<string>("IsTrack"),
                                        }).ToList(),
                                }).ToList();
                            objTrackAndBeatDetails.AddRange(List);
                        }
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
                                BMP = Row.Field<int>("BMP"),
                                DAW = Row.Field<string>("DAW"),
                                ThumbnailImageUrl = Row.Field<string>("ThumbnailImageUrl"),
                                Duration = Row.Field<string>("Duration"),
                                Price = Row.Field<decimal>("Price"),
                                IsTrack = Row.Field<string>("IsTrack"),
                                IsVocals = Row.Field<string>("IsVocals"),
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
