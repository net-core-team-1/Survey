using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Survey.Messaging;
using Survey.CQRS.Commands;
using Survey.Transverse.API._Configuration;
using Survey.Transverse.Contract.Users.Responses;
using Survey.Transverse.Domain.Users.Commands;
using Survey.Transverse.Domain.Users.Queries;
using System.Collections.Generic;
using Survey.Transverse.Domain.Users.Authentication.Commands;
using Survey.Transverse.Domain.Permissions.Commands;
using Survey.Transverse.Domain.Features.Commands;
using Survey.Transverse.Domain.Features.Queries;
using Survey.Transverse.Contract.Features.Responses;
using Survey.Transverse.Contract.Permissions.Responses;
using Survey.Transverse.Domain.Users;
using Survey.Transverse.Infrastracture.Data.Repositories;
using Survey.Transverse.Domain.Features;
using Survey.Auth;
using Survey.Transverse.Service.Users;
using Survey.CQRS.ServiceBus;
using Survey.Transverse.Service.Users.Commands;
using Survey.Transverse.Service.Users.Queries;
using Survey.Transverse.Service.Authentication.Commands;
using Survey.Transverse.Service.Permissions.Commands;
using Survey.Transverse.Service.Features.Commands;
using Survey.Transverse.Service.Features.Queries;
using Survey.CQRS.ServiceBus.RabbitMQ;

namespace Survey.Identity.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper()
                    .AddCorsConfig()
                    .AddConnectionProvider(Configuration)
                    .AddFluentValidation()
                    .AddAuth(Configuration)
                    .AddAuthFilters()
                    .AddHttpContextHelper()
                    .ConfigureServiceBus(Configuration)
                    ;




            var queriesConnectionString = new QueriesConnectionString(Configuration.GetConnectionString("QueriesConnectionString"));
            services.AddSingleton(queriesConnectionString);

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IFeatureRepository, FeatureRepository>();
            services.AddTransient<IPermissionRepository, PermissionRepository>();

            //users 
            services.AddTransient<ICommandHandler<EditUserCommand>, EditUserCommandHandler>();
            services.AddTransient<ICommandHandler<RegisterUserCommand>, RegisterUserCommandHandler>();
            services.AddTransient<IQueryHandler<GetListUsersQuery, List<UserListResponse>>, GetAllUsersQueryHandler>();
            services.AddTransient<IQueryHandler<GetUserByIdQuery, UserResponse>, GetUserByIdQueryHandler>();

            //Identity 
            services.AddTransient<ICommandHandler<SignOutCommand>, SignOutCommandHandler>();
            services.AddTransient<ICommandHandler<SignInCommand>, SignInCommandHandler>();
            services.AddTransient<ICommandHandler<ChangePasswordCommand>, ChangePasswordCommandHandler>();
            services.AddTransient<ICommandHandler<UnregisterUserCommand>, UnregisterCommandHandler>();

            //Permissions
            services.AddTransient<ICommandHandler<CreatePermissionCommand>, CreatePermissionCommandHandler>();
            services.AddTransient<ICommandHandler<DeactivatePermissionCommand>, DeactivatePermissionCommandHandler>();
            services.AddTransient<ICommandHandler<EditPermissionCommand>, EditPermissionCommandHandler>();
            services.AddTransient<ICommandHandler<RemovePermissionCommand>, RemovePermissionCommandHandler>();
            services.AddTransient<IQueryHandler<GetListPermissionQuery, List<PermissionListResponse>>, GetListPermissionQueryHandler>();


            //Permissions
            services.AddTransient<ICommandHandler<CreateFeatureCommand>, CreateFeatureCommandHandler>();
            services.AddTransient<ICommandHandler<DeactivateFeatureCommand>, DeactivateFeatureCommandHandler>();
            services.AddTransient<ICommandHandler<EditFeatureCommand>, EditFeatureCommandHandler>();
            services.AddTransient<ICommandHandler<RemoveFeatureCommand>, RemoveFeatureCommandHandler>();

            services.AddTransient<IQueryHandler<GetListFeaturesQuery, List<FeatureListResponse>>, GetListFeaturesQueryHandler>();
            services.AddTransient<IQueryHandler<GetFeatureByIdQuery, FeatureResponse>, GetFeatureByIdQueryHandler>();

            services.AddScoped<Dispatcher>();



            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            var subscriberBus = app.ApplicationServices.GetRequiredService<IBusSubscriber>();
            var exchangeInitializer = app.ApplicationServices.GetRequiredService<ExchangeInitializer>();
            exchangeInitializer.Initialize();

            subscriberBus.SubscribeCommand<RegisterUserCommand>();
            subscriberBus.SubscribeCommand<UnregisterUserCommand>();
            subscriberBus.SubscribeCommand<EditUserCommand>();
            subscriberBus.SubscribeCommand<CreatePermissionCommand>();
            subscriberBus.SubscribeCommand<DeactivatePermissionCommand>();
            subscriberBus.SubscribeCommand<EditPermissionCommand>();
            subscriberBus.SubscribeCommand<RemovePermissionCommand>();
            subscriberBus.SubscribeCommand<CreateFeatureCommand>();
            subscriberBus.SubscribeCommand<DeactivateFeatureCommand>();
            subscriberBus.SubscribeCommand<EditFeatureCommand>();
            subscriberBus.SubscribeCommand<RemoveFeatureCommand>();

        }
    }
}
