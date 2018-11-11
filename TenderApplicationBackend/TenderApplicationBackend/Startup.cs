using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TenderApplicationBackend.Models;
using TenderApplicationBackend.Models.Modules;
using TenderApplicationBackend.Models.Repositories;

namespace TenderApplicationBackend
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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                    });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<ConnectionFactory>();
            services.AddSingleton<UserModule>();
            services.AddSingleton<UserRepository>();
            services.AddSingleton<EmployeeRepository>();
            services.AddSingleton<TenderModule>();
            services.AddSingleton<TenderRepository>();
            services.AddSingleton<RequirementModule>();
            services.AddSingleton<RequirementRepository>();
            services.AddSingleton<WorkhourModule>();
            services.AddSingleton<WorkhourRepository>();
            services.AddSingleton<GroupModule>();
            services.AddSingleton<GroupRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();
            app.UseCors("AllowAll");
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}