﻿using EDM.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.Models.Admin.TrackManagement
{
    public class ClsTrackDetails
    {
        public Int64 Ref_Track_ID { get; set; }
        public Int64 Ref_Category_ID { get; set; }
        public string TrackType { get; set; }
        public string TrackName { get; set; }
        public string Bio { get; set; }
        public string Mood { get; set; }
        public string Key { get; set; }
        public string Tag { get; set; }
        public string Duration { get; set; }
        public int BMP { get; set; }
        public string DAW { get; set; }
        public Boolean IsVocals { get; set; }
        public Boolean IsTrack { get; set; }
        public Decimal Price { get; set; }
        public Decimal PriceWithProjectFiles { get; set; }
        public string TrackStatus { get; set; }
        public string Reason { get; set; }
        public Boolean IsActive { get; set; }
        public string CreatedBy { get; set; }
        public List<ClsFileManager> FileManager { get; set; }

    }

    public class ClsApproveAndRejact
    {
        public string TrackIDs { get; set; }
        public string Action { get; set; }
        public string Reason { get; set; }
        public string ActionBy { get; set; }

    }
}
