using System.Text;
using AutoMapper;
using FS.Core.Clients;
using FS.Core.Interfaces.Clients;
using FS.Core.Interfaces.Repositories;
using FS.Core.Interfaces.Services;
using FS.Core.Models;
using FS.Core.Services;
using FS.DataAccess.Data;
using FS.Infrastructure.Data;
using FS.Web.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace FS.Web
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = configuration["Database:ConnectionString"];
            var secretKey = configuration["Jwt:SecretKey"];

            services.AddDbContext<UsersContext>(options => options.UseNpgsql(
                connectionString,
                npgsqlOptions => npgsqlOptions.MigrationsAssembly("FS.DataAccess")
            ));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<UsersContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication()
                .AddJwtBearer(oprtions =>
                {
                    oprtions.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                    };
                });

            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = StatusCodes.Status308PermanentRedirect;
                options.HttpsPort = 5001;
            });

            services.AddMemoryCache();

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

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

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAutoMapper();
            services.AddHttpContextAccessor();

            services.AddTransient<IJWTService, JWTService>();
            services.AddTransient<ITwitterService, TwitterService>();
            services.AddTransient<ICloudinaryService, CloudinaryService>();
            services.AddTransient<ILeagueTablesService, LeagueTablesService>();
            services.AddTransient<ILeagueTeamsService, LeagueTeamsService>();
            services.AddTransient<ITeamsService, TeamsService>();
            services.AddTransient<IPlayersService, PlayersService>();

            services.AddTransient<IAvatarsRepository, AvatarsRepository>();
            services.AddTransient<IUsersRepository<User>, UsersRepository<User>>();
            services.AddTransient<IFavoriteTeamsRepository, FavoriteTeamsRepository>();
            services.AddTransient<ILeagueTablesRepository, LeagueTablesRepository>();
            services.AddTransient<ILeagueTeamsRepository, LeagueTeamsRepository>();
            services.AddTransient<ITeamsRepository, TeamsRepository>();
            services.AddTransient<IPlayersRepository, PlayersRepository>();
            services.AddTransient<IFanClubsRepository, FanClubsRepository>();
            services.AddTransient<IUsersFanClubsRepository, UsersFanClubsRepository>();

            services.AddTransient<IFootballClient, FootballClient>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMiddleware<HttpsRedirectionMiddleware>();
            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc();

            app.UseSpa(spa => { spa.Options.SourcePath = "wwwroot"; });
        }
    }
}