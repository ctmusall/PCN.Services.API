﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Phone.API.Data;
using Phone.API.Interfaces;
using Phone.API.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace Phone.API
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
            services.AddTransient<IPhoneLogRepository, PhoneLogRepository>();

            services.AddDbContext<PhoneContext>(option => option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc().AddJsonOptions(option =>
            {
                option.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                option.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                if (option.SerializerSettings.ContractResolver == null) return;
                if (option.SerializerSettings.ContractResolver is DefaultContractResolver resolver) resolver.NamingStrategy = null;
            }).AddMvcOptions(option =>
            {
                option.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                option.InputFormatters.Add(new XmlDataContractSerializerInputFormatter());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "PCN.Services.API.Phone", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseStatusCodePages();

            // TODO - Add authentication with JWT tokens

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PCN.Services.API.Phone v1");
            });

            app.UseMvc();
        }
    }
}
