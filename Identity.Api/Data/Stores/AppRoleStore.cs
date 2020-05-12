using Identity.Api.Identity.Domain.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Api.Data.Stores
{
    public class AppRoleStore : IRoleStore<AppRole>
    {
        private readonly TransverseIdentityDbContext _context;
        public AppRoleStore(TransverseIdentityDbContext context)
            : base()
        {
            _context = context;
        }
        public async Task<IdentityResult> CreateAsync(AppRole role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role == null) throw new ArgumentNullException(nameof(role));

            _context.Roles.Attach(role);
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
            return await Task<IdentityResult>.FromResult(IdentityResult.Success);
        }

        public async Task<IdentityResult> DeleteAsync(AppRole role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role == null) throw new ArgumentNullException(nameof(role));

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return await Task<IdentityResult>.FromResult(IdentityResult.Success);
        }
        public async Task<IdentityResult> UpdateAsync(AppRole role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role == null) throw new ArgumentNullException(nameof(role));
            _context.Roles.Attach(role);
            
            _context.SaveChanges();
            return await Task<IdentityResult>.FromResult(IdentityResult.Success);
        }

        public async Task<AppRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (roleId == null) throw new ArgumentNullException(nameof(roleId));
            Guid idGuid;
            if (!Guid.TryParse(roleId, out idGuid))
            {
                throw new ArgumentException("Not a valid Guid id", nameof(roleId));
            }

            return await _context.Roles
                //.Include(x => x.RoleAppServiceFeatures)
                .FirstOrDefaultAsync(x => x.Id == idGuid);
        }

        public async Task<AppRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (normalizedRoleName == null) throw new ArgumentNullException(nameof(normalizedRoleName));

            return await _context.Roles.FirstOrDefaultAsync(x => x.NormalizedName == normalizedRoleName);
        }

        public Task<string> GetNormalizedRoleNameAsync(AppRole role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role == null) throw new ArgumentNullException(nameof(role));

            return Task.FromResult(role.NormalizedName.ToString());
        }

        public Task<string> GetRoleIdAsync(AppRole role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role == null) throw new ArgumentNullException(nameof(role));

            return Task.FromResult(role.Id.ToString());
        }

        public Task<string> GetRoleNameAsync(AppRole role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role == null) throw new ArgumentNullException(nameof(role));

            return Task.FromResult(role.Name);
        }

        public Task SetNormalizedRoleNameAsync(AppRole role, string normalizedName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role == null) throw new ArgumentNullException(nameof(role));
            if (normalizedName == null) throw new ArgumentNullException(nameof(normalizedName));

            role.NormalizedName = normalizedName;
            return Task.FromResult<object>(null);
        }

        public Task SetRoleNameAsync(AppRole role, string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role == null) throw new ArgumentNullException(nameof(role));
            if (roleName == null) throw new ArgumentNullException(nameof(roleName));

            role.Name = roleName;
            return Task.FromResult<object>(null);
        }

        public void Dispose()
        {

        }
    }
}
