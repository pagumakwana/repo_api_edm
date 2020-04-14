using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.Common;


namespace EDM
{
      internal class CommandBuilder
    {
        private string _providerName = string.Empty;
        private DBParamBuilder _paramBuilder = null;
        private AssemblyProvider _assemblyProvider = null;

        public CommandBuilder()
        {
            this._providerName = Configuration.GetProviderName(Configuration.DefaultConnection);
            _paramBuilder = new DBParamBuilder(this._providerName);
            _assemblyProvider = new AssemblyProvider(this._providerName);
        }

        public CommandBuilder(string providerName)
        {
            this._providerName = providerName;
            _paramBuilder = new DBParamBuilder(providerName);
            _assemblyProvider = new AssemblyProvider(this._providerName);
        }

        

        #region Inrernal Methods
        internal IDbCommand GetCommand(string commandText, IDbConnection connection)
        {
            return GetCommand(commandText, connection, CommandType.Text);
        }


        internal IDbCommand GetCommand(string commandText, IDbConnection connection, CommandType commandType)
        {
            IDbCommand command = GetCommand();
            command.CommandText = commandText;
            command.Connection = connection;
            command.CommandType = commandType;
            command.CommandTimeout = 0;
            return command;
        }


        internal IDbCommand GetCommand(string commandText, IDbConnection connection, DBParameter parameter)
        {
            return GetCommand(commandText, connection, parameter, CommandType.Text);
        }

        internal IDbCommand GetCommand(string commandText, IDbConnection connection, DBParameter parameter, CommandType commandType)
        {
            IDataParameter param = _paramBuilder.GetParameter(parameter);
            IDbCommand command = GetCommand(commandText, connection, commandType);
            command.Parameters.Add(param);
            return command;
        }

        internal IDbCommand GetCommand(string commandText, IDbConnection connection, DBParameterCollection parameterCollection)
        {
            return GetCommand(commandText, connection, parameterCollection, CommandType.Text);
        }

        internal IDbCommand GetCommand(string commandText, IDbConnection connection, DBParameterCollection parameterCollection, CommandType commandType)
        {
            List<DbParameter> paramArray = _paramBuilder.GetParameterCollection(parameterCollection);
            IDbCommand command = GetCommand(commandText, connection, commandType);

            foreach (IDataParameter param in paramArray)            
                command.Parameters.Add(param);
            
            return command;
        }


        #endregion

        #region Private Methods"

        private IDbCommand GetCommand()
        {                        
            //IDbCommand command = AssemblyProvider.GetInstance(_providerName).Factory.CreateCommand();            
            IDbCommand command = _assemblyProvider.Factory.CreateCommand();            
            return command;
        }

        #endregion
    }
}
