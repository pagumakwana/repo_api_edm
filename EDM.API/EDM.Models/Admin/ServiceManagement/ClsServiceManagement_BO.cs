using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.Models.Admin.ServiceManagement
{
    public class ClsServiceDetails
    {
        public Int64 Ref_Service_ID { get; set; }
        public Int64 Ref_Category_ID { get; set; }
        public string ServiceTitle { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public string BigImageUrl { get; set; }
        public string ThumbnailImageUrl { get; set; }
        public string ServiceVideoUrl { get; set; }
        public string DeliveryDate { get; set; }
        public Boolean IsActive { get; set; }
        public string CreatedBy { get; set; }
    }
}
