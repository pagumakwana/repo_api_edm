using EDM.DataAccessLayer.Admin.ServiceManagement;
using EDM.Models.Admin.ServiceManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.BusinessAccessLayer.Admin.ServiceManagement
{
    public class ClsServiceManagement_BAL : IDisposable
    {
        public String AddModifyServiceDetails(ClsServiceDetails ObjServiceDetails)
        {
            using (ClsServiceManagement_DAL obj = new ClsServiceManagement_DAL())
            {
                return obj.AddModifyServiceDetails(ObjServiceDetails);
            }
        }

        public List<ClsServiceDetails> GetServiceDetails(string Flag, Int64 Ref_Service_ID, string AliasName)
        {
            using (ClsServiceManagement_DAL obj = new ClsServiceManagement_DAL())
            {
                return obj.GetServiceDetails(Flag, Ref_Service_ID, AliasName);
            }
        }

        public String ManageService(string ServiceIDs, string Action)
        {
            using (ClsServiceManagement_DAL obj = new ClsServiceManagement_DAL())
            {
                return obj.ManageService(ServiceIDs, Action);
            }
        }

        public void Dispose()
        {

        }
    }
}
