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
        public List<ClsUserMasterData> GetUserMasterDataList(Int64 UserMasterID)
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.GetUserMasterDataList(UserMasterID);
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
        public List<ClsCategoryDetails> GetCategoryList(string Flag, Int64 Ref_Category_ID)
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.GetCategoryList(Flag, Ref_Category_ID);
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

    }
}