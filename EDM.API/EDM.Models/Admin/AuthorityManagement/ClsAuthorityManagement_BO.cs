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
    }
    public class ClsAuthorityList
    {
        public Int64 Ref_Authority_ID { get; set; }
        public string AuthorityName { get; set; }
        public string AuthorityType { get; set; }
    }


    //public class ClsParentUserMaster
    //{

    //    public Int64 Ref_UserMaster_ID { get; set; }
    //    public string userMasterName { get; set; }
    //    public Boolean isCompulsory { get; set; }
    //    public string typeOfView { get; set; }

    //    public List<ClsUserMasterData> userMasterData { get; set; }

    //}
}
