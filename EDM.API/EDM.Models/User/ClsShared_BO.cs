using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.Models.User
{
    public class ClsGlobalSearch
    {
        public Int64 Ref_Service_ID { get; set; }
        public string ServiceTitle { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public string ThumbnailImageUrl { get; set; }
    }
}
