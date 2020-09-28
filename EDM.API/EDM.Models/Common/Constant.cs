using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.Models.Common
{
    public class Constant
    {

        //START :: MASTERS

        public const string GetDAWList = "[dbo].[GetDAWList]";
        public const string AddModifyUserMaster = "[dbo].[AddModifyUserMaster]";
        public const string GetUserMasterList = "[dbo].[GetUserMasterList]";
        public const string GetParentUserMasterList = "[dbo].[GetParentUserMasterList]";
        public const string AddModifyUserMasterData = "[dbo].[AddModifyUserMasterData]";
        public const string GetUserMasterDataList = "[dbo].[GetUserMasterDataList]";

        public const string AddModifyCouponCode = "[dbo].[AddModifyCouponCode]";
        public const string GetCouponCodeList = "[dbo].[GetCouponCodeList]";
        public const string ManageCouponCode = "[dbo].[ManageCouponCode]";

        public const string AddModifyBannerDetails = "[dbo].[AddModifyBannerDetails]";
        public const string GetBannersList = "[dbo].[GetBannersList]";
        public const string ManageBanner = "[dbo].[ManageBanner]";

        public const string GetModuleList = "[dbo].[GetModuleList]";
        public const string AddModifyAuthority = "[dbo].[AddModifyAuthority]";
        public const string AddModifyAuthorityModuleAccess = "[dbo].[AddModifyAuthorityModuleAccess]";
        public const string GetAuthorityList = "[dbo].[GetAuthorityList]";
        public const string GetAuthorityDetails = "[dbo].[GetAuthorityDetails]";

        public const string GetCategoryList = "[dbo].[GetCategoryList]";
        public const string AddModifyCategory = "[dbo].[AddModifyCategory]";

        public const string RemoveFile = "[dbo].[RemoveFile]";

        public const string GetBlogList = "[dbo].[GetBlogList]";
        public const string ManageBlog = "[dbo].[ManageBlog]";
        public const string AddModifyBlogDetails = "[dbo].[AddModifyBlogDetails]";


        //END :: MASTERS

        //START :: SHARED

        public const string SignUp = "[DBO].[SignUp]";
        public const string SignIn = "[DBO].[SignIn]";
        public const string GlobalSearch = "[dbo].[GlobalSearch]";
        public const string SaveModuleFile = "[dbo].[SaveModuleFile]";
        public const string GetParentCategoryList = "[dbo].[GetParentCategoryList]";
        public const string AddModifyUserAction = "[dbo].[AddModifyUserAction]";
        public const string GetUserActionDetails = "[dbo].[GetUserActionDetails]";
        public const string AddModifyUserOrder = "[dbo].[AddModifyUserOrder]";

        //END :: SHARED

        //START :: USERS AND PRODUCERS

        public const string GetProducersList = "[dbo].[GetProducersList]";
        public const string GetProducerTrackAndBeatList = "[dbo].[GetProducerTrackAndBeatList]";
        public const string GetProducersCustomServicesList = "[dbo].[GetProducersCustomServicesList]";
        public const string GetAvailableProducersForServices = "[dbo].[GetAvailableProducersForServices]";

        //END :: USERS AND PRODUCERS


        //START :: SERVICE

        public const string ManageService = "[dbo].[ManageService]";
        public const string AddModifyServiceFAQ = "[dbo].[AddModifyServiceFAQ]";
        public const string AddModifyServiceDetails = "[dbo].[AddModifyServiceDetails]";

        public const string GetServiceList = "[dbo].[GetServiceList]";
        public const string GetServiceDetails = "[dbo].[GetServiceDetails]";
        public const string GetCustomServiceDetails = "[dbo].[GetCustomServiceDetails]";
        public const string GetServiceListByCategory = "[dbo].[GetServiceListByCategory]";

        //END :: SERVICE

        //START :: TRACK

        public const string ManageTrack = "[dbo].[ManageTrack]";
        public const string GetTrackDetails = "[dbo].[GetTrackDetails]";
        public const string AddModifyTrackDetails = "[dbo].[AddModifyTrackDetails]";
        public const string TrackApproveAndRejact = "[dbo].[TrackApproveAndRejact]";

        public const string GetFeaturedTrackList = "[dbo].[GetFeaturedTrackList]";
        public const string GetTrackAndBeatList = "[dbo].[GetTrackAndBeatList]";
        public const string GetTrackAndBeatDetails = "[dbo].[GetTrackAndBeatDetails]";

        //END :: TRACK


        public const string RegisterGuest = "[dbo].[RegisterGuest]";
        public const string RegisterCustomer = "[dbo].[RegisterCustomer]";
        public const string SignInCustomer = "[dbo].[SignInCustomer]";
        public const string ForgotPassword = "[dbo].[ForgotPassword]";
        public const string ValidateUser = "[dbo].[ValidateUser]";
        public const string RequestOTP = "[dbo].[RequestOTP]";
        public const string SearchKeyword = "[dbo].[SearchKeyword]";
        public const string UpdateCustomerProfile = "[dbo].[UpdateCustomerProfile]";
           

    }

}
