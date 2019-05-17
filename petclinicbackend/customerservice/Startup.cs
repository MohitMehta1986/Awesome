using System.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using petclinicmicroservice.Helper;
using petclinicmicroservice.Interfaces;

namespace petclinicmicroservice
{
	public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
	        var appSettings = ConfigurationManager.AppSettings;
		}

	    readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

		public IConfiguration Configuration { get; }
		
		public IConfiguration CloudConfiguration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
	        services.AddCors(options =>
	        {
		        options.AddPolicy(MyAllowSpecificOrigins,
			        builder =>builder.AllowAnyOrigin()
					        .AllowAnyHeader()
					        .AllowAnyMethod()
						.AllowCredentials()
			        );
	        });

	       /* services.AddScoped(db =>
		        new ConnectionFactory().Create(Configuration.GetConnectionString("DefaultConnection")));*/

			switch (Configuration["DataProvider"])
	        {
				case "SQL":
					services.AddScoped(db =>
						new ConnectionFactory().Create(Configuration.GetConnectionString("DefaultConnection")));
					services.AddScoped<IOwnerRepository, OwnerRepository>();
					break;
				case "MySQL":
					services.AddScoped(db =>
						new ConnectionFactory().Create(Configuration.GetConnectionString("DefaultConnectionMySql")));
					services.AddScoped<IOwnerRepository, OwnerRepository>();
					break;
				case "CloudSQL":
					services.AddScoped<IOwnerRepository, OwnerGcpRepository>(
						service => new OwnerGcpRepository(Configuration.GetConnectionString("CloudSqlProjectID")));
					break;

			}
			
	       
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            Console.WriteLine("enviroment Name:{0}", env.EnvironmentName);
		
		 var builder = new ConfigurationBuilder()
		        .SetBasePath(env.ContentRootPath)
				.AddJsonFile("/app/appsettings.json", optional: true)
		        .AddEnvironmentVariables();
	        CloudConfiguration = builder.Build();

		Console.WriteLine("sql proxy connecttion string:{0}",CloudConfiguration["ConnectionStrings:DefaultConnectionMySql"]);
	        Console.WriteLine("DataProvider:{0}", CloudConfiguration["DataProvider"]);
            app.UseHttpsRedirection();
	        app.UseCors("_myAllowSpecificOrigins");
            app.UseMvc();
        }
    }
}
