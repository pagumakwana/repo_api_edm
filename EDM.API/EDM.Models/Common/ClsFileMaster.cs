using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.Models.Common
{
    public class ClsFileMaster
    {
        public class ClsFile
        {
            public Int64 Ref_File_ID { get; set; }
            public string FileName { get; set; }
            public string FilePath { get; set; }
            public string FileType { get; set; }
            public string FileExtension { get; set; }
            public string FileSize { get; set; }
            public Int64 CreatedBy { get; set; }
            public DateTime CreatedDateTime { get; set; }
            public Int64 UpdatedBy { get; set; }
            public DateTime UpdatedDateTime { get; set; }
            public Boolean IsActive { get; set; }
            public Boolean IsDeleted { get; set; }
            public Int64 Ref_ID { get; set; }
            public string ModuleName { get; set; }
        }
    }
}
