using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.Models.User
{
    public class ClsFeaturedTrack
    {
        public Int64 Ref_Track_ID { get; set; }
        public string CategoryName { get; set; }
        public string TrackType { get; set; }
        public string TrackName { get; set; }
        public string Bio { get; set; }
        public string Mood { get; set; }
        public string Key { get; set; }
        public string Tag { get; set; }
        public int Duration { get; set; }
        public Boolean IsTrack { get; set; }
        public Decimal Price { get; set; }
        public string BigImageUrl { get; set; }
        public string ThumbnailImageUrl { get; set; }
    }
}
