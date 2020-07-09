using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.Models.Admin.AuthorityManagement
{
    public class ClsAuthority
    {
        public Int64 Ref_Authority_ID { get; set; }
        public string AuthorityName { get; set; }
        public string AuthorityType { get; set; }
        public string Description { get; set; }
        public string MasterDataIDs { get; set; }
        public string CreatedBy { get; set; }
        public List<ClsModuleAccess> ModuleAccess { get; set; }
    }
    public class ClsAuthorityList
    {
        public Int64 Ref_Authority_ID { get; set; }
        public string AuthorityName { get; set; }
        public string AuthorityType { get; set; }
    }

    public class ClsModuleAccess
    {

        public Int64 Ref_Module_ID { get; set; }
        public Boolean View { get; set; }
        public Boolean Edit { get; set; }
        public Boolean Delete { get; set; }
    }
}
