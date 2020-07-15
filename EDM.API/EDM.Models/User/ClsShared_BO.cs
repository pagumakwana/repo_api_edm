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
        public string ThumbnailImageUrl { get; set; }
    }
}
