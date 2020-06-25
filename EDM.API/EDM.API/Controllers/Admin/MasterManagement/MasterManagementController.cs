using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using EDM.BusinessLayer.Admin.MasterManagement;
using EDM.Models.Admin.MasterManagement;


namespace EDM.API.Controllers.Admin.MasterManagement
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Admin")]
    public class MasterManagementController : ApiController
    {

        [Route("MasterManagement/UserMaster")]
        [HttpPost]
        public string AddModifyUserMaster(ClsUserMaster ObjUserMaster)
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.AddModifyUserMaster(ObjUserMaster);
            }
        }

        [Route("MasterManagement/UserMaster")]
        [HttpGet]
        public List<ClsUserMaster> GetUserMasterList(Int64 UserMasterID)
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.GetUserMasterList(UserMasterID);
            }
        }

        [Route("MasterManagement/ParentUserMaster")]
        [HttpGet]
        public List<ClsParentUserMaster> GetParentUserMasterList(Int64 UserMasterID)
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.GetParentUserMasterList(UserMasterID);
            }
        }


        [Route("MasterManagement/UserMasterData")]
        [HttpPost]
        public string AddModifyUserMasterData(ClsUserMasterData ObjUserMasterData)
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.AddModifyUserMasterData(ObjUserMasterData);
            }
        }

        [Route("MasterManagement/UserMasterData")]
        [HttpGet]
        public List<ClsUserMasterData> GetUserMasterDataList(Int64 UserMasterID)
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.GetUserMasterDataList(UserMasterID);
            }
        }

        [Route("MasterManagement/Category")]
        [HttpPost]
        public string AddModifyCategory(ClsCategoryDetails ObjCategory)
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.AddModifyCategory(ObjCategory);
            }
        }

        [Route("MasterManagement/Category")]
        [HttpGet]
        public List<ClsCategoryDetails> GetCategoryList()
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.GetCategoryList();
            }
        }

        [Route("MasterManagement/DAW")]
        [HttpGet]
        public List<ClsDAW> GetDAWList()
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.GetDAWList();
            }
        }

        [Route("MasterManagement/CouponCode")]
        [HttpPost]
        public string AddModifyCouponCode(ClsCategoryDetails ObjCategory)
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.AddModifyCouponCode(ObjCategory);
            }
        }

        [Route("MasterManagement/CouponCode")]
        [HttpGet]
        public List<ClsCategoryDetails> GetCouponCodeList()
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.GetCouponCodeList();
            }
        }

    }
}