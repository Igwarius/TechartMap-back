using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TechartMap_back.DAL.Context;
using TechartMap_back.DAL.Repository.Classes;
using TechartMap_back.DAL.Repository.Interfaces;
using TechartMap_back.Services.Interfaces;
using TechartMap_back.Services.Services;

namespace TechartMap_back
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<ICinemaService, CinemaService>();
            services.AddTransient<ICinemaRepository, CinemaRepository>();
            services.AddTransient<IFilmService, FilmService>();
            services.AddTransient<IFilmRepository, FilmRepository>();
            services.AddTransient<IHallService, HallService>();
            services.AddTransient<IHallRepository, HallRepository>();
            services.AddTransient<ISessionService, SessionService>();
            services.AddTransient<ISessionRepository, SessionRepository>();
            services.AddTransient<ITransactionService, TransactionService>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddTransient<IRefreshTokenService, RefreshTokenService>();
            services.AddControllers();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddCors();
            services.AddEntityFrameworkNpgsql().AddDbContext<Context>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("Context")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(opts => opts
                .WithOrigins(
                    "http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
            );
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}