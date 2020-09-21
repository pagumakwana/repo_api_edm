using EDM.DataAccessLayer.Common;
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
            using (ClsCommon_DAL objClsCommon_DAL = new ClsCommon_DAL())
            {
                return objClsCommon_DAL.FileUploader(ModuleName);
            }
        }
        public string RemoveFile(Int64 Ref_File_ID)
        {
            using (ClsCommon_DAL objClsCommon_DAL = new ClsCommon_DAL())
            {
                return objClsCommon_DAL.RemoveFile(Ref_File_ID);
            }
        }

        public string SaveModuleFile(Int64 ModuleID, string ModuleType, string FileIdentifier)
        {
            using (ClsCommon_DAL objClsCommon_DAL = new ClsCommon_DAL())
            {
                return objClsCommon_DAL.SaveModuleFile(ModuleID, ModuleType, FileIdentifier);
            }
        }
        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
