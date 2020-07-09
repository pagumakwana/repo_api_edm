using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.Models.Common
{
    public class ClsFileInfo : clsBase
    {
        public Int64 Ref_ID { get; set; }
        public Int64 Ref_File_ID { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileExtension { get; set; }
        public long FileSize { get; set; }
        public string ModuleName { get; set; }
    }
}
