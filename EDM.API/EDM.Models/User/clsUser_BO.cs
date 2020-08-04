using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.Models.User
{
    public class ClsUserDetails
    {
        public Int64 Ref_User_ID { get; set; }
        public string UserCode { get; set; }
        public string FullName { get; set; }
        public string EmailID { get; set; }
        public string ProfilePhoto { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }
        public string Bio { get; set; }
        public string Gender { get; set; }
        public string SocialProfileUrl { get; set; }
        public string StudioGears { get; set; }
        public string GovitID { get; set; }
        public string PayPalEmailID { get; set; }
        public string AuthorityIDs { get; set; }
        public string UserMasterDataIDs { get; set; }
        public string CreatedBy { get; set; }
        public string Response { get; set; }
    }

    public class ClsUserSignIn
    {
        public string User_Code { get; set; }
        public string Password { get; set; }
        public Boolean IsSocialLogin { get; set; }
    }

    public class ClsProducersTrackList
    {
        public Int64 Ref_Track_ID { get; set; }
        public string CategoryName { get; set; }
        public string TrackType { get; set; }
        public string TrackName { get; set; }
        public string Bio { get; set; }
        public int Duration { get; set; }
        public string IsTrack { get; set; }
        public int BMP { get; set; }
        public Decimal Price { get; set; }
        public string ThumbnailImageUrl { get; set; }
        public string TrackStatus { get; set; }
        public string SoldOut { get; set; }

    }

    public class ClsProducersServiceList
    {
        public Int64 Ref_Service_ID { get; set; }
        public string CategoryName { get; set; }
        public string ServiceTitle { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public string ThumbnailImageUrl { get; set; }
    }
}
