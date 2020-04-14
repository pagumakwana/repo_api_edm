using System;
using System.Collections.Generic;
using System.Web.Http;
using EDM.BusinessLayer.Admin.MasterManagement;
using EDM.Models.Admin.MasterManagement;


namespace EDM.API.Controllers.Admin.MasterManagement
{

    [RoutePrefix("api/EDM/Admin")]
    public class MasterManagementController : ApiController
    {
        [Route("MasterManagement/UserMasterControl")]
        [HttpPost]
        public List<ClsUserMasterControl> GetUserMasterControlList()
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.GetUserMasterControlList();
            }
        }

        [Route("MasterManagement/UserMaster")]
        [HttpPost]
        public string AddUserMaster(ClsUserMaster ObjUserMaster)
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.AddUserMaster(ObjUserMaster);
            }
        }

        [Route("MasterManagement/UserMaster")]
        [HttpGet]
        public List<ClsUserMaster> GetUserMasterList()
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.GetUserMasterList();
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
        public string AddUserMasterData(ClsUserMasterData ObjUserMasterData)
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.AddUserMasterData(ObjUserMasterData);
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

        [Route("MasterManagement/MeasureType")]
        [HttpPost]
        public List<ClsMeasureTypeNameList> GetMeasureTypeList()
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.GetMeasureTypeList();
            }
        }


        [Route("MasterManagement/MeasureName")]
        [HttpPost]
        public List<ClsMeasureNameList> GetMeasureNameList()
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.GetMeasureNameList();
            }
        }
        [Route("MasterManagement/CategoryName")]
        [HttpPost]
        public List<ClsCategoryNameList> GetCategoryNameList()
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.GetCategoryNameList();
            }
        }
        [Route("MasterManagement/BrandName")]
        [HttpPost]
        public List<ClsBrandNameList> GetBrandNameList()
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.GetBrandNameList();
            }
        }
        [Route("MasterManagement/ManufacturerName")]
        [HttpPost]
        public List<ClsManufacturerNameList> GetManufacturerNameList()
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.GetManufacturerNameList();
            }
        }
        [Route("MasterManagement/SKUName")]
        [HttpPost]
        public List<ClsSKUCodeList> GetSKUNameList(ClsSKUCodeList ObjSKU)
        {
            using (ClsMasterManagement_BAL obj = new ClsMasterManagement_BAL())
            {
                return obj.GetSKUNameList(ObjSKU);
            }
        }

    }
}