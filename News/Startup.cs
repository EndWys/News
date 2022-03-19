using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using News.Domain;
using News.Domain.Repositories.EntityFramewordk;
using News.Domain.Repositories.Interfaces;
using News.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News
{
    public class Startup
    {

        private IConfigurationRoot configString;
        public Startup(IWebHostEnvironment hostingEnvironment) 
        {
            configString = new ConfigurationBuilder().SetBasePath(hostingEnvironment.ContentRootPath).AddJsonFile("dbconnectionsettings.json").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0)
                .AddSessionStateTempDataProvider();
             services.AddDbContext<AppDBContext>(options => options.UseSqlServer(configString.GetConnectionString("DefaultConnection")));
            services.AddTransient<IPostItems, EFPostRepository>();
            services.AddTransient<IPostCategories, EFPostCategoryRepository>();
            services.AddMvc(); 
        }

       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
