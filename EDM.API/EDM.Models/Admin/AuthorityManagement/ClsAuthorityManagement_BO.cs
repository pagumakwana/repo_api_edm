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
        public Boolean IsActive { get; set; }
    }

    public class ClsModuleAccess
    {

        public Int64 Ref_Module_ID { get; set; }
        public Boolean View { get; set; }
        public Boolean Edit { get; set; }
        public Boolean Delete { get; set; }
        public Boolean Approval { get; set; }
    }

    public class ClsModuleList
    {
        public Int64 Ref_Module_ID { get; set; }
        public string ModuleName { get; set; }
        public string ModuleIdentifier { get; set; }
        public string ModuleType { get; set; }
        public string ModuleFor { get; set; }
        public string ImageUrl { get; set; }
        public string ModuleUrl { get; set; }
        public int DisplayOrder { get; set; }
        public List<ClsModuleAccess> ModuleAccess { get; set; }
    }
}
