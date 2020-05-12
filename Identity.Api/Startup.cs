using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Types.Types.ServiceBus;
using Identity.Api.Extensions;
using Identity.Api.Extensions.CommandHandlersRegistration;
using Identity.Api.Extensions.IdentityServiceRegistration;
using Identity.Api.Data.Repositories.Features;
using Identity.Api.Data.Repositories.Services;
using Identity.Api.Data.Repositories.Structures;
using Identity.Api.Identity.Domain.AppServices.Commands;
using Identity.Api.Identity.Domain.Features;
using Identity.Api.Identity.Domain.Features.Commands;
using Identity.Api.Identity.Domain.Roles.Commands;
using Identity.Api.Identity.Domain.Structure.Commands;
using Identity.Api.Identity.Domain.Users.Commands;
using Identity.Api.Identity.Domain.Users.Events;
using Identity.Api.Services;
using Identity.Api.Utils.ResultValidator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Survey.Common.CQRS.ServiceBus.RabbitMQ;
using Survey.Common.Messages;

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

            var queriesConnectionString = new QueriesConnectionString(Configuration.GetConnectionString("QueriesConnectionString"));
            services.AddSingleton(queriesConnectionString);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
          
            // Custom services injections
            services.AddIdentityServices(Configuration);
            services.AddAutoMapper();
            services.ConfigureServiceBus(Configuration);
            services.AddScoped<Dispatcher>();
            services.AddTransient<IFeatureRepository, FeatureRepository>();
            services.AddTransient<IAppServiceRepository, AppServiceRepository>();
            services.AddTransient<IStructureRepository, StructureRepository>();
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
            
            //app.UseMiddleware<StackifyMiddleware.RequestTracerMiddleware>();
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
            subscriberBus.SubscribeCommand<UnregisterUserCommand>();
            subscriberBus.SubscribeCommand<EditUserCommand>();
            subscriberBus.SubscribeCommand<EditUserRolesCommad>();

            subscriberBus.SubscribeCommand<RegisterFeatureCommand>();
            subscriberBus.SubscribeCommand<UnRegisterFeatureCommand>();
            subscriberBus.SubscribeCommand<DisableFeatureCommand>();
            subscriberBus.SubscribeCommand<EditFeatureCommand>();

            subscriberBus.SubscribeCommand<RegisterRoleCommand>();
            subscriberBus.SubscribeCommand<EditRoleCommand>();
            subscriberBus.SubscribeCommand<DisableRoleCommand>();
            subscriberBus.SubscribeCommand<UnregisterRoleCommand>();

            subscriberBus.SubscribeCommand<RegisterAppServiceCommand>();
            subscriberBus.SubscribeCommand<EditAppServiceCommand>();
            subscriberBus.SubscribeCommand<DisableAppServiceCommand>();
            subscriberBus.SubscribeCommand<DeleteAppServiceCommand>();
            subscriberBus.SubscribeCommand<EditAppServiceFeaturesCommand>();
            subscriberBus.SubscribeCommand<RegisterAppServiceFeatureCommand>();

            subscriberBus.SubscribeCommand<RegisterStructureCommand>();
            subscriberBus.SubscribeCommand<EditStructureCommand>();
            subscriberBus.SubscribeCommand<DisableStructureCommand>();
            subscriberBus.SubscribeCommand<DeleteStructureCommand>();

            //subscriberBus.SubscribeCommand<EditRoleFeaturesCommand>();

            subscriberBus.SubscribeEvent<UserRegistered>();
            subscriberBus.SubscribeEvent<UserUnregistred>();
            subscriberBus.SubscribeEvent<UserEdited>();
            subscriberBus.SubscribeEvent<UserRegistrationRejected>();
        }
    }
}
