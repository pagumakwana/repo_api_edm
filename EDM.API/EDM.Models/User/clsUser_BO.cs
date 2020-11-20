using EDM.Models.Common;
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
        public string MobileNumber { get; set; }
        public string Password { get; set; }
        public string Bio { get; set; }
        public string Gender { get; set; }
        public string ProfilePhoto { get; set; }
        public string StudioGears { get; set; }
        public string SocialProfileUrl { get; set; }
        public string PayPalEmailID { get; set; }
        public string AuthorityIDs { get; set; }
        public string UserMasterDataIDs { get; set; }
        public string CreatedBy { get; set; }
        public string Followed { get; set; }
        public string Response { get; set; }
        public List<ClsFileManager> FileManager { get; set; }
        public List<ClsUserMasterMapping> UserMaster { get; set; }
    }
    public class ClsUserMasterMapping
    {
        public string MasterName { get; set; }
        public string MasterDataName { get; set; }
    }
    public class ClsUserSignIn
    {
        public string User_Code { get; set; }
        public string Password { get; set; }
        public Boolean IsSocialLogin { get; set; }
    }
    public class ClsTicketType
    {
        public Int64 Ref_TicketType_ID { get; set; }
        public string TicketType { get; set; }
    }
    public class ClsTicketDetails
    {
        public Int64 Ref_Ticket_ID { get; set; }
        public Int64 Ref_TicketType_ID { get; set; }
        public Int64 Ref_User_ID { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public List<ClsFileManager> FileManager { get; set; }
    }

    public class ClsProducerTrackAndBeatList
    {
        public string ProducerName { get; set; }
        public string ProfilePhoto { get; set; }
        public string ProducerBio { get; set; }
        public string ProducerFrom { get; set; }
        public string Followed { get; set; }
        public Int64 Followers { get; set; }
        public Int64 Following { get; set; }
        public Int64 Plays { get; set; }
        public List<ClsTrackAndBeatList> TrackAndBeat { get; set; }
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

    public class ClsAvailableProducers
    {
        public Int64 Ref_User_ID { get; set; }
        public string UserCode { get; set; }
        public string FullName { get; set; }
        public string EmailID { get; set; }
        public string MobileNumber { get; set; }
        public string Bio { get; set; }
        public string Gender { get; set; }
        public string ProfilePhoto { get; set; }
        public string StudioGears { get; set; }
        public string SocialProfileUrl { get; set; }
        public string Followed { get; set; }
        public string ProducerFrom { get; set; }

    }
}
