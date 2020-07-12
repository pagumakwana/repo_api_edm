using EDM.Models.User;
using System;
using System.Collections.Generic;
using EDM.DataAccessLayer.User;


namespace EDM.BusinessAccessLayer.User
{
    public class ClsTrack_BAL : IDisposable
    {

        public List<ClsFeaturedTrack> GetFeaturedTrackList()
        {
            using (ClsTrack_DAL obj = new ClsTrack_DAL())
            {
                return obj.GetFeaturedTrackList();
            }
        }

        public void Dispose()
        {

        }
    }
}
