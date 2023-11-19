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
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(swagger =>
                {
                    swagger.SwaggerEndpoint("./swagger/v1/swagger.json", "API Ontwikkeling Project");
                    swagger.RoutePrefix = string.Empty;
                });
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}