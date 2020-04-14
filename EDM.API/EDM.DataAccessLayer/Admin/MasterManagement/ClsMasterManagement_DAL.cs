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

        public List<ClsUserMasterControl> GetUserMasterControlList()
        {
            try
            {

                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet("[API].[GetUserMasterControlList]", CommandType.StoredProcedure);
                List<ClsUserMasterControl> objUserMaster = new List<ClsUserMasterControl>();

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        IList<ClsUserMasterControl> List = ds.Tables[0].AsEnumerable().Select(Row =>
                            new ClsUserMasterControl
                            {
                                Ref_UserMasterControl_ID = Row.Field<Int64>("Ref_UserMasterControl_ID"),
                                UserMasterControl = Row.Field<string>("UserMasterControl"),
                                ControlUseBy = Row.Field<string>("ControlUseBy"),

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
        public string AddUserMaster(ClsUserMaster ObjUserMaster)
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
        public List<ClsUserMaster> GetUserMasterList()
        {
            try
            {

                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet("[API].[GetUserMasterList]", CommandType.StoredProcedure);
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
                DataSet ds = objDbHelper.ExecuteDataSet("[API].[GetParentUserMasterList]", ObJParameterCOl, CommandType.StoredProcedure);
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
                                userMasterData = ds.Tables[0].AsEnumerable().Where(x => x.Field<Int64>("Ref_UserMaster_ID") == Row.Field<Int64>("Ref_UserMaster_ID")).Select(Row1 =>
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
        public string AddUserMasterData(ClsUserMasterData ObjUserMasterData)
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
                DataSet ds = objDbHelper.ExecuteDataSet("[API].[GetUserMasterDataList]", ObJParameterCOl, CommandType.StoredProcedure);
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
        public List<ClsMeasureTypeNameList> GetMeasureTypeList()
        {
            try
            {

                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet("[API].[GetMeasureTypeList]", CommandType.StoredProcedure);
                List<ClsMeasureTypeNameList> objUserMaster = new List<ClsMeasureTypeNameList>();

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        IList<ClsMeasureTypeNameList> List = ds.Tables[0].AsEnumerable().Select(Row =>
                            new ClsMeasureTypeNameList
                            {
                                Ref_MeasureType_ID = Row.Field<Int64>("Ref_MeasureType_ID"),
                                MeasureType = Row.Field<string>("MeasureType"),

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
        public List<ClsMeasureNameList> GetMeasureNameList()
        {
            try
            {

                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet("[API].[GetMeasureNameList]", CommandType.StoredProcedure);
                List<ClsMeasureNameList> objUserMaster = new List<ClsMeasureNameList>();

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        IList<ClsMeasureNameList> List = ds.Tables[0].AsEnumerable().Select(Row =>
                            new ClsMeasureNameList
                            {
                                Ref_Measure_ID = Row.Field<Int64>("Ref_Measure_ID"),
                                Measure = Row.Field<string>("Measure"),

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
        public List<ClsCategoryNameList> GetCategoryNameList()
        {
            try
            {

                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet("[API].[GetCategoryNameList]", CommandType.StoredProcedure);
                List<ClsCategoryNameList> objUserMaster = new List<ClsCategoryNameList>();

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        IList<ClsCategoryNameList> List = ds.Tables[0].AsEnumerable().Select(Row =>
                            new ClsCategoryNameList
                            {
                                Ref_Category_ID = Row.Field<Int64>("Ref_Category_ID"),
                                CategoryName = Row.Field<string>("CategoryName"),

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
        public List<ClsBrandNameList> GetBrandNameList()
        {
            try
            {

                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet("[API].[GetBrandNameList]", CommandType.StoredProcedure);
                List<ClsBrandNameList> objUserMaster = new List<ClsBrandNameList>();

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        IList<ClsBrandNameList> List = ds.Tables[0].AsEnumerable().Select(Row =>
                            new ClsBrandNameList
                            {
                                Ref_Brand_ID = Row.Field<Int64>("Ref_Brand_ID"),
                                BrandName = Row.Field<string>("BrandName"),

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
        public List<ClsManufacturerNameList> GetManufacturerNameList()
        {
            try
            {

                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet("[API].[GetManufacturerNameList]", CommandType.StoredProcedure);
                List<ClsManufacturerNameList> objUserMaster = new List<ClsManufacturerNameList>();

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        IList<ClsManufacturerNameList> List = ds.Tables[0].AsEnumerable().Select(Row =>
                            new ClsManufacturerNameList
                            {
                                Ref_Manufacturer_ID = Row.Field<Int64>("Ref_Manufacturer_ID"),
                                Manufacture = Row.Field<string>("Manufacture"),

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

        public List<ClsSKUCodeList> GetSKUNameList(ClsSKUCodeList ObjSKU)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@Ref_SKU_ID", ObjSKU.Ref_SKU_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@SKUCode", ObjSKU.SKUCode, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Description", ObjSKU.Description, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@ActiveFlage", ObjSKU.ActiveFlage, DbType.Boolean);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet("[API].[GetSKUNameList]", ObJParameterCOl, CommandType.StoredProcedure);
                List<ClsSKUCodeList> objUserMaster = new List<ClsSKUCodeList>();

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        IList<ClsSKUCodeList> List = ds.Tables[0].AsEnumerable().Select(Row =>
                            new ClsSKUCodeList
                            {
                                Ref_SKU_ID = Row.Field<Int64>("Ref_SKU_ID"),
                                SKUCode = Row.Field<string>("SKUCode"),
                                Description = Row.Field<string>("Description"),
                                ActiveFlage = Row.Field<Boolean>("ActiveFlage"),
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
