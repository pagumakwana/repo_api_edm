using EDM.DataAccessLayer.User;
using EDM.Models.User;
using System;
using System.Collections.Generic;

namespace EDM.BusinessAccessLayer.User
{
    public class ClsService_BAL : IDisposable
    {
        public List<ClsArtistBranding> GetArtistBrandingList( )
        {
            using (ClsService_DAL obj = new ClsService_DAL())
            {
                return obj.GetArtistBrandingList();
            }
        }

        public void Dispose()
        {

        }
    }
}
