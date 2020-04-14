using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Reflection;
using System.Data.SqlClient;
using System.Data.Common;

namespace EDM
{
    internal class DataAdapterManager
    {
        private CommandBuilder _commandBuilder = null;
        private AssemblyProvider _assemblyProvider = null;
        private string _providerName = string.Empty;

        public DataAdapterManager()
        {
            this._providerName = Configuration.GetProviderName(Configuration.DefaultConnection);
            _commandBuilder = new CommandBuilder(_providerName);
            _assemblyProvider = new AssemblyProvider(_providerName);
        }

        public DataAdapterManager(string providerName)
        {
            this._providerName = providerName;
            _commandBuilder = new CommandBuilder(providerName);
            _assemblyProvider = new AssemblyProvider(_providerName);
        }

        internal DbDataAdapter GetDataAdapter(string sqlCommand, IDbConnection connection)
        {
            return GetDataAdapter(sqlCommand, connection, CommandType.Text);
        }


        internal DbDataAdapter GetDataAdapter(string sqlCommand, IDbConnection connection, DBParameter param, CommandType commandType)
        {
            DbDataAdapter adapter = null;
            IDbCommand command = _commandBuilder.GetCommand(sqlCommand, connection, param, commandType);
            adapter = GetDataAdapter(command);
            return adapter;
        }

        internal DbDataAdapter GetDataAdapter(string sqlCommand, IDbConnection connection, DBParameterCollection paramCollection, CommandType commandType)
        {
            DbDataAdapter adapter = null;
            IDbCommand command = _commandBuilder.GetCommand(sqlCommand, connection, paramCollection, commandType);
            adapter = GetDataAdapter(command);
            return adapter;
        }

        internal DbDataAdapter GetDataAdapter(string sqlCommand, IDbConnection connection, CommandType commandType)
        {
            DbDataAdapter adapter = null;
            IDbCommand command = _commandBuilder.GetCommand(sqlCommand, connection, commandType);
            adapter = GetDataAdapter(command);
            return adapter;
        }

        internal DataTable GetDataTable(string sqlCommand, DBParameterCollection paramCollection, IDbConnection connection, string tableName, CommandType commandType)
        {
            DataTable table = null;

            if (tableName != string.Empty)
                table = new DataTable(tableName);
            else
                table = new DataTable();

            IDbCommand command = null;
            if (paramCollection != null)
            {
                if (paramCollection.Parameters.Count > 0)
                    command = _commandBuilder.GetCommand(sqlCommand, connection, paramCollection, commandType);
                else
                    command = _commandBuilder.GetCommand(sqlCommand, connection, commandType);
            }
            else
                command = _commandBuilder.GetCommand(sqlCommand, connection, commandType);


            DbDataAdapter adapter = GetDataAdapter(command);
            ConstructorInfo constructor = adapter.GetType().GetConstructor(new Type[] { command.GetType() });
            adapter = (DbDataAdapter)constructor.Invoke(new object[] { command });
            MethodInfo method = adapter.GetType().GetMethod("Fill", new Type[] { typeof(DataTable) });

            try
            {
                method.Invoke(adapter, new object[] { table });
            }
            catch (Exception err)
            {
                throw err;
            }
            return table;
        }

        internal DataTable GetDataTable(string sqlCommand, DBParameter param, IDbConnection connection, string tableName, CommandType commandType)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(param);
            return GetDataTable(sqlCommand, paramCollection, connection, tableName, commandType);
        }

        internal DataTable GetDataTable(string sqlCommand, IDbConnection connection, string tableName, CommandType commandType)
        {
            return GetDataTable(sqlCommand, new DBParameterCollection(), connection, tableName, commandType);
        }

        internal DataTable GetDataTable(string sqlCommand, IDbConnection connection, CommandType commandType)
        {
            return GetDataTable(sqlCommand, new DBParameterCollection(), connection, string.Empty, commandType);
        }

        internal DataTable GetDataTable(string sqlCommand, IDbConnection connection)
        {
            return GetDataTable(sqlCommand, new DBParameterCollection(), connection, string.Empty, CommandType.Text);
        }


        private DbDataAdapter GetDataAdapter(IDbCommand command)
        {
            //DbDataAdapter adapter = AssemblyProvider.GetInstance(this._providerName).Factory.CreateDataAdapter();
            DbDataAdapter adapter = _assemblyProvider.Factory.CreateDataAdapter();
            adapter.SelectCommand = (DbCommand)command;
            return adapter;
        }
    }
}
