using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.Models.User
{
    public class ClsGlobalSearch
    {
        public Int64 Ref_Object_ID { get; set; }
        public string ObjectType { get; set; }
        public string Title { get; set; }
        public string Bio { get; set; }
        public Decimal Price { get; set; }
        public string Thumbnail { get; set; }
    }

    public class ClsParentCategory
    {
        public Int64 CategoryID { get; set; }
        public string CategoryUseBy { get; set; }
        public string CategoryName { get; set; }
        public string AliasName { get; set; }
        public string Description { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string Thumbnail { get; set; }
    }
}
