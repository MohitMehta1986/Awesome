using System.Data;

namespace petclinicmicroservice.Interfaces
{
	public interface ICommand
	{
		void Execute(IDbConnection connection);
		void Execute(IDbConnection connection, IDbTransaction transaction);
	}
}
