using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Security.Principal;
using System.Threading.Tasks;



namespace RestaurantReviews2024
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var config = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")
				.Build();

			Log.Logger = new LoggerConfiguration()
				.ReadFrom.Configuration(config)
				.WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
				.CreateLogger();

			var host = CreateHostBuilder(args).Build();

			using (var scope = host.Services.CreateScope())
			{			

				try
				{
					var services = scope.ServiceProvider;
					var loggerFactory = services.GetRequiredService<ILoggerFactory>();
					Log.Information("Application Starting");
				}
				catch (Exception ex)
				{
					Log.Warning(ex, "An error occured while starting the application");
				}
			}

			host.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
		  Host.CreateDefaultBuilder(args)
		   .UseSerilog()
			  .ConfigureWebHostDefaults(webBuilder =>
			  {
				  webBuilder.UseStartup<Startup>();
			  });
	}
}
