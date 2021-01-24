using EDM.DataAccessLayer.Admin.UserManagement;
using EDM.Models.Admin.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.BusinessAccessLayer.Admin.UserManagement
{
    public class ClsUserManagement_BAL : IDisposable
    {
        public List<ClsProducersDetails> GetAllProducersList(Int64 UserID, string AccountStatus, int StartCount, int EndCount)
        {
            using (ClsUserManagement_DAL obj = new ClsUserManagement_DAL())
            {
                return obj.GetAllProducersList(UserID, AccountStatus, StartCount, EndCount);
            }
        }

        public string ProducerApproveAndRejact(ClsProducersApproveAndRejact ObjApproveAndRejact)
        {
            using (ClsUserManagement_DAL obj = new ClsUserManagement_DAL())
            {
                return obj.ProducerApproveAndRejact(ObjApproveAndRejact);
            }
        }

        public void Dispose()
        {

        }
    }
}
