using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Http;

namespace EDM.API.Controllers.Common
{
    public class CommonController : ApiController
    {
        [Route("Common/Image")]
        [HttpPost]
        public string UploadImage(string ModuleName)
        {
            string FilePath = HttpContext.Current.Server.MapPath("~/Images/" + ModuleName + "/");

            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }

            if (HttpContext.Current.Request.ContentLength > 0)
            {
                HttpPostedFile PostedFile = HttpContext.Current.Request.Files[0];

                FilePath = Path.Combine(FilePath, HttpContext.Current.Request.Files[0].FileName);
                PostedFile.SaveAs(FilePath);

                return "/Images/" + ModuleName + "/" + HttpContext.Current.Request.Files[0].FileName;
            }
            else
            {
                return "";
            }
        }

        [Route("Common/File")]
        [HttpPost]
        public string FileUpload(string ModuleName)
        {
            string FilePath = HttpContext.Current.Server.MapPath("~/Files/" + ModuleName + "/");

            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }

            if (HttpContext.Current.Request.ContentLength > 0)
            {
                HttpPostedFile PostedFile = HttpContext.Current.Request.Files[0];

                FilePath = Path.Combine(FilePath, HttpContext.Current.Request.Files[0].FileName);
                PostedFile.SaveAs(FilePath);

                return "/Files/" + ModuleName + "/" + HttpContext.Current.Request.Files[0].FileName;
            }
            else
            {
                return "";
            }
        }
    }
}