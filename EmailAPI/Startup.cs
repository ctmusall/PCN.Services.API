using Email.API.Data;
using Email.API.Interfaces;
using Email.API.Models;
using Email.API.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace Email.API
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
            services.AddTransient<ILoggedEmailRepository, LoggedEmailRepository>();
            services.AddDbContext<EmailContext>(option => option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc().AddJsonOptions(option =>
            {
                if (option.SerializerSettings.ContractResolver == null) return;
                if (option.SerializerSettings.ContractResolver is DefaultContractResolver resolver) resolver.NamingStrategy = null;
            }).AddMvcOptions(option =>
            {
                option.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                option.InputFormatters.Add(new XmlDataContractSerializerInputFormatter());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseStatusCodePages();

            app.UseMvc();
        }
    }
}
