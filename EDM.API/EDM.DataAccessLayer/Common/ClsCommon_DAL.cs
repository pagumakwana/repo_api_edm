using EDM.Models.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EDM.DataAccessLayer.Common
{
    public class ClsCommon_DAL : IDisposable
    {

        public List<ClsFileInfo> FileUploader(string ModuleName)
        {
            List<ClsFileInfo> lstFiles = new List<ClsFileInfo>();
            try
            {
                if (HttpContext.Current.Request.ContentLength > 0)
                {

                    var httpRequest = HttpContext.Current.Request;
                    foreach (string file in httpRequest.Files)
                    {
                        string FilePath = HttpContext.Current.Server.MapPath("~/FileStorage/" + ModuleName + "/");
                        string StoreFilePath = "/FileStorage/" + ModuleName + "/";
                        if (!Directory.Exists(FilePath))
                        {
                            Directory.CreateDirectory(FilePath);
                        }
                        ClsFileInfo objFileInfo = new ClsFileInfo();
                        var postedFile = httpRequest.Files[file];
                        string FileName = AppendTimeStamp(postedFile.FileName);
                        FilePath = Path.Combine(FilePath, FileName);
                        objFileInfo.FileName = FileName;
                        objFileInfo.FilePath = StoreFilePath + FileName;
                        objFileInfo.FileSize = postedFile.ContentLength;
                        objFileInfo.FileExtension = Path.GetExtension(FilePath);
                        objFileInfo.ModuleName = ModuleName;
                        objFileInfo.FileType = postedFile.ContentType;
                        postedFile.SaveAs(FilePath);
                        lstFiles.Add(objFileInfo);
                    }
                    return lstFiles;
                }
                else
                {
                    return lstFiles;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string AppendTimeStamp(string fileName)
        {
            return string.Concat(
                Path.GetFileNameWithoutExtension(fileName),
                DateTime.Now.ToString("_yyyy-MM-dd-HH-mm-ss"),
                Path.GetExtension(fileName)
                );
        }
        public void Dispose()
        {
            //throw new NotImplementedException();
        }

    }
}
