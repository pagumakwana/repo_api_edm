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
        public Nullable<DateTime> CreatedDateTime { get; set; }
        public Int64? CreatedBy { get; set; }
        public string CreatedName { get; set; }
        public Nullable<DateTime> UpdatedDateTime { get; set; }
        public Int64? UpdatedBy { get; set; }
        public string UpdatedName { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public List<ClsFileInfo> ImageUrls { get; set; }
    }
}
