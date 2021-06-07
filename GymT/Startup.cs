using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymT.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GymT
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<GymDbContext>(options =>
            {
                options.UseSqlite("Data Source=gymt.db;");
            });
            
            services.AddSpaStaticFiles(options =>
            {
                options.RootPath = "frontend/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSpaStaticFiles();
            app.UseSpa(options =>
            {
                if (env.IsDevelopment())
                {
                    Console.WriteLine("Test");
                    options.UseProxyToSpaDevelopmentServer("http://localhost:8080");
                }
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
        }
    }
}
