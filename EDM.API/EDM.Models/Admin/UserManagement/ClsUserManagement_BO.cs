using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.Models.Admin.UserManagement
{
    public class ClsUserDetails
    {
        public Int64 ref_User_ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public string password { get; set; }
        public string profilePicUrl { get; set; }
        public string masterDataIDs { get; set; }
    }
}
