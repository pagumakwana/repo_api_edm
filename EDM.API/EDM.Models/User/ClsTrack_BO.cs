﻿using EDM.Models.Common;
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
        public string TrackName { get; set; }
        public string Bio { get; set; }
        public string Duration { get; set; }
        public Decimal Price { get; set; }
        public string Thumbnail { get; set; }
        public string IsTrack { get; set; }
        public string SoldOut { get; set; }
        public string Favourite { get; set; }
        public string PlayUrl { get; set; }
    }

    public class ClsTrackAndBeatDetails
    {
        public Int64 Ref_Track_ID { get; set; }
        public Int64 Ref_Category_ID { get; set; }
        public string CategoryName { get; set; }
        public string TrackType { get; set; }
        public string TrackName { get; set; }
        public string Bio { get; set; }
        public string Mood { get; set; }
        public string Key { get; set; }
        public string Tag { get; set; }
        public string Duration { get; set; }
        public int BMP { get; set; }
        public string DAW { get; set; }
        public string IsVocals { get; set; }
        public string IsTrack { get; set; }
        public Decimal Price { get; set; }
        public Decimal PriceWithProjectFiles { get; set; }
        public string TrackStatus { get; set; }
        public string Favourite { get; set; }
        public string SoldOut { get; set; }
        public List<ClsFileManager> FileManager { get; set; }
        public List<ClsRelatedTrackList> RelatedTrack { get; set; }

    }

    public class ClsRelatedTrackList
    {
        public Int64 Ref_Track_ID { get; set; }
        public string CategoryName { get; set; }
        public string TrackName { get; set; }
        public string Bio { get; set; }
        public string IsTrack { get; set; }
        public Decimal Price { get; set; }
        public string Favourite { get; set; }
        public string PlayUrl { get; set; }
        public string SoldOut { get; set; }
        public string ThumbnailImageUrl { get; set; }
    }
    public class ClsTrackAndBeatList
    {
        public Int64 Ref_Track_ID { get; set; }
        public string CategoryName { get; set; }
        public string TrackType { get; set; }
        public string TrackName { get; set; }
        public string Bio { get; set; }
        public string Mood { get; set; }
        public string Key { get; set; }
        public string Tag { get; set; }
        public string Duration { get; set; }
        public int BMP { get; set; }
        public string DAW { get; set; }
        public string ThumbnailImageUrl { get; set; }
        public string PlayUrl { get; set; }
        public string Favourite { get; set; }
        public Decimal Price { get; set; }
        public Decimal PriceWithProjectFiles { get; set; }
        public Int64 Plays { get; set; }
        public string SoldOut { get; set; }
        public string IsVocals { get; set; }
        public string IsTrack { get; set; }
        public string TrackStatus { get; set; }
    }
}
