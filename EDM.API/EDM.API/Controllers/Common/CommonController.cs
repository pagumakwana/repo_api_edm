﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Http;
using System.Web.Http.Cors;
using EDM.Models.Common;
using EDM.BusinessAccessLayer.Common;

namespace EDM.API.Controllers.Common
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Admin/Common")]
    public class CommonController : ApiController
    {

        [Route("FileUpload")]
        [HttpPost]
        public List<ClsFileInfo> FileUploader(string ModuleName)
        {
            using (ClsCommon_BAL objClsCommon_BAL = new ClsCommon_BAL())
            {
                return objClsCommon_BAL.FileUploader(ModuleName);
            }
        }

        [Route("SaveModuleFile")]
        [HttpPost]
        public List<ClsFileManager> SaveModuleFile(Int64 FileManagerID, Int64 ModuleID, string ModuleType, string FileIdentifier, int Sequence)
        {
            using (ClsCommon_BAL objClsCommon_BAL = new ClsCommon_BAL())
            {
                return objClsCommon_BAL.SaveModuleFile(FileManagerID, ModuleID, ModuleType, FileIdentifier, Sequence);
            }
        }

        [Route("RemoveFile")]
        [HttpPost]
        public string RemoveFile(Int64 Ref_File_ID)
        {
            using (ClsCommon_BAL objClsCommon_BAL = new ClsCommon_BAL())
            {
                return objClsCommon_BAL.RemoveFile(Ref_File_ID);
            }
        }
    }
}