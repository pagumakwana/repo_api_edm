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
                return Convert.ToString(objDbHelper.ExecuteScalar("[dbo].[AddModifyUserMaster]", ObJParameterCOl, CommandType.StoredProcedure));

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
                DataSet ds = objDbHelper.ExecuteDataSet("[dbo].[GetUserMasterList]", ObJParameterCOl, CommandType.StoredProcedure);
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
                DataSet ds = objDbHelper.ExecuteDataSet("[dbo].[GetParentUserMasterList]", ObJParameterCOl, CommandType.StoredProcedure);
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
                Massage = Convert.ToString(objDbHelper.ExecuteScalar("[dbo].[AddModifyUserMasterData]", ObJParameterCOl, CommandType.StoredProcedure));

                return Massage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClsUserMasterData> GetUserMasterDataList(Int64 UserMasterID)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@Ref_UserMasterData_ID", UserMasterID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet("[dbo].[GetUserMasterDataList]", ObJParameterCOl, CommandType.StoredProcedure);
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
            string Response = "";
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@Flag", ObjCategory.Flag, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Ref_User_ID", ObjCategory.Ref_User_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Ref_Category_ID", ObjCategory.Ref_Category_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Ref_Parent_ID", ObjCategory.Ref_Parent_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@CategoryName", ObjCategory.CategoryName, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@AliasName", ObjCategory.AliasName, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@CategoryUseBy", ObjCategory.CategoryUseBy, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Description", ObjCategory.Description, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@CreatedName", ObjCategory.CreatedName, DbType.String);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet(Constant.AddModifyCategory, ObJParameterCOl, CommandType.StoredProcedure);

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ObjCategory.Flag.Equals("ADDCATEGORY") || ObjCategory.Flag.Equals("MODIFYCATEGORY"))
                        {
                            Response = ds.Tables[0].Rows[0]["Response"].ToString();
                            var Res = Response.Split('~');
                            ObjCategory.Ref_Category_ID = Convert.ToInt64(Res[1].ToString());
                            if (ObjCategory.Ref_Category_ID > 0 && (ObjCategory.FileUrls != null && ObjCategory.FileUrls.Count > 0))
                            {
                                ObjCategory.FileUrls.ForEach(image =>
                                {
                                    DBParameterCollection ObJParameterCOl1 = new DBParameterCollection();
                                    DBParameter objDBParameter1 = new DBParameter("@FileName", image.FileName, DbType.String);
                                    ObJParameterCOl1.Add(objDBParameter1);
                                    objDBParameter1 = new DBParameter("@FilePath", image.FilePath, DbType.String);
                                    ObJParameterCOl1.Add(objDBParameter1);
                                    objDBParameter1 = new DBParameter("@FileExtension", image.FileExtension, DbType.String);
                                    ObJParameterCOl1.Add(objDBParameter1);
                                    objDBParameter1 = new DBParameter("@FileSize", image.FileSize, DbType.Int64);
                                    ObJParameterCOl1.Add(objDBParameter1);
                                    objDBParameter1 = new DBParameter("@Ref_User_ID", ObjCategory.Ref_User_ID, DbType.Int64);
                                    ObJParameterCOl1.Add(objDBParameter1);
                                    objDBParameter1 = new DBParameter("@CreatedName", ObjCategory.CreatedName, DbType.String);
                                    ObJParameterCOl1.Add(objDBParameter1);
                                    objDBParameter1 = new DBParameter("@Ref_ID", ObjCategory.Ref_Category_ID, DbType.Int64);
                                    ObJParameterCOl1.Add(objDBParameter1);
                                    objDBParameter1 = new DBParameter("@ModuleName", image.ModuleName, DbType.String);
                                    ObJParameterCOl1.Add(objDBParameter1);
                                    DBHelper objDbHelper1 = new DBHelper();
                                    objDbHelper1.ExecuteScalar(Constant.AddMasterFile, ObJParameterCOl1, CommandType.StoredProcedure);

                                });
                            }
                            Response = Res[0].ToString();
                        }
                        else
                        {
                            Response = ds.Tables[0].Rows[0]["Response"].ToString();
                        }
                    }
                }
                return Response;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClsCategoryDetails> GetCategoryList(string Flag, Int64 Ref_Category_ID,string AliasName)
        {
            try
            {
                DBHelper objDbHelper = new DBHelper();
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@Flag", Flag, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Ref_Category_ID", Ref_Category_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@AliasName", AliasName, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                DataSet ds = objDbHelper.ExecuteDataSet(Constant.GetCategoryList, ObJParameterCOl, CommandType.StoredProcedure);
                List<ClsCategoryDetails> objCategoryList = new List<ClsCategoryDetails>();
                List<ClsFileInfo> lstImg = new List<ClsFileInfo>();
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lstImg = ds.Tables[0].AsEnumerable().Select(Row =>
                          new ClsFileInfo
                          {
                              Ref_ID = Row.Field<Int64>("Ref_ID"),
                              Ref_File_ID = Row.Field<Int64>("Ref_File_ID"),
                              FileName = Row.Field<string>("FileName"),
                              FilePath = Row.Field<string>("FilePath"),
                              FileExtension = Row.Field<string>("FileExtension"),
                              FileSize = Row.Field<long>("FileSize"),
                              ModuleName = Row.Field<string>("ModuleName")
                          }).ToList();
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        objCategoryList = ds.Tables[1].AsEnumerable().Select(Row =>
                            new ClsCategoryDetails
                            {
                                Ref_Category_ID = Row.Field<Int64>("Ref_Category_ID"),
                                Ref_Parent_ID = Row.Field<Int64>("Ref_Parent_ID"),
                                CategoryName = Row.Field<string>("CategoryName"),
                                AliasName = Row.Field<string>("AliasName"),
                                CategoryUseBy = Row.Field<string>("CategoryUseBy"),
                                Description = Row.Field<string>("Description"),
                                CreatedBy = Row.Field<Int64>("CreatedBy"),
                                CreatedName = Row.Field<string>("CreatedName"),
                                CreatedDateTime = Row.Field<DateTime?>("CreatedDateTime"),
                                UpdatedBy = Row.Field<Int64>("UpdatedBy"),
                                UpdatedName = Row.Field<string>("UpdatedName"),
                                UpdatedDateTime = Row.Field<DateTime?>("UpdatedDateTime"),
                                IsActive = Row.Field<Boolean>("IsActive"),
                                IsDeleted = Row.Field<Boolean>("IsDeleted"),
                                FileUrls = lstImg
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
                DataTable dt = objDbHelper.ExecuteDataTable("[dbo].[GetDAWList]", CommandType.StoredProcedure);
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
                Ref_CouponCode_ID = Convert.ToInt64(objDbHelper.ExecuteScalar("[dbo].[AddModifyCouponCode]", ObJParameterCOl, CommandType.StoredProcedure));

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
                DataSet Ds = objDbHelper.ExecuteDataSet("[dbo].[GetCouponCodeList]", CommandType.StoredProcedure);
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
                return Convert.ToString(objDbHelper.ExecuteScalar("[dbo].[ManageCouponCode]", ObJParameterCOl, CommandType.StoredProcedure));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string AddModifyBlog(ClsBlogDetails ObjBlog)
        {
            string Response = "";
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@Ref_Category_ID", ObjBlog.Ref_Blog_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@CategoryName", ObjBlog.BlogTitle, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@AliasName", ObjBlog.AliasName, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@CategoryUseBy", ObjBlog.CategoryUseBy, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Description", ObjBlog.Description, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@CreatedName", ObjBlog.CreatedName, DbType.String);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet(Constant.AddModifyCategory, ObJParameterCOl, CommandType.StoredProcedure);

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //if (ObjCategory.Flag.Equals("ADDCATEGORY") || ObjCategory.Flag.Equals("MODIFYCATEGORY"))
                        //{
                        //    Response = ds.Tables[0].Rows[0]["Response"].ToString();
                        //    var Res = Response.Split('~');
                        //    ObjCategory.Ref_Category_ID = Convert.ToInt64(Res[1].ToString());
                        //    if (ObjCategory.Ref_Category_ID > 0 && (ObjCategory.ImageUrls != null && ObjCategory.ImageUrls.Count > 0))
                        //    {
                        //        ObjCategory.ImageUrls.ForEach(image =>
                        //        {
                        //            DBParameterCollection ObJParameterCOl1 = new DBParameterCollection();
                        //            DBParameter objDBParameter1 = new DBParameter("@FileName", image.FileName, DbType.String);
                        //            ObJParameterCOl1.Add(objDBParameter1);
                        //            objDBParameter1 = new DBParameter("@FilePath", image.FilePath, DbType.String);
                        //            ObJParameterCOl1.Add(objDBParameter1);
                        //            objDBParameter1 = new DBParameter("@FileExtension", image.FileExtension, DbType.String);
                        //            ObJParameterCOl1.Add(objDBParameter1);
                        //            objDBParameter1 = new DBParameter("@FileSize", image.FileSize, DbType.Int64);
                        //            ObJParameterCOl1.Add(objDBParameter1);
                        //            objDBParameter1 = new DBParameter("@Ref_User_ID", ObjCategory.Ref_User_ID, DbType.Int64);
                        //            ObJParameterCOl1.Add(objDBParameter1);
                        //            objDBParameter1 = new DBParameter("@CreatedName", ObjCategory.CreatedName, DbType.String);
                        //            ObJParameterCOl1.Add(objDBParameter1);
                        //            objDBParameter1 = new DBParameter("@Ref_ID", ObjCategory.Ref_Category_ID, DbType.Int64);
                        //            ObJParameterCOl1.Add(objDBParameter1);
                        //            objDBParameter1 = new DBParameter("@ModuleName", image.ModuleName, DbType.String);
                        //            ObJParameterCOl1.Add(objDBParameter1);
                        //            DBHelper objDbHelper1 = new DBHelper();
                        //            objDbHelper1.ExecuteScalar(Constant.AddMasterFile, ObJParameterCOl1, CommandType.StoredProcedure);

                        //        });
                        //    }
                        //    Response = Res[0].ToString();
                        //}
                        //else
                        //{
                        //    Response = ds.Tables[0].Rows[0]["Response"].ToString();
                        //}
                    }
                }
                return Response;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClsBlogDetails> GetBlogList(Int64 Ref_Blog_ID)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter     objDBParameter = new DBParameter("@Ref_Blog_ID", Ref_Blog_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet(Constant.GetBlogList, ObJParameterCOl, CommandType.StoredProcedure);

                List<ClsBlogDetails> objBlogList = new List<ClsBlogDetails>();
                List<ClsFileInfo> lstImg = new List<ClsFileInfo>();

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lstImg = ds.Tables[0].AsEnumerable().Select(Row =>
                          new ClsFileInfo
                          {
                              Ref_ID = Row.Field<Int64>("Ref_ID"),
                              Ref_File_ID = Row.Field<Int64>("Ref_File_ID"),
                              FileName = Row.Field<string>("FileName"),
                              FilePath = Row.Field<string>("FilePath"),
                              FileExtension = Row.Field<string>("FileExtension"),
                              FileSize = Row.Field<long>("FileSize"),
                              ModuleName = Row.Field<string>("ModuleName")
                          }).ToList();
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        objBlogList = ds.Tables[1].AsEnumerable().Select(Row =>
                            new ClsBlogDetails
                            {
                                Ref_Blog_ID = Row.Field<Int64>("Ref_Blog_ID"),
                                AliasName = Row.Field<string>("AliasName"),
                                CategoryUseBy = Row.Field<string>("CategoryUseBy"),
                                Description = Row.Field<string>("Description"),
                                CreatedBy = Row.Field<Int64>("CreatedBy"),
                                CreatedName = Row.Field<string>("CreatedName"),
                                CreatedDateTime = Row.Field<DateTime?>("CreatedDateTime"),
                                UpdatedBy = Row.Field<Int64>("UpdatedBy"),
                                UpdatedName = Row.Field<string>("UpdatedName"),
                                UpdatedDateTime = Row.Field<DateTime?>("UpdatedDateTime"),
                                IsActive = Row.Field<Boolean>("IsActive"),
                                IsDeleted = Row.Field<Boolean>("IsDeleted"),
                                FileUrls = lstImg
                            }).ToList();
                    }
                }
                return objBlogList;
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
                objDBParameter = new DBParameter("@ImageUrl", ObjBannerDetails.ImageUrl, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@IsActive", ObjBannerDetails.IsActive, DbType.Boolean);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@CreatedBy", ObjBannerDetails.CreatedBy, DbType.String);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                return Convert.ToString(objDbHelper.ExecuteScalar("[dbo].[AddModifyBannerDetails]", ObJParameterCOl, CommandType.StoredProcedure));
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
                DataTable dt = objDbHelper.ExecuteDataTable("[dbo].[GetBannersList]", ObJParameterCOl, CommandType.StoredProcedure);
                List<ClsBannerDetails> objUserMaster = new List<ClsBannerDetails>();

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        IList<ClsBannerDetails> List = dt.AsEnumerable().Select(Row =>
                            new ClsBannerDetails
                            {
                                Ref_Banner_ID = Row.Field<Int64>("Ref_Banner_ID"),
                                BannerTitle = Row.Field<string>("BannerTitle"),
                                BannerPageName = Row.Field<string>("BannerPageName"),
                                Descripation = Row.Field<string>("Descripation"),
                                ImageUrl = Row.Field<string>("ImageUrl"),
                                IsActive = Row.Field<Boolean>("IsActive"),
                                CreatedBy = Row.Field<string>("CreatedBy")
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
