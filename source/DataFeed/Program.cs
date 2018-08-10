using System;

namespace DataFeed
{
    class Program
    {
        static void Main(string[] args)
        {
             var hostname = "172.17.0.6,1433";
            var password = "MyStrongPassword1234";
            var connString = $"Data Source={hostname};Initial Catalog=master;User ID=sa;Password={password};";
            Console.WriteLine("connection string {0}", connString);
        }
    }
}
