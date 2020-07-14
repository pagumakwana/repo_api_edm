﻿using EDM.Models.User;
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
                DBParameter objDBParameter = new DBParameter("@Ref_User_ID", ObjUser.Ref_User_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@User_Code", ObjUser.User_Code, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@FullName", ObjUser.FullName, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@EmailID", ObjUser.EmailID, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Password", ObjUser.Password, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Profile_Photo", ObjUser.Profile_Photo, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@MobileNumber", ObjUser.MobileNumber, DbType.String);
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
                objDBParameter = new DBParameter("@SocialProfileUrl", ObjUser.SocialProfileUrl, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Govit_ID", ObjUser.Govit_ID, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@PayPalEmailID", ObjUser.PayPalEmailID, DbType.String);
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
                                Bio = Row.Field<string>("Bio"),
                                Gender = Row.Field<string>("Gender"),
                                //Pincode = Row.Field<Int64>("Pincode"),
                                Address = Row.Field<string>("Address"),
                                Address1 = Row.Field<string>("Address1"),
                                AuthorityIDs = Row.Field<string>("Ref_Authority_ID"),
                                UserMasterDataIDs = Row.Field<string>("UserMasterDataIDs"),
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

        public List<ClsProducersTrackList> GetProducersTrackAndBeatList(Int64 ProducersID)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@User_Code", ProducersID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataTable User = objDbHelper.ExecuteDataTable("[DBO].[GetProducersTrackAndBeatList]", ObJParameterCOl, CommandType.StoredProcedure);
                List<ClsProducersTrackList> objTrackList = new List<ClsProducersTrackList>();

                if (User != null)
                {
                    if (User.Rows.Count > 0)
                    {
                        objTrackList = User.AsEnumerable().Select(Row =>
                            new ClsProducersTrackList
                            {
                                Ref_Track_ID = Row.Field<Int64>("Ref_Track_ID"),
                                CategoryName = Row.Field<string>("CategoryName"),
                                TrackName = Row.Field<string>("TrackName"),
                                TrackType = Row.Field<string>("TrackType"),
                                Bio = Row.Field<string>("Bio"),
                                ThumbnailImageUrl = Row.Field<string>("ThumbnailImageUrl"),
                                Duration = Row.Field<int>("Duration"),
                                Price = Row.Field<decimal>("Price"),
                                BMP = Row.Field<int>("BMP"),
                                TrackStatus = Row.Field<string>("TrackStatus"),
                                IsTrack = Row.Field<string>("IsTrack"),
                            }).ToList();
                    }
                }
                return objTrackList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClsProducersServiceList> GetCustomServicesList(Int64 ProducersID)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@ProducersID", ProducersID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataTable User = objDbHelper.ExecuteDataTable("[DBO].[GetCustomServicesList]", ObJParameterCOl, CommandType.StoredProcedure);
                List<ClsProducersServiceList> objServiceList = new List<ClsProducersServiceList>();

                if (User != null)
                {
                    if (User.Rows.Count > 0)
                    {
                        objServiceList = User.AsEnumerable().Select(Row =>
                            new ClsProducersServiceList
                            {
                                Ref_Service_ID = Row.Field<Int64>("Ref_Service_ID"),
                                CategoryName = Row.Field<string>("Ref_Category_ID"),
                                ServiceTitle = Row.Field<string>("ServiceTitle"),
                                Description = Row.Field<string>("Description"),
                                Price = Row.Field<decimal>("Price"),
                                ThumbnailImageUrl = Row.Field<string>("ThumbnailImageUrl"),
                            }).ToList();
                    }
                }
                return objServiceList;
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
