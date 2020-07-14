using EDM.BusinessAccessLayer.User;
using EDM.Models.User;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EDM.API.Controllers.User
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/User/Service")]
    public class ServiceController : ApiController
    {
        [Route("ArtistBranding")]
        [HttpGet]
        public List<ClsArtistBranding> GetArtistBrandingList( )
        {
            using (ClsService_BAL obj = new ClsService_BAL())
            { 
                return obj.GetArtistBrandingList();
            }
        }
    }
}