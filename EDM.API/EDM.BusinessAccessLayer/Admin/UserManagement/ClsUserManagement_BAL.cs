using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDM.DataAccessLayer.Admin.UserManagement;
using EDM.Models.Admin.UserManagement;

namespace EDM.BusinessLayer.Admin.UserManagement
{
   public class ClsUserManagement_BAL : IDisposable
    {
        public List<clsCustomer> RegisterCustomer(clsCustomer objclsCustomer)
        {
            using (ClsUserManagement_DAL objClsUserManagement_DAL = new ClsUserManagement_DAL())
            {
                return objClsUserManagement_DAL.RegisterCustomer(objclsCustomer);
            }
        }

        public List<clsCustomer> SignInCustomer(clsCustomer objclsCustomer)
        {
            using (ClsUserManagement_DAL objClsUserManagement_DAL = new ClsUserManagement_DAL())
            {
                return objClsUserManagement_DAL.SignInCustomer(objclsCustomer);
            }
        }

        public string RegisterGuest()
        {
            using (ClsUserManagement_DAL objClsUserManagement_DAL = new ClsUserManagement_DAL())
            {
                return objClsUserManagement_DAL.RegisterGuest();
            }
        }

        public string ForgotPassword(string Flag, Int64 Ref_User_ID, Int64 Password)
        {
            using (ClsUserManagement_DAL objClsUserManagement_DAL = new ClsUserManagement_DAL())
            {
                return objClsUserManagement_DAL.ForgotPassword(Flag, Ref_User_ID, Password);
            }
        }

        public List<clsCustomer> ValidateUser(string UserCode)
        {
            using (ClsUserManagement_DAL objClsUserManagement_DAL = new ClsUserManagement_DAL())
            {
                return objClsUserManagement_DAL.ValidateUser(UserCode);
            }
        }

        public string RequestOTP(clsRequestOTP objclsRequestOTP)
        {
            using (ClsUserManagement_DAL objClsUserManagement_DAL = new ClsUserManagement_DAL())
            {
                return objClsUserManagement_DAL.RequestOTP(objclsRequestOTP);
            }
        }

        public List<clsCustomer> ProfileUpdate(clsCustomer objclsCustomer)
        {
            using (ClsUserManagement_DAL objClsUserManagement_DAL = new ClsUserManagement_DAL())
            {
                return objClsUserManagement_DAL.ProfileUpdate(objclsCustomer);
            }
        }
        public void Dispose()
        {

        }
    }
}
