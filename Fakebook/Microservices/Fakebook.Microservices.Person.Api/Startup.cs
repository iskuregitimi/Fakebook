using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fakebook.Microservices.Person.Api.Database;
using Fakebook.Microservices.Person.Api.Helpers;
using Fakebook.Microservices.Person.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace Fakebook.Microservices.Person.Api
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "TestAPI", Version = "V1" });
            });
            services.AddCors();

            string connection = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<FakebookContext>
                (options => options.UseSqlServer(connection));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSetting>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSetting>();

            var key = Encoding.ASCII.GetBytes(appSettings.Secret); services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(x =>
             {
                 x.Events = new JwtBearerEvents()
                 {
                     OnTokenValidated = (context) =>
                     {
                         var login = context.HttpContext.RequestServices.GetRequiredService<ILogin>();
                         var name = context.Principal.Identity.Name; if (string.IsNullOrEmpty(name))
                         {
                             context.Fail("Unauthorized. Please re-login");
                         }
                         return Task.CompletedTask;
                     }
                 };
                 x.RequireHttpsMetadata = false;
                 x.SaveToken = true;
                 x.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(key),
                     ValidateIssuer = false,
                     ValidateAudience = false
                 };
             });

            // configure DI for application services
            services.AddScoped<ILogin, Login>();
   

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
            app.UseAuthentication();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "post API V1");
            });

            app.UseMvc();
        }
    }
}
