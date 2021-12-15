using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.DataAccess;
using IIAuctionHouse.DataAccess.Repositories;
using IIAuctionHouse.Domain.IRepositories;
using IIAuctionHouse.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace IIAuctionHouse
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
            
            Byte[] secretBytes = new byte[40];
            Random rand = new Random();
            rand.NextBytes(secretBytes);
            
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            services.AddDbContext<MainDbContext>(builder => builder.UseLoggerFactory(loggerFactory).UseSqlite("Data Source=DatabaseApp.db"));
            
            services.AddScoped<IAccDetailsRepository, AccDetailsRepository>();
            services.AddScoped<IAccDetailsService, AccDetailsService>();
            
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAddressService, AddressService>();
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddMvc().AddNewtonsoftJson(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            
            services.AddDbContext<MainDbContext>(
                options =>
                {
                    options.UseSqlite("Data Source=main.db");
                });

            services.AddCors(options =>
            {
                options.AddPolicy("Dev-cors", policy =>
                {
                    policy
                        .WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
                options.AddPolicy("Prod-cors", policy =>
                {
                    policy
                        .WithOrigins(
                            "https://dtlegosforlifedt-332510.firebaseapp.com",
                            "https://dtlegosforlifedt.firebaseapp.com",
                            "https://dtlegosforlifedt-332510.web.app")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                } );
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "IIAuctionHouse.WebApi", Version = "v1"});
            });
        } 

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MainDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HoneyShop.WebApi v1"));
                app.UseCors("Dev-cors");
            }
            else
            {
            }

            app.UseHttpsRedirection();
            
            app.UseAuthentication();

            app.UseRouting();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}