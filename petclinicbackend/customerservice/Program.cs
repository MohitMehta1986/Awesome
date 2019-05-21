using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;


namespace petclinicmicroservice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /*public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();*/
        
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) => WebHost.CreateDefaultBuilder(args)
			.ConfigureAppConfiguration((hostingContext, config) =>
			{
				var env = hostingContext.HostingEnvironment;

				if (env.IsDevelopment())
				{
					config.AddJsonFile("/app/appsettings.json", optional: true, reloadOnChange: true)
						.AddEnvironmentVariables();
				}
				else
				{
					config.AddJsonFile("/app/appsettings.json", optional: true, reloadOnChange: true)
						.AddEnvironmentVariables();
				}

				IConfiguration configInProgress = config.Build();

			}).UseStartup<Startup>();
    }
}
