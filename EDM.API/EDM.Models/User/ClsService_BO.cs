using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.Models.User
{
    public class ClsCustomServiceList
    {
        public Int64 Ref_Service_ID { get; set; }
        public string CategoryName { get; set; }
        public string ServiceTitle { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public string Thumbnail { get; set; }
    }

    public class ClsCustomServiceDetails
    {
        public Int64 Ref_Service_ID { get; set; }
        public string CategoryName { get; set; }
        public string ServiceTitle { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public Decimal PriceWithProjectFiles { get; set; }
        public string BigImageUrl { get; set; }
        public string ThumbnailImageUrl { get; set; }
        public string ServiceVideoUrl { get; set; }
        public string ProjectFilesUrl { get; set; }
        public int Revision { get; set; }
        public List<ClsFAQList> FAQList { get; set; }
    }
    public class ClsFAQList
    {
        public string Questions { get; set; }
        public string Answer { get; set; }
    }
}
