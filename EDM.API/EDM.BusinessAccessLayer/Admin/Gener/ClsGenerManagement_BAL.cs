using EDM.DataAccessLayer.Admin.Gener;
using EDM.Models.Admin.Gener;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.BusinessAccessLayer.Admin.Gener
{
    public class ClsGenerManagement_BAL : IDisposable
    {
        public string GenerAddModify(ClsGenerManagement_BO objClsGenerManagement_BO)
        {
            using (ClsGenerManagement_DAL objClsGenerManagement_DAL = new ClsGenerManagement_DAL())
            {
                return objClsGenerManagement_DAL.GenerAddModify(objClsGenerManagement_BO);
            }
        }

        public List<ClsGenerManagement_BO> GenerList(ClsGenerManagement_BO objClsGenerManagement_BO)
        {
            using (ClsGenerManagement_DAL objClsGenerManagement_DAL = new ClsGenerManagement_DAL())
            {
                return objClsGenerManagement_DAL.GenerList(objClsGenerManagement_BO);
            }
        }

        public void Dispose()
        {

        }
    }
}
