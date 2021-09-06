using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlvaroFacturacionApi.Domain.IRepositories;
using AlvaroFacturacionApi.Domain.IServices;
//using AlvaroFacturacionApi.Domain.IRepositories;
//using AlvaroFacturacionApi.Domain.IServices;
using AlvaroFacturacionApi.Persistence.Context;
using AlvaroFacturacionApi.Persistence.Repositories;
using AlvaroFacturacionApi.Services;
//using AlvaroFacturacionApi.Persistence.Repositories;
//using AlvaroFacturacionApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AlvaroFacturacionApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AplicationDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("Conexion")));

            // Service
            services.AddScoped<IProductService, ProductService>();

            // Repository
            services.AddScoped<IProductRepository, ProductRepository>();


            //cors
            services.AddCors(options => options.AddPolicy("AllowWepApp",
                                        builder => builder.AllowAnyOrigin()
                                        .AllowAnyHeader()
                                        .AllowAnyMethod()));

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowWepApp");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
