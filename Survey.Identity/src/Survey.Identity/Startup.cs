﻿
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Survey.Messaging;
using Survey.CQRS.Commands;
using Survey.Idendity.Extensions;
using Survey.Identity.Domain.Authentication.Commands;
using Survey.Identity.Domain.Features;
using Survey.Identity.Domain.Features.Commands;
using Survey.Identity.Domain.Users.Commands;
using Survey.Identity.Extensions;
using Survey.Identity.Handlers.Authentication;
using Survey.Identity.Handlers.Features;
using Survey.Identity.Handlers.Roles;
using Survey.Identity.Handlers.Users;
using Survey.Identity.Infrastracture.Data.Repositories;
using Survey.Identity.Services.Authentication;
using Survey.Identity.Services.Features;
using Survey.Identity.Services.Roles;
using Survey.Identity.Services.Users;
using Survey.Indentity.Domain.Roles.Commands;
using Survey.Auth;
using Survey.Identity.Domain.Entities;
using Survey.Identity.Services.Entities;
using Survey.Identity.Domain.Entities.Levels.Commands;
using Survey.Identity.Handlers.EntityLevels;
using Survey.Identity.Handlers.Entities;
using Survey.Identity.Domain.Entities.Commands;
using Survey.Identity.Domain.Services;
using Survey.Identity.Data.Repositories;
using Microsoft.Extensions.Hosting;

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
            services.AddEvents();

            services.AddSurveyIdentityDbContext(Configuration)
                    .AddSurveyIdentity()
                    .AddAutoMapper()
                    .AddIdentityOptions()
                    .AddAuth(Configuration)
                    .AddAuthFilters()
                    .AddFluentValidation()
                    .AddHttpContextHelper()
                    .AddAuthentication()
                   ;



            services.AddScoped<IFeatureRepository, FeatureRepository>();
            //services.AddScoped<IEntityLevelRepository, EntityLevelRepository>();
            services.AddScoped<IEntityRepository, EntityRepository>();
            services.AddScoped<IMicroServiceRepository, MicroServiceRepository>();


            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IFeatureService, FeatureService>();

            //services.AddScoped<IEntityLevelService, EntityLevelService>();
            //services.AddScoped<IEntityService, EntityService>();

            //user commands
            services.AddScoped<ICommandHandler<RegisterUserCommand>, RegisterUserHandler>();
            services.AddScoped<ICommandHandler<EditUserInfoCommand>, EditUserInfoHandler>();
            services.AddScoped<ICommandHandler<ChangeEmailCommand>, ChangeEmailHandler>();

            //authentication commands
            services.AddScoped<ICommandHandler<SignInCommand>, SignInHandler>();
            services.AddScoped<ICommandHandler<SignOutCommand>, LogOutHandler>();
            services.AddScoped<ICommandHandler<ChangePasswordCommand>, ChangePasswordHandler>();

            //role commands
            services.AddScoped<ICommandHandler<CreateRoleCommand>, CreateRoleHandler>();
            services.AddScoped<ICommandHandler<DeactivateRoleCommand>, DeactivateRoleHandler>();
            services.AddScoped<ICommandHandler<EditRoleCommand>, EditRoleHandler>();
            services.AddScoped<ICommandHandler<RemoveRoleCommand>, RemoveRoleHandler>();
            services.AddScoped<ICommandHandler<UpdateRoleFeaturesCommand>, UpdateFeaturesHandler>();
            services.AddScoped<ICommandHandler<ActivateRoleCommand>, ActivateRoleHandler>();


            //Features
            services.AddScoped<ICommandHandler<CreateFeatureCommand>, CreateFeatureHandler>();
            services.AddScoped<ICommandHandler<DeactivateFeatureCommand>, DeactivateFeatureHandler>();
            services.AddScoped<ICommandHandler<EditFeatureCommand>, EditFeatureHandler>();
            services.AddScoped<ICommandHandler<RemoveFeatureCommand>, RemoveFeatureHandler>();
            services.AddScoped<ICommandHandler<ActivateFeatureCommand>, ActivateFeatureHandler>();

            //Entity levels
            //services.AddScoped<ICommandHandler<AddEntityLevelCommand>, AddEntityLevelHandler>();
            //services.AddScoped<ICommandHandler<EditInfoEntityLevelCommand>, EditInfoEntityLevelHandler>();
            //services.AddScoped<ICommandHandler<DeleteEntityLevelCommand>, DeleteEntityLevelHandler>();

            //Entity 
            services.AddScoped<ICommandHandler<CreateEntityCommand>, CreateEntityHandler>();
            services.AddScoped<ICommandHandler<EditInfoEntityCommand>, EditInfoEntityHandler>();
            services.AddScoped<ICommandHandler<DeleteEntityCommand>, DeleteEntityHandler>();


            services.AddScoped<DispatcherAsync>();
            services.AddScoped<Dispatcher>();
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            //var subscriberBus = app.ApplicationServices.GetRequiredService<IBusSubscriber>();
            //var exchangeInitializer = app.ApplicationServices.GetRequiredService<ExchangeInitializer>();
            //exchangeInitializer.Initialize();

            //subscriberBus.SubscribeCommand<RegisterUserCommand>();
            app.UseRouting();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });

        }
    }
}
