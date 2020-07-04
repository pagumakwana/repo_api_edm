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

        public List<ClsCategoryDetails> GetCategoryList(string Flag, Int64 Ref_Category_ID)
        {
            using (ClsMasterManagement_DAL obj = new ClsMasterManagement_DAL())
            {
                return obj.GetCategoryList(Flag, Ref_Category_ID);
            }
        }

        public List<ClsDAW> GetDAWList()
        {
            using (ClsMasterManagement_DAL obj = new ClsMasterManagement_DAL())
            {
                return obj.GetDAWList();
            }
        }

        public String AddModifyCouponCode(ClsCouponDetails ObjCouponDetails)
        {
            using (ClsMasterManagement_DAL obj = new ClsMasterManagement_DAL())
            {
                return obj.AddModifyCouponCode(ObjCouponDetails);
            }
        }

        public List<ClsCouponDetails> GetCouponCodeList()
        {
            using (ClsMasterManagement_DAL obj = new ClsMasterManagement_DAL())
            {
                return obj.GetCouponCodeList();
            }
        }
        public String ManageCouponCode(string CouponIDs, string Action)
        {
            using (ClsMasterManagement_DAL obj = new ClsMasterManagement_DAL())
            {
                return obj.ManageCouponCode(CouponIDs, Action);
            }
        }

        public String AddModifyBlog(ClsBlogDetails ObjBlog)
        {
            using (ClsMasterManagement_DAL obj = new ClsMasterManagement_DAL())
            {
                return obj.AddModifyBlog(ObjBlog);
            }

        }

        public List<ClsBlogDetails> GetBlogList(Int64 Ref_Blog_ID)
        {
            using (ClsMasterManagement_DAL obj = new ClsMasterManagement_DAL())
            {
                return obj.GetBlogList(Ref_Blog_ID);
            }
        }

        public void Dispose()
        {

        }
    }
}