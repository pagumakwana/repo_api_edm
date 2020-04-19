using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.Models.Common
{
    public class clsBase
    {
        public string UserName { get; set; }
        public string Response { get; set; }
        public Int64 Ref_Client_ID { get; set; }
        public Nullable<DateTime> CreatedDateTime { get; set; }
        public Int64 CreatedBy { get; set; }
        public string CreatedName { get; set; }
        public Nullable<DateTime> UpdatedDateTime { get; set; }
        public Int64 UpdatedBy { get; set; }
        public string UpdatedName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string Extras { get; set; }
    }
}
