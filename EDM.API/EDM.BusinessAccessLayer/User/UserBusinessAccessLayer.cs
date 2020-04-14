using EDM.DataAccessLayer.User;
using EDM.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.BusinessAccessLayer.User
{
    public class UserBusinessAccessLayer : IDisposable
    {
        public string SignUp(ClsUserSignUp ObjUser)
        {
            using (UserDataAccessLayer obj = new UserDataAccessLayer())
            {
                return obj.SignUp(ObjUser);
            }
        }

        public List<ClsUserSignUp> SignIn(ClsUserSignIn ObjUser)
        {
            using (UserDataAccessLayer obj = new UserDataAccessLayer())
            {
                return obj.SignIn(ObjUser);
            }
        }

        public void Dispose()
        {

        }
    }
}
