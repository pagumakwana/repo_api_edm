using EDM.BusinessAccessLayer.Admin.ServiceManagement;
using EDM.Models.Admin.ServiceManagement;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EDM.API.Controllers.Admin.ServiceManagement
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Admin/ServiceManagement")]
    public class ServiceManagementController : ApiController
    {
        [Route("Service")]
        [HttpPost]
        public string AddModifyServiceDetails(ClsServiceDetails ObjServiceDetails)
        {
            using (ClsServiceManagement_BAL obj = new ClsServiceManagement_BAL())
            {
                return obj.AddModifyServiceDetails(ObjServiceDetails);
            }
        }

        [Route("Service")]
        [HttpGet]
        public List<ClsServiceDetails> GetServiceDetails(string Flag, Int64 Ref_Service_ID, string AliasName)
        {
            using (ClsServiceManagement_BAL obj = new ClsServiceManagement_BAL())
            {
                return obj.GetServiceDetails(Flag, Ref_Service_ID, AliasName);
            }
        }

        [Route("ManageService")]
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