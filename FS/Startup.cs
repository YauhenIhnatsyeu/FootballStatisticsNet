using System;
using System.Collections.Generic;
using System.Linq;
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

namespace FS {
    public class Startup {
        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<UsersContext>(options => options.UseNpgsql(CONNECTION_STRING));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<UsersContext>()
                .AddDefaultTokenProviders();
            services.AddMvc();

            services.Configure<IdentityOptions>(options => {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            });
        }

        private const string CONNECTION_STRING =
            "Server=localhost;Port=5432;Database=football-statistics;User Id=postgres;Password=password;";

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc();

            //var optionsBuilder= new DbContextOptionsBuilder<UsersContext>();
            //optionsBuilder.UseNpgsql(CONNECTION_STRING);

            //using (var dbContext = new UsersContext(optionsBuilder.Options)) {
            //    foreach (var item in dbContext.Users) {
            //        Console.WriteLine($"Name {item.Name}");
            //    }
            //}

            //app.UseDeveloperExceptionPage();
            //if (env.IsDevelopment()) {
            //    app.UseDeveloperExceptionPage();
            //    app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions {
            //        HotModuleReplacement = true
            //    });
            //}
        }
    }
}
