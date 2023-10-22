using ApiOntwikkelingProject.Services;

namespace ApiOntwikkelingProject
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICamperData, CamperData>();
            services.AddScoped<IClubData, ClubData>();
            services.AddScoped<ICampingData, CampingData>();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}