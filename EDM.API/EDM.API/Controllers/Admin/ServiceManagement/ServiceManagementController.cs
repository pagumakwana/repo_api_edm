using EDM.BusinessAccessLayer.Admin.ServiceManagement;
using EDM.Models.Admin.ServiceManagement;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EDM.API.Controllers.Admin.ServiceManagement
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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

        [Route("ServiceManagement/ManageService")]
        [HttpGet]
        public string ManageService(string ServiceIDs, string Action)
        {
            using (ClsServiceManagement_BAL obj = new ClsServiceManagement_BAL())
            {
                return obj.ManageService(ServiceIDs, Action);
            }
        }
    }
}