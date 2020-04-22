using EDM.BusinessAccessLayer.Admin.Gener;
using EDM.Models.Admin.Gener;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EDM.API.Controllers.Admin.Gener
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    [RoutePrefix("api/Admin/GenerManagement")]
    public class GenerController : ApiController
    {
        [Route("Gener")]
        [HttpPost]
        public string GenerAddModify(ClsGenerManagement_BO objClsGenerManagement_BO)
        {
            using (ClsGenerManagement_BAL objClsGenerManagement_BAL = new ClsGenerManagement_BAL())
            {
                return objClsGenerManagement_BAL.GenerAddModify(objClsGenerManagement_BO);
            }
        }

        [Route("GenerList")]
        [HttpPost]
        public List<ClsGenerManagement_BO> GenerList(ClsGenerManagement_BO objClsGenerManagement_BO)
        {
            using (ClsGenerManagement_BAL objClsGenerManagement_BAL = new ClsGenerManagement_BAL())
            {
                return objClsGenerManagement_BAL.GenerList(objClsGenerManagement_BO);
            }
        }

    }
}
