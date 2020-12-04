using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RecruitmentApp.Container;
using RecruitmentApp.Repository;

namespace RecruitmentApp
{
    public class Startup
    {
        private readonly IConfiguration conf;
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        

        public Startup(IConfiguration conf )
        {
            this.conf = conf;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContextPool<dbContainer>(op => op.UseSqlServer(conf.GetConnectionString("myConnection")));
            services.AddScoped<IEmployeeLoginDataRepo, EmployeeLoginDataRepo>();
            services.AddScoped<ICandidateRepo, CandidateRepo>();
            services.AddScoped<ICompanyRepo, CompanyRepo>();
            services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            services.AddScoped<ICompanyDepartmentRepo, CompanyDepartmentRepo>();
            services.AddScoped<IJobsRepo, JobsRepo>();
            services.AddScoped<IApplicationRepo, ApplicationRepo>();

            services.AddSession();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSession();

            app.UseStaticFiles();

            app.UseEndpoints(a => a.MapControllerRoute(name: "myAreas", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"));

            app.UseEndpoints(a => a.MapDefaultControllerRoute());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
