using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bit285_assignment3_api.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace bit285_assignment3_api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddTransient<PasswordSuggetionService>();
            services.AddDbContext<BitDataContext>(options =>
            {
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BitDatabase;Trusted_Connection=True");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute("Default",
                    "{controller=Admin}/{action=Index}/{id:long?}");
            });

            app.UseFileServer();
        }
    }
}
