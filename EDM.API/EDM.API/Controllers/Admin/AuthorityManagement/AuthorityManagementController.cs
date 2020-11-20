using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using EDM.BusinessLayer.Admin.AuthorityManagement;
using EDM.Models.Admin.AuthorityManagement;


namespace EDM.API.Controllers.Admin.AuthorityManagement
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Admin")]
    public class AuthorityManagementController : ApiController
    {

        [Route("AuthorityManagement/Module")]
        [HttpGet]
        public List<ClsModuleList> GetModuleList()
        {
            using (ClsAuthorityManagement_BAL obj = new ClsAuthorityManagement_BAL())
            {
                return obj.GetModuleList();
            }
        }

        [Route("AuthorityManagement/Authority")]
        [HttpPost]
        public string AddModifyAuthority(ClsAuthority ObjAuthority)
        {
            using (ClsAuthorityManagement_BAL obj = new ClsAuthorityManagement_BAL())
            {
                return obj.AddModifyAuthority(ObjAuthority);
            }
        }

        [Route("AuthorityManagement/Authority")]
        [HttpGet]
        public List<ClsAuthorityList> GetAuthorityList()
        {
            using (ClsAuthorityManagement_BAL obj = new ClsAuthorityManagement_BAL())
            {
                return obj.GetAuthorityList();
            }
        }

        [Route("AuthorityManagement/AuthorityDetails")]
        [HttpGet]
        public List<ClsAuthority> GetAuthorityDetails(Int64 AuthorityID)
        {
            using (ClsAuthorityManagement_BAL obj = new ClsAuthorityManagement_BAL())
            {
                return obj.GetAuthorityDetails(AuthorityID);
            }
        }

        [Route("AuthorityManagement/ModuleAccess")]
        [HttpGet]
        public List<ClsModuleList> GetUserModuleAccess(Int64 UserID,Int64 ModuleID)
        {
            using (ClsAuthorityManagement_BAL obj = new ClsAuthorityManagement_BAL())
            {
                return obj.GetUserModuleAccess(UserID, ModuleID);
            }
        }
    }
}