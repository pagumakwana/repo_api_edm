using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDM.Models.Admin.AuthorityManagement;

namespace EDM.DataAccessLayer.Admin.AuthorityManagement
{
    public class ClsAuthorityManagement_DAL : IDisposable
    {
        public string AddModifyAuthority(ClsAuthority ObjAuthority)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@Ref_Authority_ID", ObjAuthority.Ref_Authority_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@AuthorityName", ObjAuthority.AuthorityName, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@AuthorityType", ObjAuthority.AuthorityType, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Description", ObjAuthority.Description, DbType.String);
                ObJParameterCOl.Add(objDBParameter);

                Int64 Ref_Authority_ID = 0;
                DBHelper objDbHelper = new DBHelper();
                Ref_Authority_ID = Convert.ToInt64(objDbHelper.ExecuteScalar("[dbo].[AddModifyAuthority]", ObJParameterCOl, CommandType.StoredProcedure));

                if (Ref_Authority_ID > 0)
                {
                    ObjAuthority.ModuleAccess.ForEach(Module =>
                    {
                        DBParameterCollection ObJParameterCOl1 = new DBParameterCollection();
                        DBParameter objDBParameter1 = new DBParameter("@Ref_Service_ID", Ref_Authority_ID, DbType.Int64);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@Ref_Module_ID", Module.Ref_Module_ID, DbType.Int64);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@View", Module.View, DbType.Boolean);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@Edit", Module.Edit, DbType.Boolean);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@Delete", Module.Delete, DbType.Boolean);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@CreatedBy", ObjAuthority.CreatedBy, DbType.String);
                        ObJParameterCOl1.Add(objDBParameter1);

                        objDbHelper.ExecuteScalar("[dbo].[AddModifyAuthorityModuleAccess]", ObJParameterCOl1, CommandType.StoredProcedure);
                    });
                }

                if (Ref_Authority_ID > 0 && ObjAuthority.Ref_Authority_ID == 0)
                {
                    return "AUTHORITYADDED";
                }
                else if (Ref_Authority_ID > 0 && ObjAuthority.Ref_Authority_ID == 0)
                {
                    return "AUTHORITYUPDATED";
                }
                else
                {
                    return "AUTHORITYEXISTS";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ClsAuthorityList> GetAuthorityList()
        {
            try
            {

                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet("[API].[GetAuthorityList]", CommandType.StoredProcedure);
                List<ClsAuthorityList> objUserMaster = new List<ClsAuthorityList>();

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        IList<ClsAuthorityList> List = ds.Tables[0].AsEnumerable().Select(Row =>
                            new ClsAuthorityList
                            {
                                Ref_Authority_ID = Row.Field<Int64>("Ref_Authority_ID"),
                                AuthorityName = Row.Field<string>("AuthorityName"),
                                AuthorityType = Row.Field<string>("AuthorityType")
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

        public List<ClsAuthority> GetAuthorityDetails(Int64 AuthorityID)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@AuthorityID", AuthorityID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet("[API].[GetAuthorityDetails]", ObJParameterCOl, CommandType.StoredProcedure);
                List<ClsAuthority> objUserMasterData = new List<ClsAuthority>();

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        IList<ClsAuthority> List = ds.Tables[0].AsEnumerable().Select(Row =>
                            new ClsAuthority
                            {
                                Ref_Authority_ID = Row.Field<Int64>("Ref_Authority_ID"),
                                AuthorityName = Row.Field<string>("AuthorityName"),
                                AuthorityType = Row.Field<string>("AuthorityType"),
                                Description = Row.Field<string>("Description"),
                                MasterDataIDs = Row.Field<string>("MasterDataIDs"),
                                ModuleAccess = ds.Tables[0].AsEnumerable().Where(x => x.Field<Int64>("Ref_Authority_ID") == Row.Field<Int64>("Ref_Authority_ID")).Select(Row1 =>
                                 new ClsModuleAccess
                                 {
                                     Ref_Module_ID = Row1.Field<Int64>("Ref_Module_ID"),
                                     View = Row1.Field<Boolean>("View"),
                                     Edit = Row1.Field<Boolean>("Edit"),
                                     Delete = Row1.Field<Boolean>("Delete")

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


        public void Dispose()
        {

        }
    }
}
