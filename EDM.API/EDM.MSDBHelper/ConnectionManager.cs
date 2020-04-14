using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Reflection;
using System.Data.Common;

namespace EDM
{
    /// <summary>
    /// ConnectionManager takes care of establishing the connection to the database parameters specified into web.config or app.config file.
    /// </summary>
    internal class ConnectionManager
    {

        private string _connectionName = string.Empty;
        private string _connectionString = string.Empty;
        private string _providerName = string.Empty;
        private AssemblyProvider _assemblyProvider = null;

        internal ConnectionManager()
        {
            _connectionName = Configuration.DefaultConnection;
            _connectionString = Configuration.ConnectionString;
            _providerName = Configuration.ProviderName;
            _assemblyProvider = new AssemblyProvider(_providerName);
        }


        internal ConnectionManager(string connectionName)
        {
            _connectionName = connectionName;
            _connectionString = Configuration.GetConnectionString(connectionName);
            _providerName = Configuration.GetProviderName(connectionName);
            _assemblyProvider = new AssemblyProvider(_providerName);
        }

        internal ConnectionManager(string connectionString, string providerName)
        {
            _connectionString = connectionString;
            _providerName = providerName;
            _connectionName = string.Empty;
            _assemblyProvider = new AssemblyProvider(_providerName);
        }

        internal string ConnectionString
        {
            get
            {
                return _connectionString;
            }
        }

        internal string ProviderName
        {
            get
            {
                return _providerName;
            }
        }


        /// <summary>
        /// Establish Connection to the database and Return an open connection.
        /// </summary>
        /// <returns>Open connection to the database</returns>
        internal IDbConnection GetConnection()
        {
            IDbConnection connection = _assemblyProvider.Factory.CreateConnection();
            connection.ConnectionString = _connectionString;

            try
            {
                connection.Open();
            }
            catch (Exception err)
            {
                throw err;
            }

            return connection;
        }


    }
}
