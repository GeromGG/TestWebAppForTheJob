using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebAppForTheJob.Data;
using TestWebAppForTheJob.Data.Interfaces;
using TestWebAppForTheJob.Data.Mocks;
using TestWebAppForTheJob.Data.Repository;

namespace TestWebAppForTheJob
{
    public class Startup
    {

        private IConfigurationRoot _confString;
        public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostEnv)
        {
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContext>(obtions => obtions.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
            services.AddMvc();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            //services.AddTransient<IAllClients, MockClient>();
            //services.AddTransient<IClientFounders, MockFounder>();
            services.AddTransient<IAllClients, ClientRepository>();
            services.AddTransient<IClientFounders, FounderRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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


            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContext context = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                DBObjects.Initial(context);
            }

            
        }
    }
}
