using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using EDM.BusinessLayer.Admin.UserManagement;
using EDM.Models.Admin.UserManagement;
using System.Web.Http.Cors;

namespace EDM.API.Controllers.Admin.UserManagement
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    [RoutePrefix("api/Admin/UserManagement")]
    public class UserManagementController : ApiController
    {

        [Route("RegisterCustomer")]
        [HttpPost]
        public List<clsCustomer> RegisterCustomer(clsCustomer objclsCustomer)
        {
            using (ClsUserManagement_BAL objClsUserManagement_BAL = new ClsUserManagement_BAL())
            {
                return objClsUserManagement_BAL.RegisterCustomer(objclsCustomer);
            }
        }

        [Route("SignIn")]
        [HttpPost]
        public List<clsCustomer> SignInCustomer(clsCustomer objclsCustomer)
        {
            using (ClsUserManagement_BAL objClsUserManagement_BAL = new ClsUserManagement_BAL())
            {
                return objClsUserManagement_BAL.SignInCustomer(objclsCustomer);
            }
        }

        [Route("RegisterGuest")]
        [HttpPost]
        public string RegisterGuest()
        {
            using (ClsUserManagement_BAL objClsUserManagement_BAL = new ClsUserManagement_BAL())
            {
                return objClsUserManagement_BAL.RegisterGuest();
            }
        }

        [Route("ForgotPassword")]
        [HttpPost]
        public string ForgotPassword(string Flag, Int64 Ref_User_ID, Int64 Password)
        {
            using (ClsUserManagement_BAL objClsUserManagement_BAL = new ClsUserManagement_BAL())
            {
                return objClsUserManagement_BAL.ForgotPassword(Flag, Ref_User_ID, Password);
            }
        }

        [Route("ValidateUser")]
        [HttpGet]
        public List<clsCustomer> ValidateUser(string UserCode)
        {
            using (ClsUserManagement_BAL objClsUserManagement_BAL = new ClsUserManagement_BAL())
            {
                return objClsUserManagement_BAL.ValidateUser(UserCode);
            }
        }

        [Route("RequestOTP")]
        [HttpPost]
        public string RequestOTP(clsRequestOTP objclsRequestOTP)
        {
            using (ClsUserManagement_BAL objClsUserManagement_BAL = new ClsUserManagement_BAL())
            {
                return objClsUserManagement_BAL.RequestOTP(objclsRequestOTP);
            }
        }

        [Route("ProfileUpdate")]
        [HttpPost]
        public List<clsCustomer> ProfileUpdate(clsCustomer objclsCustomer)
        {
            using (ClsUserManagement_BAL objClsUserManagement_BAL = new ClsUserManagement_BAL())
            {
                return objClsUserManagement_BAL.ProfileUpdate(objclsCustomer);
            }
        }

    }
}