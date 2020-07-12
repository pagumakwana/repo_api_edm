using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using EDM.BusinessAccessLayer.User;
using EDM.Models.User;

namespace EDM.API.Controllers.User
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/User/Track")]
    public class TrackController : ApiController
    {
        [Route("FeaturedTrack")]
        [HttpGet]
        public List<ClsFeaturedTrack> GetFeaturedTrackList( )
        {
            using (ClsTrack_BAL obj = new ClsTrack_BAL())
            {
                return obj.GetFeaturedTrackList();
            }
        }
    }
}