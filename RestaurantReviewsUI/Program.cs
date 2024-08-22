using RestaurantReviewsUI.Components;
using RestaurantReviewsUI.Services;

namespace RestaurantReviewsUI
{
    public class Program
	{
        //https://github.com/fullstackhero/blazor-starter-kit
        public static void Main(string[] args)
		{
			const string apiBaseAddress = @"https://localhost:7131";
			var builder = WebApplication.CreateBuilder(args);

			
			// Add services to the container.
			builder.Services.AddRazorComponents()
				.AddInteractiveServerComponents();

			builder.Services.AddSingleton(new HttpClient
			{
				BaseAddress = new Uri(apiBaseAddress)
			});			

            //builder.Services.AddScoped(sp =>
            //{
            //	var client = new HttpClient
            //	{
            //		BaseAddress = new Uri(apiBaseAddress)
            //	};
            //	return client;
            //});

            builder.Services.AddScoped<IRestaurantsListService,RestaurantListService>();
			builder.Services.AddScoped<IUserReviewService,UserReviewService>();
            //builder.Services.AddScoped<ApplicationUserState>();

            var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();				
			}

			app.UseHttpsRedirection();

			app.UseStaticFiles();
			app.UseAntiforgery();

			app.MapRazorComponents<App>()
				.AddInteractiveServerRenderMode();

			app.Run();
		}
	}
}
