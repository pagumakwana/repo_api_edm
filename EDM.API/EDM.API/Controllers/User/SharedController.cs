using EDM.BusinessAccessLayer.User;
using EDM.Models.User;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EDM.API.Controllers.User
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/User/Shared")]
    public class SharedController : ApiController
    {
        [Route("GlobalSearch")]
        [HttpGet]
        public List<ClsGlobalSearch> GlobalSearch(string SearchKeyWord)
        {
            using (ClsShared_BAL obj = new ClsShared_BAL())
            {
                return obj.GlobalSearch(SearchKeyWord);
            }
        }

        [Route("ParentCategory")]
        [HttpGet]
        public List<ClsParentCategory> GetParentCategoryList()
        {
            using (ClsShared_BAL obj = new ClsShared_BAL())
            {
                return obj.GetParentCategoryList();
            }
        }
    }
}