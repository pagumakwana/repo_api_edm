using EDM.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.Models.Admin.Gener
{
    public class ClsGenerManagement_BO : clsBase
    {
        public Int64 Ref_Gener_ID { get; set; }
        public Int64 Ref_ParentGener_ID { get; set; }
        public string GenerName { get; set; }
        public string Description { get; set; }
        public string DisplayOnHome { get; set; }

    }
}
