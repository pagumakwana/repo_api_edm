using EDM.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.Models.Admin.ServiceManagement
{
    public class ClsServiceDetails : clsBase
    {
        public Int64 Ref_Service_ID { get; set; }
        public Int64 Ref_Category_ID { get; set; }
        public string AliasName { get; set; }
        public string ServiceTitle { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public Decimal PriceWithProjectFiles { get; set; }
        public int Revision { get; set; }
        public string DeliveryDate { get; set; }
        public List<ClsFAQDetails> FAQDetails { get; set; }
        public List<ClsFileManager> FileManager { get; set; }
    }
    public class ClsFAQDetails
    {
        public Int64 Ref_Service_ID { get; set; }
        public string Questions { get; set; }
        public string Answer { get; set; }
    }
}
