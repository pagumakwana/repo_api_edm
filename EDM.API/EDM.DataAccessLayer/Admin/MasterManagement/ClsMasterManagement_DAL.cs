using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDM.Models.Admin.MasterManagement;
using EDM.Models.Common;

namespace EDM.DataAccessLayer.Admin.MasterManagement
{
    public class ClsMasterManagement_DAL : IDisposable
    {
        public string AddModifyUserMaster(ClsUserMaster ObjUserMaster)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@Ref_UserMaster_ID", ObjUserMaster.Ref_UserMaster_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@ControlName", ObjUserMaster.ControlName, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@MasterName", ObjUserMaster.UserMaster, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Description", ObjUserMaster.Description, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@MandatoryMasterIDs", ObjUserMaster.MandatoryMasterIDs, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@IsMandatory", ObjUserMaster.IsMandatory, DbType.Boolean);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@NonMandatoryMasterIDs", ObjUserMaster.NonMandatoryMasterIDs, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@IsActive", ObjUserMaster.IsActive, DbType.Boolean);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@AddedBy", ObjUserMaster.AddedBy, DbType.String);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                return Convert.ToString(objDbHelper.ExecuteScalar(Constant.AddModifyUserMaster, ObJParameterCOl, CommandType.StoredProcedure));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ClsUserMaster> GetUserMasterList(Int64 UserMasterID)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@Ref_UserMaster_ID", UserMasterID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet(Constant.GetUserMasterList, ObJParameterCOl, CommandType.StoredProcedure);
                List<ClsUserMaster> objUserMaster = new List<ClsUserMaster>();

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        IList<ClsUserMaster> List = ds.Tables[0].AsEnumerable().Select(Row =>
                            new ClsUserMaster
                            {
                                Ref_UserMaster_ID = Row.Field<Int64>("Ref_UserMaster_ID"),
                                ControlName = Row.Field<string>("ControlName"),
                                UserMaster = Row.Field<string>("MasterName"),
                                Description = Row.Field<string>("Description"),
                                MandatoryMasterIDs = Row.Field<string>("MandatoryMasterIDs"),
                                NonMandatoryMasterIDs = Row.Field<string>("NonMandatoryMasterIDs"),
                                IsMandatory = Row.Field<Boolean>("IsMandatory"),
                                IsActive = Row.Field<Boolean>("IsActive"),
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
        public List<ClsParentUserMaster> GetParentUserMasterList(Int64 UserMasterID)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@Ref_UserMaster_ID", UserMasterID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet(Constant.GetParentUserMasterList, ObJParameterCOl, CommandType.StoredProcedure);
                List<ClsParentUserMaster> objUserMasterData = new List<ClsParentUserMaster>();

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        IList<ClsParentUserMaster> List = ds.Tables[0].AsEnumerable().Select(Row =>
                            new ClsParentUserMaster
                            {
                                Ref_UserMaster_ID = Row.Field<Int64>("Ref_UserMaster_ID"),
                                UserMaster = Row.Field<string>("MasterName"),
                                ControlName = Row.Field<string>("ControlName"),
                                IsMandatory = Row.Field<Boolean>("IsMandatory"),
                                userMasterData = ds.Tables[1].AsEnumerable().Where(x => x.Field<Int64>("Ref_UserMaster_ID") == Row.Field<Int64>("Ref_UserMaster_ID")).Select(Row1 =>
                                    new ClsUserMasterData
                                    {
                                        Ref_UserMasterData_ID = Row1.Field<Int64>("Ref_UserMasterData_ID"),
                                        UserMasterData = Row1.Field<string>("MasterDataName")
                                    }).ToList()
                            }).ToList();
                        objUserMasterData.AddRange(List);
                    }
                }
                return objUserMasterData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string AddModifyUserMasterData(ClsUserMasterData ObjUserMasterData)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@Ref_UserMaster_ID", ObjUserMasterData.Ref_UserMaster_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Ref_UserMasterData_ID", ObjUserMasterData.Ref_UserMasterData_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@MasterDataName", ObjUserMasterData.UserMasterData, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Description", ObjUserMasterData.Description, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@MandatoryMasterIDs", ObjUserMasterData.MandatoryMasterIDs, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@NonMandatoryMasterIDs", ObjUserMasterData.NonMandatoryMasterIDs, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@AddedBy", ObjUserMasterData.AddedBy, DbType.String);
                ObJParameterCOl.Add(objDBParameter);

                string Massage = "";
                DBHelper objDbHelper = new DBHelper();
                Massage = Convert.ToString(objDbHelper.ExecuteScalar(Constant.AddModifyUserMasterData, ObJParameterCOl, CommandType.StoredProcedure));

                return Massage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ClsUserMasterData> GetUserMasterDataList(Int64 UserMasterID, Int64 UserMasterDataID)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@Ref_UserMasterData_ID", UserMasterDataID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@UserMasterID", UserMasterID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet(Constant.GetUserMasterDataList, ObJParameterCOl, CommandType.StoredProcedure);
                List<ClsUserMasterData> objUserMasterData = new List<ClsUserMasterData>();

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        IList<ClsUserMasterData> List = ds.Tables[0].AsEnumerable().Select(Row =>
                            new ClsUserMasterData
                            {
                                Ref_UserMaster_ID = Row.Field<Int64>("Ref_UserMaster_ID"),
                                Ref_UserMasterData_ID = Row.Field<Int64>("Ref_UserMasterData_ID"),
                                UserMasterData = Row.Field<string>("MasterDataName"),
                                UserMaster = Row.Field<string>("MasterName"),
                                Description = Row.Field<string>("Description"),
                                MandatoryMasterIDs = Row.Field<string>("MandatoryMasterIDs"),
                                NonMandatoryMasterIDs = Row.Field<string>("NonMandatoryMasterIDs"),
                                IsActive = Row.Field<Boolean>("IsActive"),
                            }).ToList();
                        objUserMasterData.AddRange(List);
                    }
                }
                return objUserMasterData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string AddModifyCategory(ClsCategoryDetails ObjCategory)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@Ref_Category_ID", ObjCategory.Ref_Category_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Ref_Parent_ID", ObjCategory.Ref_Parent_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@CategoryName", ObjCategory.CategoryName, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@AliasName", ObjCategory.AliasName, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@CategoryUseBy", ObjCategory.CategoryUseBy, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Description", ObjCategory.Description, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@MetaTitle", ObjCategory.MetaTitle, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@MetaKeywords", ObjCategory.MetaKeywords, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@MetaDescription", ObjCategory.MetaDescription, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Ref_User_ID", ObjCategory.Ref_User_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                Int64 Ref_Category_ID = Convert.ToInt64(objDbHelper.ExecuteDataSet(Constant.AddModifyCategory, ObJParameterCOl, CommandType.StoredProcedure));

                if (Ref_Category_ID > 0)
                {
                    ObjCategory.FileManager.ForEach(File =>
                    {
                        DBParameterCollection ObJParameterCOl1 = new DBParameterCollection();
                        DBParameter objDBParameter1 = new DBParameter("@FileManagerID", File.FileManagerID, DbType.Int64);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@ModuleID", Ref_Category_ID, DbType.Int64);
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

                if (Ref_Category_ID > 0 && ObjCategory.Ref_Category_ID == 0)
                {
                    return "CATEGORYADDED";
                }
                else if (Ref_Category_ID > 0 && ObjCategory.Ref_Category_ID > 0)
                {
                    return "CATEGORYUPDATED";
                }
                else
                {
                    return "CATEGORYEXISTS";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ClsCategoryDetails> GetCategoryList(string Flag, Int64 Ref_Category_ID, string AliasName)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@Flag", Flag, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Ref_Category_ID", Ref_Category_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@AliasName", AliasName, DbType.String);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet(Constant.GetCategoryList, ObJParameterCOl, CommandType.StoredProcedure);

                List<ClsCategoryDetails> objCategoryList = new List<ClsCategoryDetails>();

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objCategoryList = ds.Tables[1].AsEnumerable().Select(Row =>
                        new ClsCategoryDetails
                        {
                            Ref_Category_ID = Row.Field<Int64>("Ref_Category_ID"),
                            Ref_Parent_ID = Row.Field<Int64>("Ref_Parent_ID"),
                            CategoryName = Row.Field<string>("CategoryName"),
                            AliasName = Row.Field<string>("AliasName"),
                            CategoryUseBy = Row.Field<Int64>("CategoryUseBy"),
                            Description = Row.Field<string>("Description"),
                            IsActive = Row.Field<Boolean>("IsActive"),
                            MetaTitle = Row.Field<string>("MetaTitle"),
                            MetaKeywords = Row.Field<string>("MetaKeywords"),
                            MetaDescription = Row.Field<string>("MetaDescription"),
                            FileManager = ds.Tables[1].AsEnumerable().Where(x => x.Field<Int64>("ModuleID") == Row.Field<Int64>("Ref_Category_ID")).Select(Row1 =>
                             new ClsFileManager
                             {
                                 FileManagerID = Row1.Field<Int64>("Ref_FileManager_ID"),
                                 FileIdentifier = Row1.Field<string>("FileIdentifier"),
                                 FileName = Row1.Field<string>("FileName"),
                                 FilePath = Row1.Field<string>("FilePath"),
                                 FileExtension = Row1.Field<string>("FileExtension"),
                                 FileSize = Row1.Field<Int64>("FileSize"),
                                 FileType = Row1.Field<string>("FileType"),
                                 Sequence = Row1.Field<int>("Sequence"),
                             }).ToList(),
                        }).ToList();
                    }
                }
                return objCategoryList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ClsDAW> GetDAWList()
        {
            try
            {
                DBHelper objDbHelper = new DBHelper();
                DataTable dt = objDbHelper.ExecuteDataTable(Constant.GetDAWList, CommandType.StoredProcedure);
                List<ClsDAW> objUserMaster = new List<ClsDAW>();

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        IList<ClsDAW> List = dt.AsEnumerable().Select(Row =>
                            new ClsDAW
                            {
                                Ref_DAW_ID = Row.Field<Int64>("Ref_DAW_ID"),
                                DAW = Row.Field<string>("DAW"),
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
        public string AddModifyCouponCode(ClsCouponDetails ObjCouponDetails)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@Ref_Coupon_ID", ObjCouponDetails.Ref_Coupon_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@CouponCode", ObjCouponDetails.CouponCode, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@CouponUseBy", ObjCouponDetails.CouponUseBy, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Description", ObjCouponDetails.Description, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@DiscountInPercentage", ObjCouponDetails.DiscountInPercentage, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@DiscountInMax", ObjCouponDetails.DiscountInMax, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@StartDate", ObjCouponDetails.StartDate, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@EndDate", ObjCouponDetails.EndDate, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@OneTimeUse", ObjCouponDetails.OneTimeUse, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@AudienceCount", ObjCouponDetails.AudienceCount, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@OnlyForNewUsers", ObjCouponDetails.OnlyForNewUsers, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@CreatedBy", ObjCouponDetails.CreatedBy, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@IsActive", ObjCouponDetails.IsActive, DbType.Boolean);
                ObJParameterCOl.Add(objDBParameter);

                Int64 Ref_CouponCode_ID = 0;

                DBHelper objDbHelper = new DBHelper();
                Ref_CouponCode_ID = Convert.ToInt64(objDbHelper.ExecuteScalar(Constant.AddModifyCouponCode, ObJParameterCOl, CommandType.StoredProcedure));

                if (Ref_CouponCode_ID > 0)
                {
                    ObjCouponDetails.CouponObject.ForEach(Object =>
                    {
                        DBParameterCollection ObJParameterCOl1 = new DBParameterCollection();
                        DBParameter objDBParameter1 = new DBParameter("@Ref_CouponCode_ID", Ref_CouponCode_ID, DbType.Int64);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@ObjectType", Object.ObjectType, DbType.String);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@Ref_Object_ID", Object.Ref_Object_ID, DbType.Int64);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@CreatedBy", ObjCouponDetails.CreatedBy, DbType.String);
                        ObJParameterCOl1.Add(objDBParameter1);

                        objDbHelper.ExecuteScalar("[dbo].[AddModifyCouponObjectMapping]", ObJParameterCOl1, CommandType.StoredProcedure);
                    });
                }

                if (Ref_CouponCode_ID > 0 && ObjCouponDetails.Ref_Coupon_ID == 0)
                {
                    return "COUPONCODEADDED";
                }
                else if (Ref_CouponCode_ID > 0 && ObjCouponDetails.Ref_Coupon_ID == 0)
                {
                    return "COUPONCODEUPDATED";
                }
                else
                {
                    return "COUPONCODEEXISTS";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ClsCouponDetails> GetCouponCodeList()
        {
            try
            {
                DBHelper objDbHelper = new DBHelper();
                DataSet Ds = objDbHelper.ExecuteDataSet(Constant.GetCouponCodeList, CommandType.StoredProcedure);
                List<ClsCouponDetails> ObjCouponDetails = new List<ClsCouponDetails>();

                if (Ds != null)
                {
                    if (Ds.Tables.Count > 0)
                    {
                        if (Ds.Tables[0].Rows.Count > 0)
                        {
                            IList<ClsCouponDetails> List = Ds.Tables[0].AsEnumerable().Select(Row =>
                            new ClsCouponDetails
                            {
                                Ref_Coupon_ID = Row.Field<Int64>("Ref_Coupon_ID"),
                                CouponCode = Row.Field<string>("CouponCode"),
                                Description = Row.Field<string>("Description"),
                                CouponUseBy = Row.Field<string>("CouponUseBy"),
                                DiscountInMax = Row.Field<Decimal>("DiscountInMax"),
                                DiscountInPercentage = Row.Field<Decimal>("DiscountInPercentage"),
                                StartDate = Row.Field<DateTime>("StartDate"),
                                EndDate = Row.Field<DateTime>("EndDate"),
                                OneTimeUse = Row.Field<Boolean>("OneTimeUse"),
                                OnlyForNewUsers = Row.Field<Boolean>("OnlyForNewUsers"),
                                AudienceCount = Row.Field<int>("AudienceCount"),
                                IsActive = Row.Field<Boolean>("IsActive"),
                                CouponObject = Ds.Tables[1].AsEnumerable().Where(x => x.Field<Int64>("Ref_Coupon_ID") == Row.Field<Int64>("Ref_Coupon_ID")).Select(Row1 =>
                                    new ClsCouponObject
                                    {
                                        ObjectType = Row1.Field<string>("ObjectType"),
                                        Ref_Object_ID = Row1.Field<Int64>("Ref_Object_ID")
                                    }).ToList()

                            }).ToList();
                            ObjCouponDetails.AddRange(List);
                        }
                    }
                }
                return ObjCouponDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ManageCouponCode(string CouponIDs, string Action)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@CouponIDs", CouponIDs, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Action", Action, DbType.String);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                return Convert.ToString(objDbHelper.ExecuteScalar(Constant.ManageCouponCode, ObJParameterCOl, CommandType.StoredProcedure));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string AddModifyBlogDetails(ClsBlogDetails ObjBlogDetails)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@Ref_Blog_ID", ObjBlogDetails.Ref_Blog_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@BlogTitle", ObjBlogDetails.BlogTitle, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Blog", ObjBlogDetails.Blog, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@IsActive", ObjBlogDetails.IsActive, DbType.Boolean);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@CreatedBy", ObjBlogDetails.CreatedBy, DbType.String);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                Int64 Ref_Blog_ID = Convert.ToInt64(objDbHelper.ExecuteScalar(Constant.AddModifyBlogDetails, ObJParameterCOl, CommandType.StoredProcedure));

                if (Ref_Blog_ID > 0)
                {
                    ObjBlogDetails.FileManager.ForEach(File =>
                    {
                        DBParameterCollection ObJParameterCOl1 = new DBParameterCollection();
                        DBParameter objDBParameter1 = new DBParameter("@FileManagerID", File.FileManagerID, DbType.Int64);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@ModuleID", Ref_Blog_ID, DbType.Int64);
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

                if (Ref_Blog_ID > 0 && ObjBlogDetails.Ref_Blog_ID == 0)
                {
                    return "BLOGADDED";
                }
                else if (Ref_Blog_ID > 0 && ObjBlogDetails.Ref_Blog_ID > 0)
                {
                    return "BLOGUPDATED";
                }
                else
                {
                    return "BLOGEXISTS";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ClsBlogDetails> GetBlogList(Int64 BlogID)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@Ref_Blog_ID", BlogID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet(Constant.GetBlogList, ObJParameterCOl, CommandType.StoredProcedure);
                List<ClsBlogDetails> ObjBlogDetails = new List<ClsBlogDetails>();

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        IList<ClsBlogDetails> List = ds.Tables[0].AsEnumerable().Select(Row =>
                            new ClsBlogDetails
                            {
                                Ref_Blog_ID = Row.Field<Int64>("Ref_Blog_ID"),
                                BlogTitle = Row.Field<string>("BlogTitle"),
                                Blog = Row.Field<string>("Blog"),
                                IsActive = Row.Field<Boolean>("IsActive"),
                                CreatedBy = Row.Field<string>("CreatedBy"),
                                FileManager = ds.Tables[1].AsEnumerable().Where(x => x.Field<Int64>("ModuleID") == Row.Field<Int64>("Ref_Blog_ID")).Select(Row1 =>
                                 new ClsFileManager
                                 {
                                     FileManagerID = Row1.Field<Int64>("Ref_FileManager_ID"),
                                     FileIdentifier = Row1.Field<string>("FileIdentifier"),
                                     FileName = Row1.Field<string>("FileName"),
                                     FilePath = Row1.Field<string>("FilePath"),
                                     FileExtension = Row1.Field<string>("FileExtension"),
                                     FileSize = Row1.Field<Int64>("FileSize"),
                                     FileType = Row1.Field<string>("FileType"),
                                     Sequence = Row1.Field<int>("Sequence"),
                                 }).ToList(),
                            }).ToList();
                        ObjBlogDetails.AddRange(List);
                    }
                }
                return ObjBlogDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ManageBlog(string BlogIDs, string Action)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@BlogIDs", BlogIDs, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Action", Action, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                DBHelper objDbHelper = new DBHelper();
                return Convert.ToString(objDbHelper.ExecuteScalar(Constant.ManageBlog, ObJParameterCOl, CommandType.StoredProcedure));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string AddModifyBannerDetails(ClsBannerDetails ObjBannerDetails)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@Ref_Banner_ID", ObjBannerDetails.Ref_Banner_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@BannerTitle", ObjBannerDetails.BannerTitle, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@BannerPageName", ObjBannerDetails.BannerPageName, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Descripation", ObjBannerDetails.Descripation, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@IsActive", ObjBannerDetails.IsActive, DbType.Boolean);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@CreatedBy", ObjBannerDetails.CreatedBy, DbType.String);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                Int64 Ref_Banner_ID = Convert.ToInt64(objDbHelper.ExecuteScalar(Constant.AddModifyBannerDetails, ObJParameterCOl, CommandType.StoredProcedure));

                if (Ref_Banner_ID > 0)
                {
                    ObjBannerDetails.FileManager.ForEach(File =>
                    {
                        DBParameterCollection ObJParameterCOl1 = new DBParameterCollection();
                        DBParameter objDBParameter1 = new DBParameter("@FileManagerID", File.FileManagerID, DbType.Int64);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@ModuleID", Ref_Banner_ID, DbType.Int64);
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

                if (Ref_Banner_ID > 0 && ObjBannerDetails.Ref_Banner_ID == 0)
                {
                    return "BANNERADDED";
                }
                else if (Ref_Banner_ID > 0 && ObjBannerDetails.Ref_Banner_ID > 0)
                {
                    return "BANNERUPDATED";
                }
                else
                {
                    return "BANNEREXISTS";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ClsBannerDetails> GetBannersList(Int64 BannerID)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@Ref_Banner_ID", BannerID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet(Constant.GetBannersList, ObJParameterCOl, CommandType.StoredProcedure);
                List<ClsBannerDetails> objUserMaster = new List<ClsBannerDetails>();

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        IList<ClsBannerDetails> List = ds.Tables[0].AsEnumerable().Select(Row =>
                            new ClsBannerDetails
                            {
                                Ref_Banner_ID = Row.Field<Int64>("Ref_Banner_ID"),
                                BannerTitle = Row.Field<string>("BannerTitle"),
                                BannerPageName = Row.Field<string>("BannerPageName"),
                                Descripation = Row.Field<string>("Descripation"),
                                IsActive = Row.Field<Boolean>("IsActive"),
                                CreatedBy = Row.Field<string>("CreatedBy"),
                                FileManager = ds.Tables[1].AsEnumerable().Where(x => x.Field<Int64>("ModuleID") == Row.Field<Int64>("Ref_Banner_ID")).Select(Row1 =>
                                 new ClsFileManager
                                 {
                                     FileManagerID = Row1.Field<Int64>("Ref_FileManager_ID"),
                                     FileIdentifier = Row1.Field<string>("FileIdentifier"),
                                     FileName = Row1.Field<string>("FileName"),
                                     FilePath = Row1.Field<string>("FilePath"),
                                     FileExtension = Row1.Field<string>("FileExtension"),
                                     FileSize = Row1.Field<Int64>("FileSize"),
                                     FileType = Row1.Field<string>("FileType"),
                                     Sequence = Row1.Field<int>("Sequence"),
                                 }).ToList(),
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
        public string ManageBanner(string BannerIDs, string Action)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@BannerIDs", BannerIDs, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Action", Action, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                DBHelper objDbHelper = new DBHelper();
                return Convert.ToString(objDbHelper.ExecuteScalar(Constant.ManageBanner, ObJParameterCOl, CommandType.StoredProcedure));

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
