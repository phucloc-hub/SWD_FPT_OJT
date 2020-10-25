using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SWD_DEMO.Models;
using SWD_DEMO.Services;

namespace SWD_DEMO
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
            services.AddControllers();
            services.AddDbContext<SWDContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("SWDContext")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking), ServiceLifetime.Scoped, ServiceLifetime.Scoped);
            services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IUniversityService, UniversityService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IFalcutyService, FalcutyService>();
            services.AddScoped<IUniFalcutyService, UniFalcutyService>();
            services.AddScoped<IMajorService, MajorService>();
            services.AddScoped<IMajorTypeService, MajorTypeService>();
            services.AddScoped<ISemesterService, SemesterService>();
            services.AddScoped<ISemesterStudentService, SemesterStudentService>();
            services.AddScoped<IUniversitySemesterService, UniversitySemesterService>();
            services.AddScoped<IUniversityMajorService, UniversityMajorService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
