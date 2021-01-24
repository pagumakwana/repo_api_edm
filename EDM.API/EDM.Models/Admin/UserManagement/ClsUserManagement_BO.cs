using EDM.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.Models.Admin.UserManagement
{
    public class ClsProducersDetails
    {
        public Int64 Ref_User_ID { get; set; }
        public string UserCode { get; set; }
        public string FullName { get; set; }
        public string EmailID { get; set; }
        public string MobileNumber { get; set; }
        public string Bio { get; set; }
        public string ProfilePhoto { get; set; }
        public string AccountStatus { get; set; }
        public int TrackCount { get; set; }
        public int BeatCount { get; set; }
        public string Earning { get; set; }

    }
    public class ClsProducersApproveAndRejact
    {
        public string ProducerIDs { get; set; }
        public string Action { get; set; }
        public string Reason { get; set; }
        public string ActionBy { get; set; }

    }
}
