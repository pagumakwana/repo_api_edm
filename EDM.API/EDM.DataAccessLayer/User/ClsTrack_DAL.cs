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
        public List<ClsFeaturedTrack> GetFeaturedTrackList(Int64 UserID, int StartCount, int EndCount)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@UserID", UserID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@StartCount", StartCount, DbType.Int16);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@EndCount", EndCount, DbType.Int16);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataTable DT = objDbHelper.ExecuteDataTable(Constant.GetFeaturedTrackList, ObJParameterCOl, CommandType.StoredProcedure);

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
                                Favourite = Row.Field<string>("Favourite"),
                                PlayUrl = Row.Field<string>("PlayUrl"),
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

        public List<ClsTrackAndBeatDetails> GetTrackAndBeatDetails(Int64 UserID, Int64 TrackID)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@UserID", UserID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@TrackID", TrackID, DbType.Int64);
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
                                    Duration = Row.Field<string>("Duration"),
                                    Price = Row.Field<decimal>("Price"),
                                    PriceWithProjectFiles = Row.Field<decimal>("PriceWithProjectFiles"),
                                    BMP = Row.Field<int>("BMP"),
                                    DAW = Row.Field<string>("DAW"),
                                    IsVocals = Row.Field<string>("IsVocals"),
                                    IsTrack = Row.Field<string>("IsTrack"),
                                    Favourite = Row.Field<string>("Favourite"),
                                    FileManager = Ds.Tables[1].AsEnumerable().Where(x => x.Field<Int64>("ModuleID") == Row.Field<Int64>("Ref_Track_ID")).Select(Row1 =>
                                         new ClsFileManager
                                         {
                                             FileIdentifier = Row1.Field<string>("FileIdentifier"),
                                             FileName = Row1.Field<string>("FileName"),
                                             FilePath = Row1.Field<string>("FilePath"),
                                             FileExtension = Row1.Field<string>("FileExtension"),
                                             FileSize = Row1.Field<Int64>("FileSize"),
                                             FileType = Row1.Field<string>("FileType"),
                                             Sequence = Row1.Field<int>("Sequence"),
                                         }).ToList(),
                                    RelatedTrack = Ds.Tables[2].AsEnumerable().Select(Row2 =>
                                        new ClsRelatedTrackList
                                        {
                                            Ref_Track_ID = Row2.Field<Int64>("Ref_Track_ID"),
                                            CategoryName = Row2.Field<string>("CategoryName"),
                                            TrackName = Row2.Field<string>("TrackName"),
                                            Bio = Row2.Field<string>("Bio"),
                                            ThumbnailImageUrl = Row2.Field<string>("ThumbnailImageUrl"),
                                            Price = Row2.Field<decimal>("Price"),
                                            IsTrack = Row2.Field<string>("IsTrack"),
                                            PlayUrl = Row2.Field<string>("PlayUrl"),
                                            Favourite = Row2.Field<string>("Favourite"),
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

        public List<ClsTrackAndBeatList> GetTrackAndBeatList(Int64 UserID, int StartCount, int EndCount)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@UserID", UserID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@StartCount", StartCount, DbType.Int16);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@EndCount", EndCount, DbType.Int16);
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
                                Favourite = Row.Field<string>("Favourite"),
                                PlayUrl = Row.Field<string>("PlayUrl"),
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
