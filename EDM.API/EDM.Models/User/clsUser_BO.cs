using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.Models.User
{
    public class ClsUserSignUp
    {
        public string User_Code { get; set; }
        public string FullName { get; set; }
        public string EmailID { get; set; }
        public string Profile_Photo { get; set; }
        public string Password { get; set; }
        public string CreatedName { get; set; }
    }
    public class ClsUserSignIn
    {
        public string User_Code { get; set; }
        public string Password { get; set; }
        public Boolean IsSocialLogin { get; set; }
    }

    public class ClsUserDetails
    {
        public Int64 Ref_User_ID { get; set; }
        public string User_Code { get; set; }
        public string FullName { get; set; }
        public string EmailID { get; set; }
        public string MobileNumber { get; set; }
        public string Profile_Photo { get; set; }
        public string Bio { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public Int64 CreatedBy { get; set; }
        public string CreatedName { get; set; }
        public Int64 UpdatedBy { get; set; }
        public string UpdatedName { get; set; }
        public Nullable<DateTime> CreatedDateTime { get; set; }
        public Nullable<DateTime> UpdatedDateTime { get; set; }
        public string ResponseMessage { get; set; }
    }
}
