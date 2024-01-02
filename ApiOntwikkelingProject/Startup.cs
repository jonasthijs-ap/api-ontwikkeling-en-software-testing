using ApiOntwikkelingProject.DbContexts;
using ApiOntwikkelingProject.Services;
using Microsoft.EntityFrameworkCore;

namespace ApiOntwikkelingProject
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICamperData, CamperDataEF>();
            services.AddScoped<IClubData, ClubDataEF>();
            services.AddScoped<ICampingData, CampingDataEF>();
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddDbContext<ApiDbContext>(context =>
            {
                string connection = "server = localhost; database = ApiOntwikkeling-project; user = root; password = password";
                context.UseMySql(connection, ServerVersion.AutoDetect(connection));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(swagger =>
            {
                swagger.SwaggerEndpoint("./swagger/v1/swagger.json", "API Ontwikkeling Project");
                swagger.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}