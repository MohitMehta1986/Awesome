using System.Data;

namespace petclinicmicroservice.Interfaces
{
	public interface IConnectionFactory
	{
		IDbConnection Create(string connectionString);
	}
}
