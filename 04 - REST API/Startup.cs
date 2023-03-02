
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRental
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(setup => setup.AddPolicy("Application", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

            services.Configure<ApiBehaviorOptions>(o => o.SuppressModelStateInvalidFilter = true);
            services.AddDbContext<CarRentalCompanyContext>(o => o.UseSqlServer(Configuration.GetConnectionString("localDB")));
            //services.AddControllers();
            //services.AddCors(setup => setup.AddPolicy("EntireWorld", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
            services.AddTransient<BranchesLogic>();
            services.AddTransient<RentalsLogic>();
            services.AddTransient<UsersLogic>();
            services.AddTransient<VehiclesLogic>();
            services.AddTransient<VehicleTypesLogic>();

            JwtHelper jwtHelper = new JwtHelper(Configuration.GetValue<string>("JWT:Key"));
            services.AddSingleton(jwtHelper);

            // Enable JWT Authentication: 
            services.AddAuthentication(options => jwtHelper.SetAuthenticationOptions(options)).AddJwtBearer(options => jwtHelper.SetBearerOptions(options));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseCors("EntireWorld");
            app.UseCors();

            app.UseAuthentication(); 
            app.UseAuthorization();  

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
