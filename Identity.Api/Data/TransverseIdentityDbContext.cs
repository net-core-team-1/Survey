using Identity.Api.Data.Mapping;
using Identity.Api.Identity.Domain;
using Identity.Api.Identity.Domain.AppServices;
using Identity.Api.Identity.Domain.AppUserRoles;
using Identity.Api.Identity.Domain.Civilities;
using Identity.Api.Identity.Domain.Features;
using Identity.Api.Identity.Domain.Outbox;
using Identity.Api.Identity.Domain.RoleFeature;
using Identity.Api.Identity.Domain.Roles;
using Identity.Api.Identity.Domain.Structures;
using Identity.Api.Identity.Domain.Users;
using Identity.Api.Infrastructure.Events;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Api.Data
{
    public class TransverseIdentityDbContext :
        IdentityDbContext<AppUser, AppRole, Guid, AppUserClaim, AppUserRole,
        AppUserLogin, AppRoleClaim, AppUserToken>
    {
        private readonly IEventMapper _eventMappers;
        public TransverseIdentityDbContext(DbContextOptions<TransverseIdentityDbContext> options
            , IEventMapper eventMappers)
            : base(options)
        {
            _eventMappers = eventMappers;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new AppServiceMapping());
            builder.ApplyConfiguration(new UserMapping());
            builder.ApplyConfiguration(new FeatureMapping());
            builder.ApplyConfiguration(new RoleMapping());
            builder.ApplyConfiguration(new RoleFeaturesMapping());
            builder.ApplyConfiguration(new CivilityMapping());
            builder.ApplyConfiguration(new UserRolesMapping());
            builder.ApplyConfiguration(new UserClaimMapping());
            builder.ApplyConfiguration(new RoleClaimMapping());
            builder.ApplyConfiguration(new UserTokenMapping());
            builder.ApplyConfiguration(new UserLoginMapping());
            builder.ApplyConfiguration(new AppServiceMapping());
            builder.ApplyConfiguration(new StructureMapping());
            builder.ApplyConfiguration(new StructureUsersMapping());
            builder.ApplyConfiguration(new OutboxMapping());

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            foreach (var relationship in builder.Model.GetEntityTypes().Where(e => e.IsOwned()).SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Cascade;
            }
        }

        public DbSet<Civility> Civilities { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<AppRoleFeatures> AppRoleFeatures { get; set; }
        public DbSet<AppService> AppServices { get; set; }
        public DbSet<Structure> Structures { get; set; }
        public DbSet<StructureUsers> StructureUsers { get; set; }
        public DbSet<OutboxMessage> OutboxMessages { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var changedEntries = GetChangedEntries();
            var eventsDetected = GetEvents(changedEntries);
            if (eventsDetected.Count > 0)
                Set<OutboxMessage>().AddRange(eventsDetected);

            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }

        private List<EntityEntry> GetChangedEntries()
        {
            return this.ChangeTracker.Entries()
                                        .Where(entry => entry.State == EntityState.Added
                                                || entry.State == EntityState.Modified
                                                || entry.State == EntityState.Deleted)
                                        .ToList();
        }
        private IReadOnlyCollection<OutboxMessage> GetEvents(IEnumerable<EntityEntry> entities)
        {
            var now = DateTime.UtcNow;
            List<OutboxMessage> messages = new List<OutboxMessage>();
            foreach (var entry in entities)
                if (entry.Entity is IDomainEntity)
                    messages.AddRange(_eventMappers.Map((IDomainEntity)entry.Entity, now).ToList());

            return messages;
        }
    }

}
