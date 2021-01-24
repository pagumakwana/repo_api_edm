using EDM.BusinessAccessLayer.Admin.UserManagement;
using EDM.Models.Admin.UserManagement;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EDM.API.Controllers.Admin.UserManagement
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Admin/UserManagement")]
    public class UserManagementController : ApiController
    {
        [Route("Producers")]
        [HttpGet]
        public List<ClsProducersDetails> GetAllProducersList(Int64 UserID = 0, string AccountStatus = "All", int StartCount = 0, int EndCount = 0)
        {
            using (ClsUserManagement_BAL obj = new ClsUserManagement_BAL())
            {
                return obj.GetAllProducersList(UserID, AccountStatus, StartCount, EndCount);
            }
        }

        [Route("ApproveAndRejact")]
        [HttpPost]
        public string ProducerApproveAndRejact(ClsProducersApproveAndRejact ObjApproveAndRejact)
        {
            using (ClsUserManagement_BAL obj = new ClsUserManagement_BAL())
            {
                return obj.ProducerApproveAndRejact(ObjApproveAndRejact);
            }
        }
    }
}