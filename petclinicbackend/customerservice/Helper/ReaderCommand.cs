using System;
using System.Data;
using petclinicmicroservice.Interfaces;

namespace petclinicmicroservice.Helper
{
	public abstract class ReaderCommand<TResult> : Command, IReaderCommand<TResult>
	{

		protected ReaderCommand(string storedProcedureName)
			: base(storedProcedureName)
		{ }

		protected ReaderCommand(string storedProcedureName, int commandTimeout)
			: base(storedProcedureName, commandTimeout)
		{ }

		protected ReaderCommand(CommandType commandType, string commandText)
			: base(commandType, commandText)
		{ }

		protected ReaderCommand(CommandType commandType, string commandText, int commandTimeout)
			: base(commandType, commandText, commandTimeout)
		{ }

		public TResult Result { get; protected set; }

		public override void Execute(IDbConnection connection, IDbTransaction transaction)
		{
			using (var command = PrepareCommand(connection, transaction))
			using (var reader = command.ExecuteReader())
			{
				Result = ProcessReader(reader);
			}
		}

		protected abstract TResult ProcessReader(IDataReader reader);

		protected static DbType GetDbType(string dataTypeName)
		{
			return DBTypeReaderFactory.GetDbType(dataTypeName);
		}

		protected static string ValueToString(IDataReader reader, int index, DbType dbType)
		{
			

			if (reader[index] == DBNull.Value)
			{
				return null;
			}

			if (dbType == DbType.Date)
			{
				return reader.GetDateTime(index).ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
			}
			else
			{
				return Convert.ToString(reader[index], System.Globalization.CultureInfo.InvariantCulture);
			}
		}
	}
}
