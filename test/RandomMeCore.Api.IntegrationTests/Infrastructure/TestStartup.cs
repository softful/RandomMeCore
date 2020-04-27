using RandomMeCore.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RandomMeCore.Core.Repositories;
using RandomMeCore.Core.Services;

namespace RandomMeCore.Api.IntegrationTests.Infrastructure
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration)
            : base(configuration)
        {

        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddDataAnnotations()
                .SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddMemoryCache();
            services.AddTransient<INameRepository, NameCachedRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddDbContext<UsersContext>(options =>
            {
                options.UseInMemoryDatabase("users");
            });
        }

        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var usersContext = app.ApplicationServices.GetService<UsersContext>();
            UsersContextDataFeeder.Feed(usersContext);

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
