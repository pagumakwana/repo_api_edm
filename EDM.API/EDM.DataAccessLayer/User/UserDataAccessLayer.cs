using EDM.Models.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.DataAccessLayer.User
{
    public class UserDataAccessLayer : IDisposable
    {
        public string SignUp(ClsUserSignUp ObjUser)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@Ref_User_ID", ObjUser.Ref_User_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@User_Code", ObjUser.User_Code, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@User_FirstName", ObjUser.User_FirstName, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@User_LastName", ObjUser.User_LastName, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@User_EmailID", ObjUser.User_EmailID, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@User_Password", ObjUser.User_Password, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Profile_Photo", ObjUser.Profile_Photo, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Bio", ObjUser.Bio, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Gender", ObjUser.Gender, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Pincode", ObjUser.Pincode, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Address", ObjUser.Address, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Address1", ObjUser.Address1, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@AuthorityIDs", ObjUser.AuthorityIDs, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@UserMasterDataIDs", ObjUser.UserMasterDataIDs, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@IsActive", ObjUser.IsActive, DbType.Boolean);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@CreatedBy", ObjUser.CreatedBy, DbType.String);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                return Convert.ToString(objDbHelper.ExecuteScalar("[DBO].[SignUp]", ObJParameterCOl, CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClsUserSignUp> SignIn(ClsUserSignIn ObjUser)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@User_Code", ObjUser.User_Code, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@password", ObjUser.Password, DbType.String);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataTable User = objDbHelper.ExecuteDataTable("[DBO].[SignIn]", ObJParameterCOl, CommandType.StoredProcedure);
                List<ClsUserSignUp> objUserMaster = new List<ClsUserSignUp>();

                if (User != null)
                {
                    if (User.Rows.Count > 0)
                    {
                        IList<ClsUserSignUp> List = User.AsEnumerable().Select(Row =>
                            new ClsUserSignUp
                            {
                                Ref_User_ID = Row.Field<Int64>("Ref_User_ID"),
                                User_Code = Row.Field<string>("User_Code"),
                                User_FirstName = Row.Field<string>("User_FirstName"),
                                User_LastName = Row.Field<string>("User_LastName"),
                                User_EmailID = Row.Field<string>("User_EmailID"),
                                Profile_Photo = Row.Field<string>("Profile_Photo"),
                                Bio = Row.Field<string>("Bio"),
                                Gender = Row.Field<string>("Gender"),
                                User_Password = Row.Field<string>("User_Password"),
                                Pincode = Row.Field<Int64>("Pincode"),
                                Address = Row.Field<string>("Address"),
                                Address1 = Row.Field<string>("Address1"),
                                AuthorityIDs = Row.Field<string>("AuthorityIDs"),
                                UserMasterDataIDs = Row.Field<string>("UserMasterDataIDs")
                            }).ToList();
                        objUserMaster.AddRange(List);
                    }
                }
                return objUserMaster;
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
