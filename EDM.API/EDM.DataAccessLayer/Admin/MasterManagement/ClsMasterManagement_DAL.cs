using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDM.Models.Admin.MasterManagement;

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
                objDBParameter = new DBParameter("@Ref_UserMasterControl_ID", ObjUserMaster.Ref_UserMasterControl_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@UserMaster", ObjUserMaster.UserMaster, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Description", ObjUserMaster.Description, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@ParentIDs", ObjUserMaster.ParentIDs, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@IsMandatory", ObjUserMaster.IsMandatory, DbType.Boolean);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@HasParent", ObjUserMaster.HasParent, DbType.Boolean);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@AllowAlphaNumeric", ObjUserMaster.AllowAlphaNumeric, DbType.Boolean);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@AllowNumeric", ObjUserMaster.AllowNumeric, DbType.Boolean);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@AllowNegativeNumbers", ObjUserMaster.AllowNegativeNumbers, DbType.Boolean);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@AllowSpecialCharacters", ObjUserMaster.AllowSpecialCharacters, DbType.Boolean);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@SpecialCharacters", ObjUserMaster.SpecialCharacters, DbType.String);
                ObJParameterCOl.Add(objDBParameter);


                string Massage = "";
                DBHelper objDbHelper = new DBHelper();
                Massage = Convert.ToString(objDbHelper.ExecuteScalar("[dbo].[AddModifyUserMaster]", ObJParameterCOl, CommandType.StoredProcedure));

                return Massage;
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
                DataSet ds = objDbHelper.ExecuteDataSet("[dbo].[GetUserMasterList]", CommandType.StoredProcedure);
                List<ClsUserMaster> objUserMaster = new List<ClsUserMaster>();

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        IList<ClsUserMaster> List = ds.Tables[0].AsEnumerable().Select(Row =>
                            new ClsUserMaster
                            {
                                Ref_UserMaster_ID = Row.Field<Int64>("Ref_UserMaster_ID"),
                                Ref_UserMasterControl_ID = Row.Field<Int64>("Ref_UserMasterControl_ID"),
                                UserMaster = Row.Field<string>("UserMaster"),
                                Description = Row.Field<string>("Description"),
                                ParentIDs = Row.Field<string>("ParentIDs"),
                                IsMandatory = Row.Field<Boolean>("IsMandatory")

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
                DBParameter objDBParameter = new DBParameter("@UserMasterID", UserMasterID, DbType.Int64);
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
                                userMasterName = Row.Field<string>("UserMaster"),
                                typeOfView = Row.Field<string>("TypeOfView"),
                                isCompulsory = Row.Field<Boolean>("isCompulsory"),
                                userMasterData = ds.Tables[1].AsEnumerable().Where(x => x.Field<Int64>("Ref_UserMaster_ID") == Row.Field<Int64>("Ref_UserMaster_ID")).Select(Row1 =>
                                    new ClsUserMasterData
                                    {
                                        Ref_UserMasterData_ID = Row1.Field<Int64>("Ref_UserMasterData_ID"),
                                        UserMasterData = Row1.Field<string>("UserMasterData")
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
                objDBParameter = new DBParameter("@UserMasterData", ObjUserMasterData.UserMasterData, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Description", ObjUserMasterData.Description, DbType.String);
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
                DBParameter objDBParameter = new DBParameter("@UserMasterID", UserMasterID, DbType.Int64);
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
                                UserMasterData = Row.Field<string>("UserMasterData"),
                                Description = Row.Field<string>("Description"),
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
                DBParameter objDBParameter = new DBParameter("@Ref_User_ID", ObjCategory.Ref_User_ID, DbType.Int64);
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
                objDBParameter = new DBParameter("@ThumbnailImageUrl", ObjCategory.ThumbnailImageUrl, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@IsActive", ObjCategory.IsActive, DbType.Boolean);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                return Convert.ToString(objDbHelper.ExecuteScalar("[dbo].[AddModifyCategory]", ObJParameterCOl, CommandType.StoredProcedure));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClsCategoryDetails> GetCategoryList()
        {
            try
            {
                DBHelper objDbHelper = new DBHelper();
                DataTable dt = objDbHelper.ExecuteDataTable("[dbo].[GetCategoryList]", CommandType.StoredProcedure);
                List<ClsCategoryDetails> objUserMaster = new List<ClsCategoryDetails>();

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        IList<ClsCategoryDetails> List = dt.AsEnumerable().Select(Row =>
                            new ClsCategoryDetails
                            {
                                Ref_Category_ID = Row.Field<Int64>("Ref_Category_ID"),
                                Ref_Parent_ID = Row.Field<Int64>("Ref_Parent_ID"),
                                CategoryName = Row.Field<string>("CategoryName"),
                                AliasName = Row.Field<string>("AliasName"),
                                CategoryUseBy = Row.Field<string>("CategoryUseBy"),
                                Description = Row.Field<string>("Description"),
                                ThumbnailImageUrl = Row.Field<string>("ThumbnailImageUrl"),
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

        public void Dispose()
        {

        }

    }

}
