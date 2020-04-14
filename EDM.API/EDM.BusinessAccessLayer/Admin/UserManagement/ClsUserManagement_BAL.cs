using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDM.DataAccessLayer.Admin.UserManagement;
using EDM.Models.Admin.UserManagement;

namespace EDM.BusinessLayer.Admin.UserManagement
{
   public class ClsUserManagement_BAL : IDisposable
    {
        public string AddModifyUser(ClsUserDetails ObjUser)
        {
            using (ClsUserManagement_DAL obj = new ClsUserManagement_DAL())
            {
                return obj.AddModifyUser(ObjUser);
            }
        }

        public void Dispose()
        {

        }
    }
}
