using Deneme1.Data;
using Deneme1.Data.IRepositories;
using Deneme1.Data.IUnitOfWorks;
using Deneme1.Data.Repositories;
using Deneme1.Data.UnitOfWork;
using Deneme1.Service.IService;
using Deneme1.Service.IServices;
using Deneme1.Service.Mapping;
using Deneme1.Service.Services;
using Deneme1.Services.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deneme1.API
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

            services.AddAutoMapper(typeof(MapProfile));
            
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IPersonelService, PersonelService>();


            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Employee",
                    Version = "v1",
                    Description = "TuAF-Bogey"
                });
            });


            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = (doc =>
                {
                    doc.Info.Title = "Saim API";
                    doc.Info.Version = "1.0";
                    doc.Info.Contact = new NSwag.OpenApiContact()
                    {
                        Name = "Hayrullah Uður Güvenen",
                        Url = "https://www.linkedin.com/in/guvenenugur/",
                        Email = "uguvenen@gmail.com"
                    };
                });
            });


            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("Default").ToString(), o =>
                {
                    o.MigrationsAssembly("Deneme1.Data");
                });
            });

            services.AddRouting();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddControllers();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseOpenApi();

            app.UseSwaggerUi3();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
