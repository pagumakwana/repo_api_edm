using EDM.BusinessAccessLayer.Admin.TrackManagement;
using EDM.Models.Admin.TrackManagement;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EDM.API.Controllers.Admin.TrackManagement
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Admin")]
    public class TrackManagementController : ApiController
    {

        [Route("TrackManagement/Track")]
        [HttpPost]
        public string AddModifyTrackDetails(ClsTrackDetails ObjTrackDetails)
        {
            using (ClsTrackManagement_BAL obj = new ClsTrackManagement_BAL())
            {
                return obj.AddModifyTrackDetails(ObjTrackDetails);
            }
        }

        [Route("TrackManagement/Track")]
        [HttpGet]
        public List<ClsTrackDetails> GetTrackDetails(Int64 TrackID)
        {
            using (ClsTrackManagement_BAL obj = new ClsTrackManagement_BAL())
            {
                return obj.GetTrackDetails(TrackID);
            }
        }

        [Route("TrackManagement/ManageTrack")]
        [HttpGet]
        public string ManageTrack(string TrackIDs, string Action)
        {
            using (ClsTrackManagement_BAL obj = new ClsTrackManagement_BAL())
            {
                return obj.ManageTrack(TrackIDs, Action);
            }
        }

        [Route("TrackManagement/ApproveAndRejact")]
        [HttpGet]
        public string TrackApproveAndRejact(string TrackIDs, string Action, string ActionBy)
        {
            using (ClsTrackManagement_BAL obj = new ClsTrackManagement_BAL())
            {
                return obj.TrackApproveAndRejact(TrackIDs, Action, ActionBy);
            }
        }

    }
}