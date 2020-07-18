﻿using System;
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
        public List<ClsUserDetails> GetProducersList(int StartCount, int EndCount)
        {
            using (ClsUser_BAL obj = new ClsUser_BAL())
            {
                return obj.GetProducersList( StartCount,  EndCount);
            }
        }

        [Route("TrackAndBeat")]
        [HttpPost]
        public List<ClsProducersTrackList> GetProducersTrackAndBeatList(Int64 ProducersID)
        {
            using (ClsUser_BAL obj = new ClsUser_BAL())
            {
                return obj.GetProducersTrackAndBeatList(ProducersID);
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