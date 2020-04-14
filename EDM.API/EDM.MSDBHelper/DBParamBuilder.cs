using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.Common;

namespace EDM
{
    internal class DBParamBuilder
    {

        private string _providerName = string.Empty;
        private AssemblyProvider _assemblyProvider = null;

        internal DBParamBuilder(string providerName)
        {
            _assemblyProvider = new AssemblyProvider(providerName);
            _providerName = providerName;
        }

        internal DbParameter GetParameter(DBParameter parameter)
        {
            DbParameter dbParam = GetParameter();
            dbParam.ParameterName = parameter.Name;
            dbParam.Value = parameter.Value;
            dbParam.Direction = parameter.ParamDirection;
            dbParam.DbType = parameter.Type;

            return dbParam;
        }

        internal List<DbParameter> GetParameterCollection(DBParameterCollection parameterCollection)
        {
            List<DbParameter> dbParamCollection = new List<DbParameter>();
            DbParameter dbParam = null;
            foreach (DBParameter param in parameterCollection.Parameters)
            {
                dbParam = GetParameter(param);
                dbParamCollection.Add(dbParam);
            }

            return dbParamCollection;
        }

        #region Private Methods
        private DbParameter GetParameter()
        {
            //string typeName = AssemblyProvider.GetInstance().GetParameterType();
            //IDbDataParameter dbParam = (IDbDataParameter)AssemblyProvider.GetInstance().DBProviderAssembly.CreateInstance(typeName);
            //return dbParam;

            //DbParameter dbParam = AssemblyProvider.GetInstance(this._providerName).Factory.CreateParameter();
            DbParameter dbParam = _assemblyProvider.Factory.CreateParameter();
            return dbParam;

        }



        #endregion
    }
}
