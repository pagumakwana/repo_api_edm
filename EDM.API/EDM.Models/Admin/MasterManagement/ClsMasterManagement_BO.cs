﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.Models.Admin.MasterManagement
{

    public class ClsParentUserMaster
    {

        public Int64 Ref_UserMaster_ID { get; set; }
        public string userMasterName { get; set; }
        public Boolean isCompulsory { get; set; }
        public string typeOfView { get; set; }

        public List<ClsUserMasterData> userMasterData { get; set; }

    }

    public class ClsUserMaster
    {
        public Int64 Ref_UserMaster_ID { get; set; }
        public Int64 Ref_UserMasterControl_ID { get; set; }
        public string UserMaster { get; set; }
        public string Description { get; set; }
        public string ParentIDs { get; set; }
        public Boolean IsMandatory { get; set; }
        public Boolean HasParent { get; set; }
        public Boolean AllowNumeric { get; set; }
        public Boolean AllowAlphaNumeric { get; set; }
        public Boolean AllowSpecialCharacters { get; set; }
        public string SpecialCharacters { get; set; }
        public Boolean AllowNegativeNumbers { get; set; }
    }

    public class ClsUserMasterData
    {
        public Int64 Ref_UserMasterData_ID { get; set; }
        public Int64 Ref_UserMaster_ID { get; set; }
        public string UserMasterData { get; set; }
        public string Description { get; set; }
    }

    public class ClsCategoryDetails
    {
        public Int64 Ref_Category_ID { get; set; }
        public Int64 Ref_Preant_ID { get; set; }
        public string CategoryName { get; set; }
        public string Descripation { get; set; }
        public string ThumbnailImageUrl { get; set; }
        public Boolean IsActive { get; set; }

    }

}
