using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.Models.Admin.MasterManagement
{

    public class ClsUserMasterControl
    {
        public Int64 Ref_UserMasterControl_ID { get; set; }
        public string UserMasterControl { get; set; }
        public string ControlUseBy { get; set; }


    }

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


    public class ClsMeasureNameList
    {
        public Int64 Ref_Measure_ID { get; set; }
        public string Measure { get; set; }

    }

    public class ClsMeasureTypeNameList
    {
        public Int64 Ref_MeasureType_ID { get; set; }
        public string MeasureType { get; set; }

    }
    public class ClsCategoryNameList
    {
        public Int64 Ref_Category_ID { get; set; }
        public string CategoryName { get; set; }

    }
    public class ClsBrandNameList
    {
        public Int64 Ref_Brand_ID { get; set; }
        public string BrandName { get; set; }

    }
    public class ClsManufacturerNameList
    {
        public Int64 Ref_Manufacturer_ID { get; set; }
        public string Manufacture { get; set; }

    }

    public class ClsSKUCodeList
    {
        public Int64 Ref_SKU_ID { get; set; }
        public string SKUCode { get; set; }
        public string Description { get; set; }
        public Boolean ActiveFlage { get; set; }
    }
}
