using Microsoft.AspNetCore.Authentication.Cookies;
using RestaurantReviews2024.App.Services;

namespace RestaurantReviews2024.Server
{
    public class Startup
    {
        #region CTOR
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        #region Properties
        public IConfiguration Configuration { get; }
        #endregion

        #region Public Methods
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor()
                .AddInteractiveServerComponents();

            services.AddCascadingAuthenticationState();

            services.AddHttpClient<IRestaurantsListService, RestaurantListService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7131/");
            });

            services.AddHttpClient<IUserReviewService, UserReviewService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7131/");
            });

            services.AddHttpClient<IRegisteredUsersAdminService, RegisteredUsersAdminService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44345/");
            });

            // TokenProvider is a service defined in the App (RestaurantReviewsUI)
            services.AddScoped<TokenProvider>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();  
            
            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });


        }

        #endregion
    }
}
