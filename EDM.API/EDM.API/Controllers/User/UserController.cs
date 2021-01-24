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

        [Route("TicketType")]
        [HttpGet]
        public List<ClsTicketType> GetTicketTypeList()
        {
            using (ClsUser_BAL obj = new ClsUser_BAL())
            {
                return obj.GetTicketTypeList();
            }
        }

        [Route("Ticket")]
        [HttpPost]
        public string AddModifyUserTicket(ClsTicketDetails ObjTicket)
        {
            using (ClsUser_BAL obj = new ClsUser_BAL())
            {
                return obj.AddModifyUserTicket(ObjTicket);
            }
        }

        [Route("Ticket")]
        [HttpGet]
        public List<ClsTicketDetails> GetUserTicketList(Int64 UserID = 0, int StartCount = 0, int EndCount = 0)
        {
            using (ClsUser_BAL obj = new ClsUser_BAL())
            {
                return obj.GetUserTicketList(UserID, StartCount, EndCount);
            }
        }

        [Route("Producers")]
        [HttpGet]
        public List<ClsUserDetails> GetProducersList(Int64 UserID = 0, int StartCount = 0, int EndCount = 0)
        {
            using (ClsUser_BAL obj = new ClsUser_BAL())
            {
                return obj.GetProducersList(UserID, StartCount, EndCount);
            }
        }

        [Route("TrackAndBeat")]
        [HttpGet]
        public List<ClsProducerTrackAndBeatList> GetProducerTrackAndBeatList(Int64 ProducersID, Int64 UserID)
        {
            using (ClsUser_BAL obj = new ClsUser_BAL())
            {
                return obj.GetProducerTrackAndBeatList(ProducersID, UserID);
            }
        }

        [Route("CustomServices")]
        [HttpGet]
        public List<ClsProducersServiceList> GetProducersCustomServicesList(Int64 ProducersID)
        {
            using (ClsUser_BAL obj = new ClsUser_BAL())
            {
                return obj.GetProducersCustomServicesList(ProducersID);
            }
        }

        [Route("AvailableProducers")]
        [HttpGet]
        public List<ClsUserDetails> GetAvailableProducersForServices(Int64 UserID, Int64 ServiceID, int StartCount, int EndCount)
        {
            using (ClsUser_BAL obj = new ClsUser_BAL())
            {
                return obj.GetAvailableProducersForServices( UserID, ServiceID, StartCount, EndCount);
            }
        }
    }
}