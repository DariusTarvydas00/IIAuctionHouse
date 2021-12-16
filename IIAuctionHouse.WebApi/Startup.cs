using System;
using System.Text;
using IIAuctionHouse.Core.Domain.IRepositories;
using IIAuctionHouse.Core.Domain.Services;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.DataAccess;
using IIAuctionHouse.DataAccess.Repositories;
using IIAuctionHouse.Security;
using IIAuctionHouse.Security.IRepositories;
using IIAuctionHouse.Security.IServices;
using IIAuctionHouse.Security.Repositories;
using IIAuctionHouse.Security.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

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

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo {Title = "AuctionHouse.WebApi", Version = "v1"});
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description =
                        "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });

            services.AddAuthentication(authenticationOptions =>
            {
                authenticationOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authenticationOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(Configuration["Jwt:Secret"])),
                    ValidateIssuer = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = Configuration["Jwt:Audience"],
                    ValidateLifetime = true
                };
            });
            var value = Configuration["JwtConfig:secret"];

            services.AddControllers();

            var loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

            services.AddDbContext<AuctionHouseDbContext>(builder =>
                {
                    builder.UseLoggerFactory(loggerFactory)
                        .UseSqlite("Data Source=AuctionHouseDbContext.db");
                }, ServiceLifetime.Transient
            );

            services.AddDbContext<AuthDbContext>(builder =>
                {
                    builder.UseLoggerFactory(loggerFactory)
                        .UseSqlite("Data Source=AuthDbContext.db");
                }, ServiceLifetime.Transient
            );

            services.AddScoped<ICustomerDetailsRepository, CustomerDetailsRepository>();
            services.AddScoped<ICustomerDetailsService, CustomerDetailsService>();
            services.AddScoped<IBidRepository, BidRepository>();
            services.AddScoped<IBidService, BidService>();
            services.AddScoped<IProprietaryRepository, ProprietaryRepository>();
            services.AddScoped<IProprietaryService, ProprietaryService>();
            services.AddScoped<IAuctionHouseDbSeeder, AuctionHouseDbSeeder>();

            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<IAuthUserRepository, AuthUserRepository>();
            services.AddScoped<IAuthUserService, AuthUserService>();
            services.AddScoped<IAuthDbSeeder, AuthDbSeeder>();

            services.AddCors(options =>
            {
                options.AddPolicy("Dev-cors", policy =>
                {
                    policy
                        .WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            
        //
        // services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        //     services.AddMvc().AddNewtonsoftJson(options => {
        //         options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        //     });
        //     
        //     services.AddDbContext<AuctionHouseDbContext>(
        //         options =>
        //         {
        //             options.UseSqlite("Data Source=main.db");
        //         });
        //     
        //         options.AddPolicy("Prod-cors", policy =>
        //         {
        //             policy
        //                 .WithOrigins(
        //                     "https://dtlegosforlifedt-332510.firebaseapp.com",
        //                     "https://dtlegosforlifedt.firebaseapp.com",
        //                     "https://dtlegosforlifedt-332510.web.app")
        //                 .AllowAnyHeader()
        //                 .AllowAnyMethod();
        //         } );
        //     });
        } 

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IAuctionHouseDbSeeder auctionHouseDbSeeder, IAuthDbSeeder authDbSeeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AuctionHouse.WebApi v1"));
                app.UseCors("Dev-cors");
                auctionHouseDbSeeder.SeedDevelopment();
                authDbSeeder.SeedDevelopment();
            }
            else
            {
                auctionHouseDbSeeder.SeedProduction();
                authDbSeeder.SeedProduction();
            }

            app.UseHttpsRedirection();
            
            app.UseAuthentication();

            app.UseRouting();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}