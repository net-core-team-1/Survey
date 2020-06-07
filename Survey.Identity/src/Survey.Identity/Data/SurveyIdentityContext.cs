using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Survey.Identity.Domain.Users;
using Survey.Identity.Domain.Roles;
using System;
using Survey.Identity.Data.Mapping;
using Survey.Identity.Domain.Features;
using Survey.Identity.Domain.Identity;
using Survey.Identity.Domain.Entities;
using Survey.Identity.Domain.Services;
using System.Threading.Tasks;
using System.Threading;
using Survey.Identity.Data.OutBox;
using Survey.Identity.Events;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Survey.Identity.Extensions;
using Survey.CQRS.Events;

namespace Survey.Identity.Data
{
    public class SurveyIdentityContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        //  private readonly IEnumerable<IEventMapper> _eventMappers;

        public SurveyIdentityContext(DbContextOptions<SurveyIdentityContext> options

                                     ) : base(options)
        {
            var serviceProvider = this.GetService<IServiceProvider>();
            var scope = serviceProvider.CreateScope();
            //   _eventMappers = scope.ServiceProvider.GetRequiredService<IEnumerable<IEventMapper>>();

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserClaim>().ToTable("USER_CLAIMS", schema: DbSchemaNames.Identity);
            builder.Entity<UserLogin>().ToTable("USER_LOGINS", schema: DbSchemaNames.Identity);
            builder.Entity<RoleClaim>().ToTable("ROLE_CLAIMS", schema: DbSchemaNames.Identity);
            builder.Entity<UserToken>().ToTable("USER_TOKENS", schema: DbSchemaNames.Identity);



            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new FeatureMap());
            builder.ApplyConfiguration(new RoleMap());
            builder.ApplyConfiguration(new UserRoleMap());
            builder.ApplyConfiguration(new RoleFeatureMap());
            builder.ApplyConfiguration(new RefreshTokenMap());

            builder.ApplyConfiguration(new EntityMap());
            builder.ApplyConfiguration(new MicroServiceMap());
            builder.ApplyConfiguration(new OutBoxMap());
        }

        public override int SaveChanges()
        {
            var eventsDetected = GetEvents();
            AddEventsIfAny(eventsDetected);

            var result = base.SaveChanges();


            return result;
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var eventsDetected = GetEvents();
            AddEventsIfAny(eventsDetected);

            var result = base.SaveChangesAsync(cancellationToken);


            return result;
        }

        private IReadOnlyCollection<OutboxMessage> GetEvents()
        {
            var entities = this.ChangeTracker.Entries()
                                             .ToList();

            var now = DateTime.UtcNow;
            List<OutboxMessage> messages = new List<OutboxMessage>();
            foreach (var entry in entities)
            {
                if (entry.Entity is IEventEntity)
                {
                    messages.AddRange(GetMessages((IEventEntity)entry.Entity, now));
                }
            }
            return messages;

        }

        private IEnumerable<OutboxMessage> GetMessages(IEventEntity entity, DateTime now)
        {
            var data = entity.Events.Select(@event => new OutboxMessage(now, @event));
            
            return data;

        }
        private void AddEventsIfAny(IReadOnlyCollection<OutboxMessage> eventsDetected)
        {
            if (eventsDetected.Count > 0)
            {
                Set<OutboxMessage>().AddRange(eventsDetected);
            }
        }
        public virtual DbSet<Feature> Features { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

        public virtual DbSet<Entity> Entities { get; set; }
        //    public virtual DbSet<EntityLevel> EntityLevels { get; set; }

        public virtual DbSet<MicroService> MicroServices { get; set; }
        public DbSet<OutboxMessage> OutboxMessages { get; set; }



    }
}
