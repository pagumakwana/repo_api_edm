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
                DBParameter objDBParameter = new DBParameter("@Ref_UserMaster_ID", ObjAuthority.Ref_Authority_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Ref_UserMasterData_ID", ObjAuthority.AuthorityName, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@UserMasterData", ObjAuthority.AuthorityType, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Description", ObjAuthority.Description, DbType.String);
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
        public List<ClsAuthorityList> GetAuthorityList()
        {
            try
            {

                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet("[API].[GetUserMasterList]", CommandType.StoredProcedure);
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
                DataSet ds = objDbHelper.ExecuteDataSet("[API].[GetParentUserMasterList]", ObJParameterCOl, CommandType.StoredProcedure);
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
                                //userMasterData = ds.Tables[0].AsEnumerable().Where(x => x.Field<Int64>("Ref_UserMaster_ID") == Row.Field<Int64>("Ref_UserMaster_ID")).Select(Row1 =>
                                //    new ClsUserMasterData
                                //    {
                                //        Ref_UserMasterData_ID = Row1.Field<Int64>("Ref_UserMasterData_ID"),
                                //        UserMasterData = Row1.Field<string>("UserMasterData")
                                //    }).ToList()
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
