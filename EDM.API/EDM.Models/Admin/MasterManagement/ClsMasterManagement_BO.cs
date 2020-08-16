using EDM.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.Models.Admin.MasterManagement
{

    public class ClsParentUserMaster
    {

        public Int64 Ref_UserMaster_ID { get; set; }
        public string UserMaster { get; set; }
        public Boolean IsMandatory { get; set; }
        public string ControlName { get; set; }

        public List<ClsUserMasterData> userMasterData { get; set; }

    }

    public class ClsUserMaster
    {
        public Int64 Ref_UserMaster_ID { get; set; }
        public string ControlName { get; set; }
        public string UserMaster { get; set; }
        public string Description { get; set; }
        public string MandatoryMasterIDs { get; set; }
        public string NonMandatoryMasterIDs { get; set; }
        public Boolean IsMandatory { get; set; }
        public Boolean IsActive { get; set; }
        public string AddedBy { get; set; }
    }

    public class ClsUserMasterData
    {
        public Int64 Ref_UserMasterData_ID { get; set; }
        public Int64 Ref_UserMaster_ID { get; set; }
        public string UserMasterData { get; set; }
        public string UserMaster { get; set; }
        public string Description { get; set; }
        public string MandatoryMasterIDs { get; set; }
        public string NonMandatoryMasterIDs { get; set; }
        public Boolean IsActive { get; set; }
        public string AddedBy { get; set; }
    }

    public class ClsCategoryDetails : clsBase
    {
        public Int64 Ref_Category_ID { get; set; }
        public Int64 Ref_Parent_ID { get; set; }
        public string CategoryName { get; set; }
        public string AliasName { get; set; }
        public Int64 CategoryUseBy { get; set; }
        public string Description { get; set; }
    }

    public class ClsDAW
    {
        public Int64 Ref_DAW_ID { get; set; }
        public string DAW { get; set; }
    }

    public class ClsCouponDetails
    {
        public Int64 Ref_Coupon_ID { get; set; }
        public string CouponCode { get; set; }
        public string CouponUseBy { get; set; }
        public string Description { get; set; }
        public Decimal DiscountInPercentage { get; set; }
        public Decimal DiscountInMax { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Boolean OneTimeUse { get; set; }
        public int AudienceCount { get; set; }
        public Boolean OnlyForNewUsers { get; set; }
        public Boolean IsActive { get; set; }
        public string CreatedBy { get; set; }
        public List<ClsCouponObject> CouponObject { get; set; }
    }
    public class ClsCouponObject
    {
        public Int64 Ref_Object_ID { get; set; }
        public string ObjectType { get; set; }
    }

    public class ClsBlogDetails : clsBase
    {
        public Int64 Ref_Blog_ID { get; set; }
        public string BlogTitle { get; set; }
        public string AliasName { get; set; }
        public string CategoryUseBy { get; set; }
        public string Description { get; set; }
    }
    public class ClsBannerDetails
    {
        public Int64 Ref_Banner_ID { get; set; }
        public string BannerTitle { get; set; }
        public string BannerPageName { get; set; }
        public string Descripation { get; set; }
        public string ImageUrl { get; set; }
        public Boolean IsActive { get; set; }
        public string CreatedBy { get; set; }
    }
}
