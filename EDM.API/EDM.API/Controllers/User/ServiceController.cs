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

        [Route("List")]
        [HttpGet]
        public List<ClsServiceList> GetServiceList(int StartCount, int EndCount)
        {
            using (ClsService_BAL obj = new ClsService_BAL())
            {
                return obj.GetServiceList(StartCount, EndCount);
            }
        }

        [Route("ServiceByCategory")]
        [HttpGet]
        public List<ClsServiceList> GetServiceListByCategory(int StartCount, int EndCount, string AliasName)
        {
            using (ClsService_BAL obj = new ClsService_BAL())
            {
                return obj.GetServiceListByCategory(StartCount, EndCount, AliasName);
            }
        }

        [Route("CustomServiceDetails")]
        [HttpGet]
        public List<ClsCustomServiceDetails> GetCustomServiceDetails(Int64 ServiceID)
        {
            using (ClsService_BAL obj = new ClsService_BAL())
            {
                return obj.GetCustomServiceDetails(ServiceID);
            }
        }

    }
}