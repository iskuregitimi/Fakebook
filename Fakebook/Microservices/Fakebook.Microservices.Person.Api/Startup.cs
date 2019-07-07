﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fakebook.Microservices.Person.Api.DataBase;
using Fakebook.Microservices.Person.Api.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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


			services.AddDbContext<FakebookDataContext>(x => x.UseSqlServer(Configuration.GetSection("ConnectionString")["DefaultConnection"]));
			//services.AddMvc().AddSessionStateTempDataProvider();
			services.AddScoped<ActionFilter>();
			services.AddScoped<ResultFilter>();

			//var connection = @"Server=DESKTOP-SKLKMJ1\SQLEXPRESS;Database=Fakebook;Trusted_Connection=True;MultipleActiveResultSets=true;";
			//services.AddDbContext<FakebookDataContext>
			//	(options => options.UseSqlServer(connection));
			
			//services.AddScoped<Iproduct, classgelicek>
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
			//app.UseSession();
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "post API V1");
			});
			app.UseMvc();

		}
    }
}
