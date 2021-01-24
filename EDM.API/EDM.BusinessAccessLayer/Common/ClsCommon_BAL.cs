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

        public List<ClsFileManager> SaveModuleFile(Int64 FileManagerID, Int64 ModuleID, string ModuleType, string FileIdentifier, int Sequence)
        {
            using (ClsCommon_DAL objClsCommon_DAL = new ClsCommon_DAL())
            {
                return objClsCommon_DAL.SaveModuleFile(FileManagerID, ModuleID, ModuleType, FileIdentifier, Sequence);
            }
        }
        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
