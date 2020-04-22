using EDM.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.Models.Admin.UserManagement
{
    public class clsCustomer : clsBase
    {
        public string User_Code { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public bool IsGuestUser { get; set; }
        public string Gender { get; set; }
        public string Bio { get; set; }
        public string Website { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public List<clsAddress> Address { get; set; }
    }

    public class clsAddress : clsBase
    {
        public Int64 Ref_Address_ID { get; set; }
        public string PersonName { get; set; }
        public string Address { get; set; }
        public string Address1 { get; set; }
        public Int64 Ref_Country_ID { get; set; }
        public string Country { get; set; }
        public Int64 Ref_State_ID { get; set; }
        public string State { get; set; }
        public Int64 Ref_City_ID { get; set; }
        public string City { get; set; }
        public Int64 Ref_PinCode_ID { get; set; }
        public string Pincode { get; set; }
        public string LandMark { get; set; }
        public string Mobile { get; set; }
        public bool IsDefaultAddress { get; set; }
        public bool IsBillingAddress { get; set; }
        public bool IsDeliveryAddress { get; set; }
    }

    public class clsRequestOTP : clsBase
    {
        public Int64 Ref_OTP_ID { get; set; }
        public string OTP { get; set; }
        public string Type { get; set; }
        public bool IsValidate { get; set; }
    }
    public class ClsUserData
    {
        public Int64 ref_User_ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public string password { get; set; }
        public string encryptionKey { get; set; }
        public string profilePicUrl { get; set; }
        public List<ClsUserMasterDataMap> userMasterDataMap { get; set; }

    }
    public class ClsUserMasterDataMap
    {
        public Int64 userMasterID { get; set; }
        public Int64 userMasterDataID { get; set; }
        public string userMasterValueTo { get; set; }
        public string userMasterValueFrom { get; set; }

    }
}
