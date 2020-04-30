using Common.Types.Types.ServiceBus;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Survey.Common.CQRS.ServiceBus.RabbitMQ;
using Survey.Common.Messages;
using Survey.Common.Types;
using Survey.Identity.Data;
using Survey.Identity.Domain.Roles;
using Survey.Identity.Domain.Users;
using Survey.Identity.Domain.Users.Commands;
using Survey.Identity.Extensions;
using Survey.Identity.Handlers.Handlers;
using Survey.Identity.Services.Users;
using System;

namespace Survey.Identity
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
            services.AddSurveyIdentityDbContext(Configuration)
                    .AddSurveyIdentity()
                    .AddAutoMapper()
                    .AddIdentityOptions();
            // .ConfigureServiceBus(Configuration);

           

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICommandHandler<RegisterUserCommand>, RegisterUserHandler>();
            services.AddScoped<ICommandHandler<EditUserInfoCommand>, EditUserInfoHandler>();
            services.AddScoped<ICommandHandler<ChangeEmailCommand>, ChangeEmailHandler>();

            services.AddScoped<AsyncDispatcher>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //var subscriberBus = app.ApplicationServices.GetRequiredService<IBusSubscriber>();
            //var exchangeInitializer = app.ApplicationServices.GetRequiredService<ExchangeInitializer>();
            //exchangeInitializer.Initialize();

            //subscriberBus.SubscribeCommand<RegisterUserCommand>();

            app.UseMvc();
        }
    }
}
