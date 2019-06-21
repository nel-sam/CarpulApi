using CarpoolApi.Api;
using CarpoolApi.Api.Authentication;
using CarpoolApi.Api.Logger;
using CarpoolApi.Common.Logger;
using CarpoolApi.Domain.Repositories;
using CarpoolApi.Infastructure;
using CarpoolApi.Infrastructure.SQLRepositories;
using CarpoolApi.Service.Services;
using CarpoolApi.Services;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using OpenTracing.Util;
using Petabridge.Tracing.ApplicationInsights;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarpoolApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        private IConfiguration configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(config =>
            {
                config.Filters.Add(typeof(CustomTracingFilter));
                config.Filters.Add(typeof(CustomExceptionHandler));
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            ConfigureDependencyInjection(services);
            ConfigureAuthentication(services);
            ConfigureLogging(services);
            ConfigureSwagger(services);

            services.AddMvc().AddJsonOptions(options =>
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());
        }

        private static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Carpül API", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Name = "authorization",
                    In = "header",
                    Type = "apiKey",
                });

                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer", Enumerable.Empty<string>() }
                });
            });
        }

        private void ConfigureLogging(IServiceCollection services)
        {
            if (!GlobalTracer.IsRegistered())
            {
                var key = configuration.GetSection("ApplicationInsights").GetSection("InstrumentationKey").Value;
                var config = new TelemetryConfiguration { InstrumentationKey = key };
                var tracer = new ApplicationInsightsTracer(config);
                GlobalTracer.Register(tracer);

                // The tracer itself is a single instance during the durantion of the whole request.
                // Specifying the type here is option since it could decipher it, but adding it for explicity
                services.AddSingleton<OpenTracing.ITracer>(tracer);

                // Scoped services are created per client request
                services.AddScoped<ICustomLogger, CustomLogger>();
            }
        }

        private static void ConfigureDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<IAuthenticateService, TokenAuthenticationService>();
            services.AddScoped<IUserManagementService, UserManagementService>();
            services.AddScoped<ICarpoolDetails, CarpoolDetails>();
            services.AddScoped<IAddressDetails, AddressDetails>();
            services.AddScoped<ICarpoolService, CarpoolService>();
            services.AddScoped<ICampusDetails, CampusDetails>();
            services.AddScoped<IUserDetails, UserDetails>();
            services.AddScoped<IUserService, UserService>();
            services.AddDbContext<DatabaseContext>();           
        }

        private void ConfigureAuthentication(IServiceCollection services)
        {
            services.Configure<TokenManagement>(configuration.GetSection("TokenManagement"));
            var tokenManagement = configuration.GetSection("TokenManagement").Get<TokenManagement>();

            services.AddAuthentication(x =>
            {
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.SaveToken = true;
                x.RequireHttpsMetadata = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = tokenManagement.Issuer,
                    ValidAudience = tokenManagement.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenManagement.Secret)),
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Carpül API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}