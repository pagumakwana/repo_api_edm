using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using EDM.BusinessLayer.Admin.MasterManagement;
using EDM.Models.Admin.MasterManagement;


namespace EDM.API.Controllers.Admin.MasterManagement
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Admin/MasterManagement")]
    public class MasterManagementController : ApiController
    {

        [Route("UserMaster")]
        [HttpPost]
        public string AddModifyUserMaster(ClsUserMaster ObjUserMaster)
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.AddModifyUserMaster(ObjUserMaster);
            }
        }

        [Route("UserMaster")]
        [HttpGet]
        public List<ClsUserMaster> GetUserMasterList(Int64 UserMasterID)
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.GetUserMasterList(UserMasterID);
            }
        }

        [Route("ParentUserMaster")]
        [HttpGet]
        public List<ClsParentUserMaster> GetParentUserMasterList(Int64 UserMasterID)
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.GetParentUserMasterList(UserMasterID);
            }
        }


        [Route("UserMasterData")]
        [HttpPost]
        public string AddModifyUserMasterData(ClsUserMasterData ObjUserMasterData)
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.AddModifyUserMasterData(ObjUserMasterData);
            }
        }

        [Route("UserMasterData")]
        [HttpGet]
        public List<ClsUserMasterData> GetUserMasterDataList(Int64 UserMasterID, Int64 UserMasterDataID)
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.GetUserMasterDataList( UserMasterID,  UserMasterDataID);
            }
        }

        [Route("Category")]
        [HttpPost]
        public string AddModifyCategory(ClsCategoryDetails ObjCategory)
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.AddModifyCategory(ObjCategory);
            }
        }

        [Route("Category")]
        [HttpGet]
        public List<ClsCategoryDetails> GetCategoryList(string Flag, Int64 Ref_Category_ID, string AliasName)
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.GetCategoryList(Flag, Ref_Category_ID, AliasName);
            }
        }

        [Route("DAW")]
        [HttpGet]
        public List<ClsDAW> GetDAWList()
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.GetDAWList();
            }
        }

        [Route("CouponCode")]
        [HttpPost]
        public string AddModifyCouponCode(ClsCouponDetails ObjCouponDetails)
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.AddModifyCouponCode(ObjCouponDetails);
            }
        }

        [Route("CouponCode")]
        [HttpGet]
        public List<ClsCouponDetails> GetCouponCodeList()
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.GetCouponCodeList();
            }
        }

        [Route("ManageCouponCode")]
        [HttpGet]
        public string ManageCouponCode(string CouponIDs, string Action)
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.ManageCouponCode(CouponIDs, Action);
            }
        }

        [Route("Blog")]
        [HttpPost]
        public string AddModifyBlogDetails(ClsBlogDetails ObjBlog)
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.AddModifyBlogDetails(ObjBlog);
            }
        }

        [Route("Blog")]
        [HttpGet]
        public List<ClsBlogDetails> GetBlogList(Int64 Ref_Blog_ID)
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.GetBlogList(Ref_Blog_ID);
            }
        }

        [Route("ManageBlog")]
        [HttpGet]
        public string ManageBlog(string BlogIDs, string Action)
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.ManageBlog(BlogIDs, Action);
            }
        }

        [Route("Carousel")]
        [HttpPost]
        public string AddModifyBannerDetails(ClsBannerDetails ObjBannerDetails)
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.AddModifyBannerDetails(ObjBannerDetails);
            }
        }

        [Route("CarouselList")]
        [HttpGet]
        public List<ClsBannerDetails> GetBannersList(Int64 CarouselID)
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.GetBannersList(CarouselID);
            }
        }

        [Route("ManageCarousel")]
        [HttpGet]
        public string ManageBanner(string BannerIDs, string Action)
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.ManageBanner(BannerIDs, Action);
            }
        }

    }
}