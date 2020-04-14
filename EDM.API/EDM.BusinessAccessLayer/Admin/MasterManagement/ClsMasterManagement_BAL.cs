using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDM.DataAccessLayer.Admin.MasterManagement;
using EDM.Models.Admin.MasterManagement;

namespace EDM.BusinessLayer.Admin.MasterManagement
{
    public class ClsMasterManagement_BAL : IDisposable
    {
        public List<ClsUserMasterControl> GetUserMasterControlList()
        {
            using (ClsMasterManagement_DAL obj = new ClsMasterManagement_DAL())
            {
                return obj.GetUserMasterControlList();
            }
        }

        public String AddUserMaster(ClsUserMaster ObjUserMaster)
        {
            using (ClsMasterManagement_DAL obj = new ClsMasterManagement_DAL())
            {
                return obj.AddUserMaster(ObjUserMaster);
            }
        }

        public List<ClsUserMaster> GetUserMasterList()
        {
            using (ClsMasterManagement_DAL obj = new ClsMasterManagement_DAL())
            {
                return obj.GetUserMasterList();
            }
        }

        public List<ClsParentUserMaster> GetParentUserMasterList(Int64 UserMasterID)
        {
            using (ClsMasterManagement_DAL obj = new ClsMasterManagement_DAL())
            {
                return obj.GetParentUserMasterList(UserMasterID);
            }
        }

        public String AddUserMasterData(ClsUserMasterData ObjUserMasterData)
        {
            using (ClsMasterManagement_DAL obj = new ClsMasterManagement_DAL())
            {
                return obj.AddUserMasterData(ObjUserMasterData);
            }

        }

        public List<ClsUserMasterData> GetUserMasterDataList(Int64 UserMasterID)
        {
            using (ClsMasterManagement_DAL obj = new ClsMasterManagement_DAL())
            {
                return obj.GetUserMasterDataList(UserMasterID);
            }
        }

        public List<ClsMeasureTypeNameList> GetMeasureTypeList()
        {
            using (ClsMasterManagement_DAL obj = new ClsMasterManagement_DAL())
            {
                return obj.GetMeasureTypeList();
            }
        }
        public List<ClsMeasureNameList> GetMeasureNameList()
        {
            using (ClsMasterManagement_DAL obj = new ClsMasterManagement_DAL())
            {
                return obj.GetMeasureNameList();
            }
        }
        public List<ClsCategoryNameList> GetCategoryNameList()
        {
            using (ClsMasterManagement_DAL obj = new ClsMasterManagement_DAL())
            {
                return obj.GetCategoryNameList();
            }
        }
        public List<ClsBrandNameList> GetBrandNameList()
        {
            using (ClsMasterManagement_DAL obj = new ClsMasterManagement_DAL())
            {
                return obj.GetBrandNameList();
            }
        }
        public List<ClsManufacturerNameList> GetManufacturerNameList()
        {
            using (ClsMasterManagement_DAL obj = new ClsMasterManagement_DAL())
            {
                return obj.GetManufacturerNameList();
            }
        }
        public List<ClsSKUCodeList> GetSKUNameList(ClsSKUCodeList ObjSKU)
        {
            using (ClsMasterManagement_DAL obj = new ClsMasterManagement_DAL())
            {
                return obj.GetSKUNameList(ObjSKU);
            }
        }

        public void Dispose()
        {

        }
    }
}