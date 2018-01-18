using System.Net.Mail;
using Email.API.Data;
using Email.API.Email;
using Email.API.Interfaces;
using Email.API.Repositories;
using Email.API.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;

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
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<ILoggedEmailRepository, LoggedEmailRepository>();
            services.AddTransient<IEmailRequestUtility, EmailRequestUtility>();
            services.AddTransient<IEmailMessageUtility, EmailMessageUtility>();
            services.AddTransient<IEmailAttachmentSeeker, EmailAttachmentSeeker>();
            services.AddTransient<MailMessage>();
            services.Configure<EmailConfig>(Configuration.GetSection("Email"));

            services.AddDbContext<EmailContext>(option => option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

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
                c.SwaggerDoc("v1", new Info {Title = "PCN.Services.API.Email", Version = "v1"});
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

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PCN.Services.API.Email v1");
            });
        }
    }
}
