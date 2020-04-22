using EDM.Models.Admin.Gener;
using EDM.Models.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.DataAccessLayer.Admin.Gener
{
    public class ClsGenerManagement_DAL : IDisposable
    {
        public string GenerAddModify(ClsGenerManagement_BO objClsGenerManagement_BO)
        {
            try
            {
                string ResponseMessage = "";
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@Ref_Gener_ID", objClsGenerManagement_BO.Ref_Gener_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Ref_ParentGener_ID", objClsGenerManagement_BO.Ref_ParentGener_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@GenerName", objClsGenerManagement_BO.GenerName, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Description", objClsGenerManagement_BO.Description, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@DisplayOnHome", objClsGenerManagement_BO.DisplayOnHome, DbType.Boolean);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet(Constant.GenerAddModify, ObJParameterCOl, CommandType.StoredProcedure);
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

        public List<ClsGenerManagement_BO> GenerList(ClsGenerManagement_BO objClsGenerManagement_BO)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@Ref_Gener_ID", objClsGenerManagement_BO.Ref_Gener_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Ref_ParentGener_ID", objClsGenerManagement_BO.Ref_ParentGener_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Flag", objClsGenerManagement_BO.Flag, DbType.String);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet(Constant.GenerList, ObJParameterCOl, CommandType.StoredProcedure);
                List<ClsGenerManagement_BO> lstGener = new List<ClsGenerManagement_BO>();
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lstGener = ds.Tables[0].AsEnumerable().Select(Row =>
                          new ClsGenerManagement_BO
                          {
                              Ref_Gener_ID = Row.Field<Int64>("Ref_Gener_ID"),
                              Ref_ParentGener_ID = Row.Field<Int64>("Ref_ParentGener_ID"),
                              GenerName = Row.Field<string>("GenerName"),
                              Description = Row.Field<string>("Description"),
                              CreatedDateTime = Row.Field<DateTime?>("CreatedDateTime"),
                              CreatedBy = Row.Field<Int64?>("CreatedBy"),
                              UpdatedDateTime = Row.Field<DateTime?>("UpdatedDateTime"),
                              UpdatedBy = Row.Field<Int64?>("UpdatedBy"),
                              IsActive = Row.Field<Boolean>("IsActive"),
                              IsDeleted = Row.Field<Boolean>("IsDeleted")
                          }).ToList();
                    }
                }
                return lstGener;
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
