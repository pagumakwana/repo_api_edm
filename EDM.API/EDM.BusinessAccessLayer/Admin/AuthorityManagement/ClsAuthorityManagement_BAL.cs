using EDM.DataAccessLayer.Admin.AuthorityManagement;
using EDM.Models.Admin.AuthorityManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.BusinessLayer.Admin.AuthorityManagement
{
    public class ClsAuthorityManagement_BAL : IDisposable
    {
        public List<ClsModuleList> GetModuleList()
        {
            using (ClsAuthorityManagement_DAL obj = new ClsAuthorityManagement_DAL())
            {
                return obj.GetModuleList();
            }
        }

        public String AddModifyAuthority(ClsAuthority ObjAuthority)
        {
            using (ClsAuthorityManagement_DAL obj = new ClsAuthorityManagement_DAL())
            {
                return obj.AddModifyAuthority(ObjAuthority);
            }
        }

        public List<ClsAuthorityList> GetAuthorityList()
        {
            using (ClsAuthorityManagement_DAL obj = new ClsAuthorityManagement_DAL())
            {
                return obj.GetAuthorityList();
            }
        }

        public List<ClsAuthority> GetAuthorityDetails(Int64 AuthorityID)
        {
            using (ClsAuthorityManagement_DAL obj = new ClsAuthorityManagement_DAL())
            {
                return obj.GetAuthorityDetails(AuthorityID);
            }
        }

        public void Dispose()
        {

        }
    }
}
