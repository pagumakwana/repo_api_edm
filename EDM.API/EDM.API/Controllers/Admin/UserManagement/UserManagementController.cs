using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using EDM.BusinessLayer.Admin.UserManagement;
using EDM.Models.Admin.UserManagement;

namespace EDM.API.Controllers.Admin.UserManagement
{
    [RoutePrefix("api/EDM/Admin")]
    public class UserManagementController : ApiController
    {
        [Route("UserManagement/User")]
        [HttpPost]
        public string AddModifyUser(ClsUserDetails ObjUser)
        {
            using (ClsUserManagement_BAL obj = new ClsUserManagement_BAL())
            {
                return obj.AddModifyUser(ObjUser);
            }
        }

    }
}