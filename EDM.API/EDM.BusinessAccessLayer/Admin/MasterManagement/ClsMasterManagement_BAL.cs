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
        public String AddModifyUserMaster(ClsUserMaster ObjUserMaster)
        {
            using (ClsMasterManagement_DAL obj = new ClsMasterManagement_DAL())
            {
                return obj.AddModifyUserMaster(ObjUserMaster);
            }
        }

        public List<ClsUserMaster> GetUserMasterList(Int64 UserMasterID)
        {
            using (ClsMasterManagement_DAL obj = new ClsMasterManagement_DAL())
            {
                return obj.GetUserMasterList(UserMasterID);
            }
        }

        public List<ClsParentUserMaster> GetParentUserMasterList(Int64 UserMasterID)
        {
            using (ClsMasterManagement_DAL obj = new ClsMasterManagement_DAL())
            {
                return obj.GetParentUserMasterList(UserMasterID);
            }
        }

        public String AddModifyUserMasterData(ClsUserMasterData ObjUserMasterData)
        {
            using (ClsMasterManagement_DAL obj = new ClsMasterManagement_DAL())
            {
                return obj.AddModifyUserMasterData(ObjUserMasterData);
            }

        }

        public List<ClsUserMasterData> GetUserMasterDataList(Int64 UserMasterID)
        {
            using (ClsMasterManagement_DAL obj = new ClsMasterManagement_DAL())
            {
                return obj.GetUserMasterDataList(UserMasterID);
            }
        }

        public String AddModifyCategory(ClsCategoryDetails ObjCategory)
        {
            using (ClsMasterManagement_DAL obj = new ClsMasterManagement_DAL())
            {
                return obj.AddModifyCategory(ObjCategory);
            }

        }

        public List<ClsCategoryDetails> GetCategoryList()
        {
            using (ClsMasterManagement_DAL obj = new ClsMasterManagement_DAL())
            {
                return obj.GetCategoryList();
            }
        }
      

        public void Dispose()
        {

        }
    }
}