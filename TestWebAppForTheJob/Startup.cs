using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestWebAppForTheJob.Data;
using TestWebAppForTheJob.Data.Interfaces;
using TestWebAppForTheJob.Data.Repository;

namespace TestWebAppForTheJob
{
    public class Startup
    {

        private readonly IConfigurationRoot _confString;
        public Startup(IWebHostEnvironment hostEnv)
        {
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContext>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
            services.AddMvc();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddTransient<IAllClients, ClientRepository>();
            services.AddTransient<IClientFounders, FounderRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Clients}/{action=ListClients}/{id?}");
            });

            using var scope = app.ApplicationServices.CreateScope();
            AppDBContext context = scope.ServiceProvider.GetRequiredService<AppDBContext>();
            context.Database.Migrate();
            DBObjects.Initial(context);
        }
    }
}
