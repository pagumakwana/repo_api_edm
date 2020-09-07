using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using EDM.Models.User;
using EDM.BusinessAccessLayer.User;
using System.Web.Http.Cors;

namespace EDM.API.Controllers.User
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        [Route("SignUp")]
        [HttpPost]
        public string SignUp(ClsUserDetails ObjUser)
        {
            using (ClsUser_BAL obj = new ClsUser_BAL())
            {
                return obj.SignUp(ObjUser);
            }
        }

        [Route("SignIn")]
        [HttpPost]
        public List<ClsUserDetails> SignIn(ClsUserSignIn ObjUser)
        {
            using (ClsUser_BAL obj = new ClsUser_BAL())
            {
                return obj.SignIn(ObjUser);
            }
        }

        [Route("Producers")]
        [HttpPost]
        public List<ClsUserDetails> GetProducersList(Int64 UserID, int StartCount, int EndCount)
        {
            using (ClsUser_BAL obj = new ClsUser_BAL())
            {
                return obj.GetProducersList(UserID, StartCount, EndCount);
            }
        }

        [Route("TrackAndBeat")]
        [HttpPost]
        public List<ClsProducerTrackAndBeatList> GetProducerTrackAndBeatList(Int64 ProducersID, Int64 UserID)
        {
            using (ClsUser_BAL obj = new ClsUser_BAL())
            {
                return obj.GetProducerTrackAndBeatList(ProducersID, UserID);
            }
        }

        [Route("CustomServices")]
        [HttpPost]
        public List<ClsProducersServiceList> GetProducersCustomServicesList(Int64 ProducersID)
        {
            using (ClsUser_BAL obj = new ClsUser_BAL())
            {
                return obj.GetProducersCustomServicesList(ProducersID);
            }
        }
    }
}