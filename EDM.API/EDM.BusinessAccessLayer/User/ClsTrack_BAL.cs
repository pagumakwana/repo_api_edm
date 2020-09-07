using EDM.Models.User;
using System;
using System.Collections.Generic;
using EDM.DataAccessLayer.User;


namespace EDM.BusinessAccessLayer.User
{
    public class ClsTrack_BAL : IDisposable
    {

        public List<ClsFeaturedTrack> GetFeaturedTrackList(Int64 UserID, int StartCount, int EndCount)
        {
            using (ClsTrack_DAL obj = new ClsTrack_DAL())
            {
                return obj.GetFeaturedTrackList(UserID, StartCount, EndCount);
            }
        }

        public List<ClsTrackAndBeatDetails> GetTrackAndBeatDetails(Int64 UserID, Int64 TrackID)
        {
            using (ClsTrack_DAL obj = new ClsTrack_DAL())
            {
                return obj.GetTrackAndBeatDetails(UserID, TrackID);
            }
        }

        public List<ClsTrackAndBeatList> GetTrackAndBeatList(Int64 UserID, int StartCount, int EndCount)
        {
            using (ClsTrack_DAL obj = new ClsTrack_DAL())
            {
                return obj.GetTrackAndBeatList(UserID, StartCount, EndCount);
            }
        }

        public void Dispose()
        {

        }
    }
}
