﻿using EDM.BusinessAccessLayer.Admin.ServiceManagement;
using EDM.Models.Admin.ServiceManagement;
using System;
using System.Collections.Generic;
using System.Web.Http;


namespace EDM.API.Controllers.Admin.ServiceManagement
{
    [RoutePrefix("api/Admin")]
    public class ServiceManagementController : ApiController
    {
        [Route("ServiceManagement/Service")]
        [HttpPost]
        public string AddModifyServiceDetails(ClsServiceDetails ObjServiceDetails)
        {
            using (ClsServiceManagement_BAL obj = new ClsServiceManagement_BAL())
            {
                return obj.AddModifyServiceDetails(ObjServiceDetails);
            }
        }

        [Route("ServiceManagement/Service")]
        [HttpGet]
        public List<ClsServiceDetails> GetServiceDetails(Int64 ServiceID)
        {
            using (ClsServiceManagement_BAL obj = new ClsServiceManagement_BAL())
            {
                return obj.GetServiceDetails(ServiceID);
            }
        }

    }
}