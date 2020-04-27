using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RandomMeCore.Api.Infrastructure.Configurations;
using Swashbuckle.AspNetCore.SwaggerUI;
using RandomMeCore.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using RandomMeCore.Api.Infrastructure.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Rewrite;
using RandomMeCore.Core.Repositories;
using RandomMeCore.Core.Services;

namespace RandomMeCore.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore(options =>
                {
                    options.Filters.Add<HttpGlobalExceptionFilter>();                    
                    options.Filters.Add<ApiKeyAuthorizationFilter>();
                })
                .AddApiExplorer()
                .AddDataAnnotations()
                .SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddHttpContextAccessor();
            
            services.AddDbContextPool<UsersContext>(options => options.UseMySql(_configuration.GetConnectionString("MySqlDb")));

            services.AddTransient<INameRepository, NameCachedRepository>();

            services.AddTransient<IUserService, UserService>();

            services.Configure<ApiKeyConfiguration>(_configuration.GetSection("ApiKey"));
            services.AddSwaggerGen(opt => SwaggerConfigurator.Configure(opt, _configuration.GetValue<string>("ApiKey:SecretKey")));
                        
            services.AddHealthChecks();

            services.AddMemoryCache();
        }

        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                var option = new RewriteOptions();
                option.AddRedirect("^$", "swagger");
                app.UseRewriter(option);
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Simple Api V1");
                c.DocExpansion(DocExpansion.None);
            });
        }
    }
}
