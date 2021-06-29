using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymT.Common;
using GymT.Data;
using GymT.Logic;
using GymT.Middleware;
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

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                services.AddDbContext<IGymTDbContext, GymTDbContext>(options => { options.UseSqlite("Data Source=gymt.db;"); });
            }
            else
            {
                throw new Exception("Currently GymT only runs in development mode");
            }

            services.AddTransient<AccountService>();

            services.AddSpaStaticFiles(options =>
            {
                options.RootPath = "frontend/dist";
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseCors(cors =>
            {
                cors.AllowAnyOrigin();
                cors.AllowAnyHeader();
                cors.AllowAnyMethod();
            });

            app.UseMiddleware<AuthenticationMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
