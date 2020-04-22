using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.Models.Common
{
    public class clsBase
    {
        public string Flag { get; set; }
        public Int64 Ref_User_ID { get; set; }
        public Guid Ref_User_GUID { get; set; }
        public Int64 Ref_GuestUser_ID { get; set; }
        public Guid Ref_GuestUser_GUID { get; set; }
        public Nullable<DateTime> CreatedDateTime { get; set; }
        public Int64 CreatedBy { get; set; }
        public string CreatedName { get; set; }
        public Nullable<DateTime> UpdatedDateTime { get; set; }
        public Int64 UpdatedBy { get; set; }
        public string UpdatedName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string Extras { get; set; }
        public string Response { get; set; }
        //public List<ClsFile> ImageUrls { get; set; }
    }
}
