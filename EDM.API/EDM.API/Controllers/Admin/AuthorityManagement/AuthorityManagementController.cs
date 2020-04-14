using System;
using System.Collections.Generic;
using System.Web.Http;
using EDM.BusinessLayer.Admin.AuthorityManagement;
using EDM.Models.Admin.AuthorityManagement;


namespace EDM.API.Controllers.Admin.AuthorityManagement
{
    [RoutePrefix("api/EDM/Admin")]
    public class AuthorityManagementController : ApiController
    {
        [Route("AuthorityManagement/Authority")]
        [HttpPost]
        public string AddUserMaster(ClsAuthority ObjAuthority)
        {
            using (ClsAuthorityManagement_BAL obj = new ClsAuthorityManagement_BAL())
            {
                return obj.AddModifyAuthority(ObjAuthority);
            }
        }

        [Route("AuthorityManagement/Authority")]
        [HttpPost]
        public List<ClsAuthorityList> GetAuthorityList()
        {
            using (ClsAuthorityManagement_BAL obj = new ClsAuthorityManagement_BAL())
            {
                return obj.GetAuthorityList();
            }
        }

        [Route("AuthorityManagement/AuthorityDetails")]
        [HttpPost]
        public List<ClsAuthority> GetAuthorityDetails(Int64 AuthorityID)
        {
            using (ClsAuthorityManagement_BAL obj = new ClsAuthorityManagement_BAL())
            {
                return obj.GetAuthorityDetails(AuthorityID);
            }
        }
    }
}