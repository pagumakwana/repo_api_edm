using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDM.Models.Admin.UserManagement;
using EDM.Models.Common;

namespace EDM.DataAccessLayer.Admin.UserManagement
{
    public class ClsUserManagement_DAL : IDisposable
    {
        public List<clsCustomer> RegisterCustomer(clsCustomer objclsCustomer)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@FullName", objclsCustomer.FullName, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Email_ID", objclsCustomer.Email, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@MobileNumber", objclsCustomer.Mobile, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Password", objclsCustomer.Password, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@CreatedBy", objclsCustomer.CreatedBy, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@UpdatedBy", objclsCustomer.UpdatedBy, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@IsGuestUser", objclsCustomer.IsGuestUser, DbType.Boolean);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Ref_User_ID", objclsCustomer.Ref_User_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet(Constant.RegisterCustomer, ObJParameterCOl, CommandType.StoredProcedure);

                List<clsCustomer> objCustomer = new List<clsCustomer>();

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        List<clsCustomer> lstCustomer = ds.Tables[0].AsEnumerable().Select(Row =>
                          new clsCustomer
                          {
                              Ref_User_ID = Row.Field<Int64>("Ref_User_ID"),
                              FullName = Row.Field<string>("FullName"),
                              Email = Row.Field<string>("Email_ID"),
                              Mobile = Row.Field<string>("MobileNumber"),
                              Password = Row.Field<string>("Password"),
                              Response = Row.Field<string>("Response"),
                          }).ToList();
                        objCustomer.AddRange(lstCustomer);
                    }
                }
                return objCustomer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<clsCustomer> SignInCustomer(clsCustomer objclsCustomer)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@UserCode", objclsCustomer.User_Code, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Password", objclsCustomer.Password, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Ref_GuestUser_ID", objclsCustomer.Ref_GuestUser_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet(Constant.SignInCustomer, ObJParameterCOl, CommandType.StoredProcedure);
                List<clsCustomer> lstCustomer = new List<clsCustomer>();
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lstCustomer = ds.Tables[0].AsEnumerable().Select(Row =>
                          new clsCustomer
                          {
                              Ref_User_ID = Row.Field<Int64>("Ref_User_ID"),
                              FullName = Row.Field<string>("FullName"),
                              Email = Row.Field<string>("Email_ID"),
                              Mobile = Row.Field<string>("MobileNumber"),
                              Password = Row.Field<string>("Password"),
                              CreatedBy = Row.Field<Int64>("CreatedBy"),
                              Response = Row.Field<string>("Response"),
                          }).ToList();
                    }
                }
                return lstCustomer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string RegisterGuest()
        {
            try
            {
                string ResponseMessage = "";

                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet(Constant.RegisterGuest, CommandType.StoredProcedure);
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ResponseMessage = ds.Tables[0].Rows[0]["RESPONSE"].ToString();
                    }
                }
                return ResponseMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ForgotPassword(string Flag, Int64 Ref_User_ID, Int64 Password)
        {
            try
            {
                string Response = "";
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@Flag", Flag, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Ref_UserID", Ref_User_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Password", Password, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet(Constant.ForgotPassword, ObJParameterCOl, CommandType.StoredProcedure);
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response = ds.Tables[0].Rows[0]["RESPONSE"].ToString();
                    }
                }
                return Response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<clsCustomer> ValidateUser(string UserCode)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@UserCode", UserCode, DbType.String);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet(Constant.ValidateUser, ObJParameterCOl, CommandType.StoredProcedure);
                List<clsCustomer> lstCustomer = new List<clsCustomer>();
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lstCustomer = ds.Tables[0].AsEnumerable().Select(Row =>
                          new clsCustomer
                          {
                              Ref_User_ID = Row.Field<Int64>("Ref_User_ID"),
                              FullName = Row.Field<string>("FullName"),
                              Email = Row.Field<string>("Email_ID"),
                              Mobile = Row.Field<string>("MobileNumber"),
                              Password = Row.Field<string>("Password"),
                              CreatedBy = Row.Field<Int64>("CreatedBy"),
                              Response = Row.Field<string>("Response"),
                          }).ToList();
                    }
                }
                return lstCustomer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string RequestOTP(clsRequestOTP objclsRequestOTP)
        {
            try
            {
                string OTP = "";
                if (objclsRequestOTP.Type == "REQUEST")
                {
                    Random generator = new Random();
                    OTP = generator.Next(0, 999999).ToString().PadLeft(6, '0');
                }
                else
                {
                    OTP = objclsRequestOTP.OTP;
                }
                string Response = "";
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@Ref_User_ID", objclsRequestOTP.Ref_User_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@OTP", OTP, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Flag", objclsRequestOTP.Flag, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Type", objclsRequestOTP.Type, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@IsValidate", objclsRequestOTP.IsValidate, DbType.Boolean);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet(Constant.RequestOTP, ObJParameterCOl, CommandType.StoredProcedure);
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response = ds.Tables[0].Rows[0]["RESPONSE"].ToString();
                    }
                }
                return Response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<clsCustomer> ProfileUpdate(clsCustomer objclsCustomer)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@FullName", objclsCustomer.FullName, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Email_ID", objclsCustomer.Email, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@MobileNumber", objclsCustomer.Mobile, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@DateOfBirth", objclsCustomer.DateOfBirth, DbType.DateTime);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Bio", objclsCustomer.Bio, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Gender", objclsCustomer.Gender, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Website", objclsCustomer.Website, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Ref_User_ID", objclsCustomer.Ref_User_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet(Constant.UpdateCustomerProfile, ObJParameterCOl, CommandType.StoredProcedure);

                List<clsCustomer> objCustomer = new List<clsCustomer>();

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        List<clsCustomer> lstCustomer = ds.Tables[0].AsEnumerable().Select(Row =>
                          new clsCustomer
                          {
                              Ref_User_ID = Row.Field<Int64>("Ref_User_ID"),
                              FullName = Row.Field<string>("FullName"),
                              Email = Row.Field<string>("Email_ID"),
                              Mobile = Row.Field<string>("MobileNumber"),
                              Gender = Row.Field<string>("Gender"),
                              Bio = Row.Field<string>("Bio"),
                              DateOfBirth = Row.Field<DateTime>("DateOfBirth"),
                              Response = Row.Field<string>("Response"),
                          }).ToList();
                        objCustomer.AddRange(lstCustomer);
                    }
                }
                return objCustomer;
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
