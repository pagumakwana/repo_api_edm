using EDM.Models.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
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

        public string RemoveFile(Int64 Ref_File_ID)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@Ref_File_ID", Ref_File_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);

                string Massage = "";
                DBHelper objDbHelper = new DBHelper();
                Massage = Convert.ToString(objDbHelper.ExecuteScalar(Constant.RemoveFile, ObJParameterCOl, CommandType.StoredProcedure));

                return Massage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

    }
}
