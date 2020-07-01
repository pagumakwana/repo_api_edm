using EDM.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.BusinessAccessLayer.Common
{
    public class ClsCommon_BAL : IDisposable
    {
        public List<ClsFileInfo> FileUploader(string ModuleName)
        {
            using (ClsCommon_BAL objClsCommon_BAL = new ClsCommon_BAL())
            {
                return objClsCommon_BAL.FileUploader(ModuleName);
            }
        }
        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
