﻿using System;
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
        public string FileType { get; set; }
        public string FileExtension { get; set; }
        public long FileSize { get; set; }
        public string ModuleName { get; set; }
        public string FileIdentifier { get; set; }
        public Int64 DisplayOrder { get; set; }
    }

    public class ClsFileManager
    {
        public Int64 FileManagerID { get; set; }
        public Int64 ModuleID { get; set; }
        public string ModuleType { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public string FileExtension { get; set; }
        public long FileSize { get; set; }
        public string FileIdentifier { get; set; }
        public int Sequence { get; set; }
    }
}
