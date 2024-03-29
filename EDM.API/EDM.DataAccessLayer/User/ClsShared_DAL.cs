﻿using EDM.Models.Common;
using EDM.Models.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.DataAccessLayer.User
{
    public class ClsShared_DAL : IDisposable
    {
        public List<ClsGlobalSearch> GlobalSearch(string SearchKeyWord)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@SearchKeyWord", SearchKeyWord, DbType.String);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet(Constant.GlobalSearch, ObJParameterCOl, CommandType.StoredProcedure);
                List<ClsGlobalSearch> objUserMasterData = new List<ClsGlobalSearch>();

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        IList<ClsGlobalSearch> List = ds.Tables[0].AsEnumerable().Select(Row =>
                            new ClsGlobalSearch
                            {
                                Ref_Object_ID = Row.Field<Int64>("Ref_Object_ID"),
                                ObjectType = Row.Field<string>("ObjectType"),
                                Title = Row.Field<string>("Title"),
                                Bio = Row.Field<string>("Bio"),
                                Price = Row.Field<decimal>("Price"),
                                Thumbnail = Row.Field<string>("Thumbnail"),
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

        public List<ClsParentCategory> GetParentCategoryList()
        {
            try
            {
                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet(Constant.GetParentCategoryList, CommandType.StoredProcedure);
                List<ClsParentCategory> objParentCategory = new List<ClsParentCategory>();

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        IList<ClsParentCategory> List = ds.Tables[0].AsEnumerable().Select(Row =>
                            new ClsParentCategory
                            {
                                CategoryID = Row.Field<Int64>("Ref_Category_ID"),
                                CategoryUseBy = Row.Field<string>("CategoryUseBy"),
                                CategoryName = Row.Field<string>("CategoryName"),
                                AliasName = Row.Field<string>("AliasName"),
                                Description = Row.Field<string>("Description"),
                                MetaTitle = Row.Field<string>("MetaTitle"),
                                MetaKeywords = Row.Field<string>("MetaKeywords"),
                                MetaDescription = Row.Field<string>("MetaDescription"),
                                Thumbnail = Row.Field<string>("Thumbnail"),
                            }).ToList();
                        objParentCategory.AddRange(List);
                    }
                }
                return objParentCategory;
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
