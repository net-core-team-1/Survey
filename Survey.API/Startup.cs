﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Types.Types.Events;
using Common.Types.Types.ServiceBus;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Survey.Api.Domain.Repositories;
using Survey.Api.Events;
using Survey.Api.Handlers;
using Survey.Api.Repositories;
using Survey.Api.Services;
using Survey.Api.Utility;
using Survey.Common.Auth;
using Survey.Common.CQRS.ServiceBus.RabbitMQ;
using Survey.Common.MongoDb;

namespace Survey.Api
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


            services.ConfigureServiceBus(Configuration)
                    .AddAutoMapper()
                    .AddAuth(Configuration)
                    .AddMongo(Configuration);

            services.AddScoped<IEventHandler<UserRegistered>, UserRegisteredHandler>();

            services.AddTransient<IUserDtoRepository, UserDtoRepository>();
            services.AddTransient<IUserDtoService, UserDtoService>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var subscriberBus = app.ApplicationServices.GetRequiredService<IBusSubscriber>();
            var exchangeInitializer = app.ApplicationServices.GetRequiredService<ExchangeInitializer>();
            exchangeInitializer.Initialize();

            subscriberBus.SubscribeEvent<UserRegistered>();

            app.UseMvc();
        }
    }
}
