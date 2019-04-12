using System.Data;
using System.Text;
using petclinicmicroservice.Interfaces;

namespace petclinicmicroservice.Helper
{
	public abstract class Command:ICommand
    {
		public const int DefaultLongCommandTimeout = 3600; // in seconds
		private readonly CommandType commandType;
		private readonly string commandText;
		private readonly int? commandTimeout;

		protected Command(string storedProcedureName)
			: this(CommandType.StoredProcedure, storedProcedureName, null)
		{ }

		protected Command(string storedProcedureName, int commandTimeout)
			: this(CommandType.StoredProcedure, storedProcedureName, commandTimeout)
		{ }

		protected Command(CommandType commandType, string commandText)
			: this(commandType, commandText, null)
		{ }

		protected Command(CommandType commandType, string commandText, int commandTimeout)
			: this(commandType, commandText, (int?)commandTimeout)
		{ }

		private Command(CommandType commandType, string commandText, int? commandTimeout)
		{
			this.commandType = commandType;
			this.commandText = commandText;
			this.commandTimeout = commandTimeout;
		}

		public void Execute(IDbConnection connection)
		{
			Execute(connection, null);
		}

		public abstract void Execute(IDbConnection connection, IDbTransaction transaction);

		protected IDbCommand PrepareCommand(IDbConnection connection, IDbTransaction transaction)
		{

			var command = connection.CreateCommand();

			command.CommandType = commandType;
			command.CommandText = commandText;

			if (commandTimeout.HasValue)
			{
				command.CommandTimeout = commandTimeout.Value;
			}

			if (transaction != null)
			{
				command.Transaction = transaction;
			}

			SetParameters(command);

			return command;
		}

		protected abstract void SetParameters(IDbCommand command);

		protected static void AddParameter(IDbCommand command, string parameterName, object parameterValue)
		{
			AddParameter(command, parameterName, parameterValue, null, null);
		}

		protected static void AddParameter(IDbCommand command, string parameterName, object parameterValue, DbType? dbType)
		{
			AddParameter(command, parameterName, parameterValue, dbType, null);
		}

		protected static void AddParameter(IDbCommand command, string parameterName, object parameterValue, DbType? dbType, int? size)
		{

			var parameter = command.CreateParameter();
			parameter.ParameterName = parameterName;
			parameter.Value = parameterValue ?? System.DBNull.Value;
			if (dbType.HasValue)
			{
				parameter.DbType = dbType.Value;
			}
			if (size.HasValue)
			{
				parameter.Size = size.Value;
			}
			command.Parameters.Add(parameter);
		}

		protected static string LogCommand(IDbCommand command)
		{
			var sb = new StringBuilder();
			sb.AppendFormat("Execute command text: '{0}', parameters: [", command.CommandText);
			for (var i = 0; i < command.Parameters.Count; i++)
			{
				if (i > 0)
				{
					sb.Append(", ");
				}
				sb.Append(CommandParameterToString(command.Parameters[i]));
			}
			sb.AppendFormat("], timeout: {0}", command.CommandTimeout);
			return sb.ToString();
		}

		private static string CommandParameterToString(object parameter)
		{
			var dataParameter = parameter as IDataParameter;
			if (dataParameter == null)
			{
				return parameter.ToString();
			}

			return string.Format("{{ {0} {1} = {2} }}", dataParameter.DbType, dataParameter.ParameterName, dataParameter.Value);
		}
	}
}

