using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Types.Types.ServiceBus;
using Identity.Api.Extensions;
using Identity.Api.Extensions.CommandHandlersRegistration;
using Identity.Api.Extensions.IdentityServiceRegistration;
using Identity.Api.Identity.Domain.Users.Commands;
using Identity.Api.Identity.Domain.Users.Events;
using Identity.Api.Utils.ResultValidator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Survey.Common.CQRS.ServiceBus.RabbitMQ;

namespace Identity.Api
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Custom services injections
            services.AddIdentityServices(Configuration);
            services.AddAutoMapper();
            services.ConfigureServiceBus(Configuration);
            
            services.AddSingleton<IResultValidator, ResultValidation>();
            services.AddSingleton<IResultIdentityValidation, IdentityResultValidator>();
            services.RegisterHandlers();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "api/{controller=users}/{action=Index}/{id?}");
            });

            var subscriberBus = app.ApplicationServices.GetRequiredService<IBusSubscriber>();
            var exchangeInitializer = app.ApplicationServices.GetRequiredService<ExchangeInitializer>();
            exchangeInitializer.Initialize();

            subscriberBus.SubscribeCommand<RegisterUserCommand>();
            subscriberBus.SubscribeEvent<UserRegistered>();
            subscriberBus.SubscribeEvent<UserRegistrationRejected>();
        }
    }
}
