using System.Data;
using System.Data.SqlClient;
using petclinicmicroservice.Interfaces;

namespace petclinicmicroservice.Helper
{
	public abstract class NonQueryCommand : Command, INonQueryCommand
	{
		protected NonQueryCommand(string storedProcedureName)
			: base(storedProcedureName)
		{ }

		protected NonQueryCommand(string storedProcedureName, int commandTimeout)
			: base(storedProcedureName, commandTimeout)
		{ }

		protected NonQueryCommand(CommandType commandType, string commandText)
			: base(commandType, commandText)
		{ }

		protected NonQueryCommand(CommandType commandType, string commandText, int commandTimeout)
			: base(commandType, commandText, commandTimeout)
		{ }

		public int AffectedRowsCount { get; protected set; }
		public int ReturnValue { get; private set; }

		public override void Execute(IDbConnection connection, IDbTransaction transaction)
		{
			using (var command = PrepareCommand(connection, transaction))
			
			
				AffectedRowsCount = command.ExecuteNonQuery();
				if (OutputParameter != null && OutputParameter.Direction == ParameterDirection.ReturnValue)
				{
					ReturnValue = (int)OutputParameter.Value;
				}
			
		}

		protected SqlParameter OutputParameter { get; set; }

		protected void AddOutputParameter(IDbCommand command)
		{
			

			var returnValue = new SqlParameter("returnValue", SqlDbType.Int) { Direction = ParameterDirection.ReturnValue };
			command.Parameters.Add(returnValue);
			OutputParameter = returnValue;
		}
	}
}
