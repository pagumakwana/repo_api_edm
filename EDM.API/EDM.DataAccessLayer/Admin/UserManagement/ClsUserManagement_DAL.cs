using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDM.Models.Admin.UserManagement;

namespace EDM.DataAccessLayer.Admin.UserManagement
{
    public class ClsUserManagement_DAL : IDisposable
    {

        public string AddModifyUser(ClsUserDetails ObjUser)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@Ref_User_ID", ObjUser.ref_User_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@firstName", ObjUser.firstName, DbType.String);
                ObJParameterCOl.Add(objDBParameter);

                string Massage = "";
                DBHelper objDbHelper = new DBHelper();
                Massage = Convert.ToString(objDbHelper.ExecuteScalar("[DBO].[AddModifyUser]", ObJParameterCOl, CommandType.StoredProcedure));


                return Massage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Dispose()
        {

        }

    }
}
