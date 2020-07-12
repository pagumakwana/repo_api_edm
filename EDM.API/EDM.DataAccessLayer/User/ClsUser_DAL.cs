using EDM.Models.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.DataAccessLayer.User
{
    public class ClsUser_DAL : IDisposable
    {
        public string SignUp(ClsUserSignUp ObjUser)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@User_Code", ObjUser.User_Code, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@FullName", ObjUser.FullName, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@EmailID", ObjUser.EmailID, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Password", ObjUser.Password, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Profile_Photo", ObjUser.Profile_Photo, DbType.String);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                return Convert.ToString(objDbHelper.ExecuteScalar("[DBO].[SignUp]", ObJParameterCOl, CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClsUserDetails> SignIn(ClsUserSignIn ObjUser)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@User_Code", ObjUser.User_Code, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@password", ObjUser.Password, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@IsSocialLogin", ObjUser.IsSocialLogin, DbType.Boolean);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataTable User = objDbHelper.ExecuteDataTable("[DBO].[SignIn]", ObJParameterCOl, CommandType.StoredProcedure);
                List<ClsUserDetails> objUserDetails = new List<ClsUserDetails>();

                if (User != null)
                {
                    if (User.Rows.Count > 0)
                    {
                        objUserDetails = User.AsEnumerable().Select(Row =>
                            new ClsUserDetails
                            {
                                Ref_User_ID = Row.Field<Int64>("Ref_User_ID"),
                                User_Code = Row.Field<string>("User_Code"),
                                FullName = Row.Field<string>("FullName"),
                                EmailID = Row.Field<string>("EmailID"),
                                Profile_Photo = Row.Field<string>("Profile_Photo"),
                                ResponseMessage = Row.Field<string>("Response"),
                            }).ToList();
                    }
                }
                return objUserDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClsUserDetails> GetProducersList()
        {
            try
            {
                DBHelper objDbHelper = new DBHelper();
                DataTable User = objDbHelper.ExecuteDataTable("[DBO].[GetProducersList]", CommandType.StoredProcedure);
                List<ClsUserDetails> objUserDetails = new List<ClsUserDetails>();

                if (User != null)
                {
                    if (User.Rows.Count > 0)
                    {
                        objUserDetails = User.AsEnumerable().Select(Row =>
                            new ClsUserDetails
                            {
                                Ref_User_ID = Row.Field<Int64>("Ref_User_ID"),
                                User_Code = Row.Field<string>("User_Code"),
                                FullName = Row.Field<string>("FullName"),
                                EmailID = Row.Field<string>("EmailID"),
                                Profile_Photo = Row.Field<string>("Profile_Photo"),
                                ResponseMessage = Row.Field<string>("Response"),
                            }).ToList();
                    }
                }
                return objUserDetails;
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
