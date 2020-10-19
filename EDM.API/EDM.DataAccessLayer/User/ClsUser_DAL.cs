using EDM.Models.Common;
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
        public string SignUp(ClsUserDetails ObjUser)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@Ref_User_ID", ObjUser.Ref_User_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@UserCode", ObjUser.UserCode, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@FullName", ObjUser.FullName, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@EmailID", ObjUser.EmailID, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Password", ObjUser.Password, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@MobileNumber", ObjUser.MobileNumber, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Bio", ObjUser.Bio, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Gender", ObjUser.Gender, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@StudioGears", ObjUser.StudioGears, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@SocialProfileUrl", ObjUser.SocialProfileUrl, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@PayPalEmailID", ObjUser.PayPalEmailID, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@AuthorityIDs", ObjUser.AuthorityIDs, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@UserMasterDataIDs", ObjUser.UserMasterDataIDs, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@CreatedBy", ObjUser.CreatedBy, DbType.String);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                Int64 Ref_User_ID = Convert.ToInt64(objDbHelper.ExecuteScalar(Constant.SignUp, ObJParameterCOl, CommandType.StoredProcedure));

                if (Ref_User_ID > 0)
                {
                    ObjUser.FileManager.ForEach(File =>
                    {
                        DBParameterCollection ObJParameterCOl1 = new DBParameterCollection();
                        DBParameter objDBParameter1 = new DBParameter("@FileManagerID", File.FileManagerID, DbType.Int64);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@ModuleID", Ref_User_ID, DbType.Int64);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@ModuleType", File.ModuleType, DbType.String);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@FileIdentifier", File.FileIdentifier, DbType.String);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@FileName", File.FileName, DbType.String);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@FilePath", File.FilePath, DbType.String);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@FileExtension", File.FileExtension, DbType.String);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@FileType", File.FileType, DbType.String);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@FileSize", File.FileSize, DbType.Int64);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@FileSequence", File.Sequence, DbType.Int32);
                        ObJParameterCOl1.Add(objDBParameter1);

                        objDbHelper.ExecuteScalar(Constant.SaveModuleFile, ObJParameterCOl1, CommandType.StoredProcedure).ToString();
                    });
                }

                if (Ref_User_ID > 0 && ObjUser.Ref_User_ID == 0)
                {
                    return "USERADDEDSUCCESS";
                }
                else if (Ref_User_ID > 0 && ObjUser.Ref_User_ID > 0)
                {
                    return "USERUPDATEDSUCCESS";
                }
                else
                {
                    return "USERALREADYEXISTS";
                }
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
                DBParameter objDBParameter = new DBParameter("@UserCode", ObjUser.User_Code, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@password", ObjUser.Password, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@IsSocialLogin", ObjUser.IsSocialLogin, DbType.Boolean);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet(Constant.SignIn, ObJParameterCOl, CommandType.StoredProcedure);

                List<ClsUserDetails> objUserDetails = new List<ClsUserDetails>();

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objUserDetails = ds.Tables[0].AsEnumerable().Select(Row =>
                            new ClsUserDetails
                            {
                                Ref_User_ID = Row.Field<Int64>("Ref_User_ID"),
                                UserCode = Row.Field<string>("UserCode"),
                                FullName = Row.Field<string>("FullName"),
                                EmailID = Row.Field<string>("EmailID"),
                                MobileNumber = Row.Field<string>("MobileNumber"),
                                Bio = Row.Field<string>("Bio"),
                                Gender = Row.Field<string>("Gender"),
                                StudioGears = Row.Field<string>("StudioGears"),
                                PayPalEmailID = Row.Field<string>("PayPalEmailID"),
                                SocialProfileUrl = Row.Field<string>("SocialProfileUrl"),
                                Response = Row.Field<string>("Response"),
                                FileManager = ds.Tables[1].AsEnumerable().Select(Row2 =>
                                    new ClsFileManager
                                    {
                                        FileManagerID = Row2.Field<Int64>("Ref_FileManager_ID"),
                                        FileIdentifier = Row2.Field<string>("FileIdentifier"),
                                        FileName = Row2.Field<string>("FileName"),
                                        FilePath = Row2.Field<string>("FilePath"),
                                        FileExtension = Row2.Field<string>("FileExtension"),
                                        FileSize = Row2.Field<Int64>("FileSize"),
                                        FileType = Row2.Field<string>("FileType"),
                                        Sequence = Row2.Field<int>("Sequence"),
                                    }).ToList(),
                                UserMaster = ds.Tables[2].AsEnumerable().Select(Row2 =>
                                    new ClsUserMasterMapping
                                    {
                                        MasterName = Row2.Field<string>("MasterName"),
                                        MasterDataName = Row2.Field<string>("MasterDataName"),
                                    }).ToList(),
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
        public List<ClsUserDetails> GetProducersList(Int64 UserID, int StartCount, int EndCount)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@UserID", UserID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@StartCount", StartCount, DbType.Int16);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@EndCount", EndCount, DbType.Int16);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataTable User = objDbHelper.ExecuteDataTable(Constant.GetProducersList, ObJParameterCOl, CommandType.StoredProcedure);
                List<ClsUserDetails> objUserDetails = new List<ClsUserDetails>();

                if (User != null)
                {
                    if (User.Rows.Count > 0)
                    {
                        objUserDetails = User.AsEnumerable().Select(Row =>
                            new ClsUserDetails
                            {
                                Ref_User_ID = Row.Field<Int64>("Ref_User_ID"),
                                UserCode = Row.Field<string>("UserCode"),
                                FullName = Row.Field<string>("FullName"),
                                EmailID = Row.Field<string>("EmailID"),
                                MobileNumber = Row.Field<string>("MobileNumber"),
                                ProfilePhoto = Row.Field<string>("ProfilePhoto"),
                                Bio = Row.Field<string>("Bio"),
                                Followed = Row.Field<string>("Followed"),
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
        public List<ClsProducerTrackAndBeatList> GetProducerTrackAndBeatList(Int64 ProducersID, Int64 UserID)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@ProducersID", ProducersID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@UserID", UserID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataSet User = objDbHelper.ExecuteDataSet(Constant.GetProducerTrackAndBeatList, ObJParameterCOl, CommandType.StoredProcedure);

                List<ClsProducerTrackAndBeatList> objProducerTrackAndBeat = new List<ClsProducerTrackAndBeatList>();

                if (User != null)
                {
                    if (User.Tables[0].Rows.Count > 0)
                    {
                        objProducerTrackAndBeat = User.Tables[0].AsEnumerable().Select(Row =>
                            new ClsProducerTrackAndBeatList
                            {
                                ProducerName = Row.Field<string>("ProducerName"),
                                ProfilePhoto = Row.Field<string>("ProfilePhoto"),
                                ProducerBio = Row.Field<string>("ProducerBio"),
                                ProducerFrom = Row.Field<string>("ProducerFrom"),
                                Followed = Row.Field<string>("Followed"),
                                Followers = Row.Field<Int64>("Followers"),
                                Following = Row.Field<Int64>("Following"),
                                Plays = Row.Field<Int64>("Plays"),
                                TrackAndBeat = User.Tables[1].AsEnumerable().Select(Row1 =>
                                    new ClsTrackAndBeatList
                                    {
                                        Ref_Track_ID = Row1.Field<Int64>("Ref_Track_ID"),
                                        CategoryName = Row1.Field<string>("CategoryName"),
                                        TrackName = Row1.Field<string>("TrackName"),
                                        TrackType = Row1.Field<string>("TrackType"),
                                        Bio = Row1.Field<string>("Bio"),
                                        Duration = Row1.Field<string>("Duration"),
                                        Price = Row1.Field<decimal>("Price"),
                                        BMP = Row1.Field<int>("BMP"),
                                        Plays = Row1.Field<Int64>("Plays"),
                                        ThumbnailImageUrl = Row1.Field<string>("Thumbnail"),
                                        TrackStatus = Row1.Field<string>("TrackStatus"),
                                        Favourite = Row1.Field<string>("Favourite"),
                                        IsTrack = Row1.Field<string>("IsTrack"),
                                        SoldOut = Row1.Field<string>("SoldOut"),
                                    }).ToList(),
                            }).ToList();
                    }
                }
                return objProducerTrackAndBeat;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ClsProducersServiceList> GetProducersCustomServicesList(Int64 ProducersID)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@ProducersID", ProducersID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataTable User = objDbHelper.ExecuteDataTable(Constant.GetProducersCustomServicesList, ObJParameterCOl, CommandType.StoredProcedure);
                List<ClsProducersServiceList> objServiceList = new List<ClsProducersServiceList>();

                if (User != null)
                {
                    if (User.Rows.Count > 0)
                    {
                        objServiceList = User.AsEnumerable().Select(Row =>
                            new ClsProducersServiceList
                            {
                                Ref_Service_ID = Row.Field<Int64>("Ref_Service_ID"),
                                CategoryName = Row.Field<string>("CategoryName"),
                                ServiceTitle = Row.Field<string>("ServiceTitle"),
                                Description = Row.Field<string>("Description"),
                                Price = Row.Field<decimal>("Price"),
                                ThumbnailImageUrl = Row.Field<string>("Thumbnail"),
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
        public List<ClsAvailableProducers> GetAvailableProducersForServices(Int64 UserID, Int64 ServiceID, int StartCount, int EndCount)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@UserID", UserID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@ServiceID", ServiceID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@StartCount", StartCount, DbType.Int16);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@EndCount", EndCount, DbType.Int16);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataTable User = objDbHelper.ExecuteDataTable(Constant.GetAvailableProducersForServices, ObJParameterCOl, CommandType.StoredProcedure);
                List<ClsAvailableProducers> objUserDetails = new List<ClsAvailableProducers>();

                if (User != null)
                {
                    if (User.Rows.Count > 0)
                    {
                        objUserDetails = User.AsEnumerable().Select(Row =>
                            new ClsAvailableProducers
                            {
                                Ref_User_ID = Row.Field<Int64>("Ref_User_ID"),
                                UserCode = Row.Field<string>("UserCode"),
                                FullName = Row.Field<string>("FullName"),
                                EmailID = Row.Field<string>("EmailID"),
                                MobileNumber = Row.Field<string>("MobileNumber"),
                                Bio = Row.Field<string>("Bio"),
                                ProducerFrom = Row.Field<string>("ProducerFrom"),
                                ProfilePhoto = Row.Field<string>("ProfilePhoto"),
                                Followed = Row.Field<string>("Followed"),
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
