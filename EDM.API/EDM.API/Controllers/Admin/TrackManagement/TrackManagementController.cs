﻿using EDM.BusinessAccessLayer.Admin.TrackManagement;
using EDM.Models.Admin.TrackManagement;
using System;
using System.Collections.Generic;
using System.Web.Http;


namespace EDM.API.Controllers.Admin.TrackManagement
{
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

    }
}