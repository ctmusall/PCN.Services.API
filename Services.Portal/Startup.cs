﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Portal.Config;
using Services.Portal.Interfaces;
using Services.Portal.Utilities;
using Services.Portal.Utilities.Email;
using Services.Portal.Utilities.Phone;

namespace Services.Portal
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
            services.AddMvc();
            services.AddTransient<IEmailApplicationUtility, EmailApplicationUtility>();
            services.AddTransient<IEmailLogUtility, EmailLogUtility>();
            services.AddTransient<IEmailTokenUtility, EmailTokenUtility>();
            services.AddTransient<IPhoneLogUtility, PhoneLogUtility>();
            services.AddTransient<IPhoneTokenUtility, PhoneTokenUtility>();
            services.AddTransient<IPhoneApplicationUtility, PhoneApplicationUtility>();
            services.Configure<ApiConfig>(Configuration.GetSection("Api"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
