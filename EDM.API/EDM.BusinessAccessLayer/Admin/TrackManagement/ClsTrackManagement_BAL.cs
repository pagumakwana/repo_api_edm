using EDM.DataAccessLayer.Admin.TrackManagement;
using EDM.Models.Admin.TrackManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.BusinessAccessLayer.Admin.TrackManagement
{
    public class ClsTrackManagement_BAL : IDisposable
    {
        public String AddModifyTrackDetails(ClsTrackDetails ObjTrackDetails)
        {
            using (ClsTrackManagement_DAL obj = new ClsTrackManagement_DAL())
            {
                return obj.AddModifyTrackDetails(ObjTrackDetails);
            }
        }

        public List<ClsTrackDetails> GetTrackDetails(Int64 TrackID)
        {
            using (ClsTrackManagement_DAL obj = new ClsTrackManagement_DAL())
            {
                return obj.GetTrackDetails(TrackID);
            }
        }
        public string ManageTrack(string TrackIDs, string Action)
        {
            using (ClsTrackManagement_DAL obj = new ClsTrackManagement_DAL())
            {
                return obj.ManageTrack(TrackIDs, Action);
            }
        }
        public string TrackApproveAndRejact(ClsApproveAndRejact ObjApproveAndRejact)
        {
            using (ClsTrackManagement_DAL obj = new ClsTrackManagement_DAL())
            {
                return obj.TrackApproveAndRejact(ObjApproveAndRejact);
            }
        }

        public void Dispose()
        {

        }
    }
}
