using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Google.Cloud.Datastore.V1;
using MySql.Data;
using MySql.Data.MySqlClient;
using petclinicmicroservice.Interfaces;

namespace petclinicmicroservice.Helper
{
	public class ConnectionFactory : IConnectionFactory
	{
		public const string ParAccelProviderName = "padotnet";

		private const string ProviderNameKey = "ProviderName";
		private const string PasswordKey = "Password";
		private const string DatabaseKey = "Database";


		public IDbConnection Create(string connectionString)
		{
			return GetOpenConnection(connectionString);
		}

		private DbConnection GetOpenConnection(string connectionString)
		{
			var connectionStringBuilder = new DbConnectionStringBuilder { ConnectionString = connectionString };
		   var providerName = connectionStringBuilder[ProviderNameKey].ToString();
			connectionStringBuilder.Remove(ProviderNameKey);
			switch (providerName)
			{
				case "Microsoft.Data.SqLite":
					return GetSqlConnection(connectionStringBuilder.ToString());
					
				case "MySql.Data":
					Console.WriteLine("connection string:" +connectionStringBuilder);
					var mysqlconnectionstring = new MySqlConnectionStringBuilder(connectionStringBuilder.ToString())
					{
						SslMode = MySqlSslMode.None,
						ConnectionTimeout = 1000,
						DefaultCommandTimeout = 1000
					};
					Console.WriteLine("my sql connection string:" + mysqlconnectionstring.ConnectionString);
					return GetMySqlConnection(connectionStringBuilder.ToString());
				default:
					return GetMySqlConnection(connectionStringBuilder.ToString());
			}
			/*DbProviderFactory factory;
			DbProviderFactories.TryGetFactory(providerName, out factory);
			connectionStringBuilder.Remove(ProviderNameKey);
			DbConnection dbConnection = DbProviderFactories.GetFactory(dbProvider.CreateConnection()).CreateConnection();
			string database = connectionStringBuilder[DatabaseKey].ToString().ToLowerInvariant();
			connectionStringBuilder.Remove(DatabaseKey);
			connectionStringBuilder.Add(DatabaseKey, database);

			if (!connectionStringBuilder.ContainsKey(PasswordKey))
			{
				dbConnection.ConnectionString = connectionStringBuilder.ToString();
				dbConnection.Open();
				return dbConnection;
			}
				connectionStringBuilder[PasswordKey] = "password";
				dbConnection.ConnectionString = connectionStringBuilder.ToString();
				dbConnection.Open();
				return dbConnection;*/
			
		}


		private MySqlConnection GetMySqlConnection(string connectionString)
		{
			var mysqlConnection= new MySqlConnection(connectionString);
			mysqlConnection.Open();
			return mysqlConnection;
		}

		private SqlConnection GetSqlConnection(string connectionstring)
		{
			var sqlConnection = new SqlConnection(connectionstring);
			try
			{
				sqlConnection.InfoMessage += SqlInfoMessage;
				sqlConnection.Open();
				return sqlConnection;
			}
			catch
			{
				sqlConnection.Dispose();
				throw;
			}
		}

		public static string GetProviderName(string connectionString)
		{
			var csBuilder = new DbConnectionStringBuilder() { ConnectionString = connectionString };
			return !csBuilder.ContainsKey(ProviderNameKey) ? null : csBuilder[ProviderNameKey].ToString();
		}

		private void SqlInfoMessage(object sender, SqlInfoMessageEventArgs e)
		{
			for (int i = 0; i < e.Errors.Count; i++)
			{
				SqlError error = e.Errors[i];
				if (error.Class == 0x00)
				{
					//con.Info(
					//	"Sql Print [{0}] Number: {1}, State: {2}, Class: {3}, Server: [{4}], Procedure: [{5}], LineNumber: {6}, Source: [{7}]",
					//	error.Message, error.Number, error.State, error.Class, error.Server, error.Procedure, error.LineNumber,
					//	error.Source);
				}
				else
				{
					//log.Error(
					//	"Sql Error [{0}] Number: {1}, State: {2}, Class: {3}, Server: [{4}], Procedure: [{5}], LineNumber: {6}, Source: [{7}]",
					//	error.Message, error.Number, error.State, error.Class, error.Server, error.Procedure, error.LineNumber,
					//	error.Source);
				}
			}
		}

	/*	public static DbProviderFactory GetDbProviderFactory(string dbProviderFactoryTypename, string assemblyName)
		{
			var instance = ReflectionUtils.GetStaticProperty(dbProviderFactoryTypename, "Instance");
			if (instance == null)
			{
				var a = ReflectionUtils.LoadAssembly(assemblyName);
				if (a != null)
					instance = ReflectionUtils.GetStaticProperty(dbProviderFactoryTypename, "Instance");
			}

			if (instance == null)
				throw new InvalidOperationException(string.Format(Resources.UnableToRetrieveDbProviderFactoryForm, dbProviderFactoryTypename));

			return instance as DbProviderFactory;
		}*/
	}
}
