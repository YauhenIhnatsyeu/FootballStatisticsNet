using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FS.Models;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using FS.Helpers;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.IdentityModel.Tokens;

namespace FS
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            ConfigurationContainer.Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var configuration = ConfigurationContainer.Configuration;
            var connectionString = configuration["Database:ConnectionString"];
            var secretKey = configuration["Jwt:SecretKey"];

            services.AddDbContext<UsersContext>(options => options.UseNpgsql(connectionString));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<UsersContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication()
                .AddJwtBearer(oprtions =>
                {
                    oprtions.TokenValidationParameters = new TokenValidationParameters {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                    };
                });

            services.AddMvc();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            });

            services.Configure<FormOptions>(options =>
            {
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = long.MaxValue;
            });

            services.AddAutoMapper();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}