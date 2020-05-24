using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using EDM.BusinessLayer.Admin.UserManagement;
using System.Web.Http.Cors;

namespace EDM.API.Controllers.Admin.UserManagement
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    [RoutePrefix("api/Admin")]
    public class UserManagementController : ApiController
    {


    }
}