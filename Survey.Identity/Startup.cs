
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Survey.Common.Auth;
using Survey.Common.Messages;
using Survey.Common.Types;
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
                    .AddIdentityOptions()
                    .AddAuth(Configuration)
                    .AddAuthFilters()
                    .AddFluentValidation()
                    .AddHttpContextHelper()
                    .AddAuthentication()
                   ;



            services.AddScoped<IFeatureRepository, FeatureRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IFeatureService, FeatureService>();

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

            //Features
            services.AddScoped<ICommandHandler<CreateFeatureCommand>, CreateFeatureHandler>();
            services.AddScoped<ICommandHandler<DeactivateFeatureCommand>, DeactivateFeatureHandler>();
            services.AddScoped<ICommandHandler<EditFeatureCommand>, EditFeatureHandler>();
            services.AddScoped<ICommandHandler<RemoveFeatureCommand>, RemoveFeatureHandler>();


           



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
            app.UseAuthentication();
            //var subscriberBus = app.ApplicationServices.GetRequiredService<IBusSubscriber>();
            //var exchangeInitializer = app.ApplicationServices.GetRequiredService<ExchangeInitializer>();
            //exchangeInitializer.Initialize();

            //subscriberBus.SubscribeCommand<RegisterUserCommand>();

            app.UseMvc();
        }
    }
}
