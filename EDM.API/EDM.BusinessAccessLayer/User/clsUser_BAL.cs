using EDM.DataAccessLayer.User;
using EDM.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.BusinessAccessLayer.User
{
    public class clsUser_BAL : IDisposable
    {
        public string SignUp(ClsUserSignUp ObjUser)
        {
            using (clsUser_DAL obj = new clsUser_DAL())
            {
                return obj.SignUp(ObjUser);
            }
        }

        public List<ClsUserSignUp> SignIn(ClsUserSignIn ObjUser)
        {
            using (clsUser_DAL obj = new clsUser_DAL())
            {
                return obj.SignIn(ObjUser);
            }
        }

        public void Dispose()
        {

        }
    }
}
