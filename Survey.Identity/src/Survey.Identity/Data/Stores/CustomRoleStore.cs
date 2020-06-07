using Microsoft.AspNetCore.Identity;
using Survey.Identity.Domain.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Survey.Identity.Data.Stores
{
    public class CustomRoleStore : IRoleStore<Role>, IQueryableRoleStore<Role>
    {
        private readonly SurveyIdentityContext _context;

        public CustomRoleStore(SurveyIdentityContext context)
            : base()
        {
            _context = context;
        }
        public async Task<IdentityResult> CreateAsync(Role role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role == null) throw new ArgumentNullException(nameof(role));
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            return await Task<IdentityResult>.FromResult(IdentityResult.Success);
        }

        public async Task<IdentityResult> DeleteAsync(Role role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role == null) throw new ArgumentNullException(nameof(role));

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return await Task<IdentityResult>.FromResult(IdentityResult.Success);
        }
        public async Task<IdentityResult> UpdateAsync(Role role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role == null) throw new ArgumentNullException(nameof(role));
            _context.Roles.Attach(role);
            _context.SaveChanges();
            return await Task<IdentityResult>.FromResult(IdentityResult.Success);
        }

        public async Task<Role> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (roleId == null) throw new ArgumentNullException(nameof(roleId));
            Guid idGuid;
            if (!Guid.TryParse(roleId, out idGuid))
            {
                throw new ArgumentException("Not a valid Guid id", nameof(roleId));
            }

            return await _context.Roles
                .Include(a => a.RoleFeatures)
                .FirstOrDefaultAsync(x => x.Id == idGuid);
        }

        public async Task<Role> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (normalizedRoleName == null) throw new ArgumentNullException(nameof(normalizedRoleName));

            return await _context.Roles.FirstOrDefaultAsync(x => x.NormalizedName == normalizedRoleName);
        }

        public Task<string> GetNormalizedRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role == null) throw new ArgumentNullException(nameof(role));

            return Task.FromResult(role.NormalizedName.ToString());
        }

        public Task<string> GetRoleIdAsync(Role role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role == null) throw new ArgumentNullException(nameof(role));

            return Task.FromResult(role.Id.ToString());
        }

        public Task<string> GetRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role == null) throw new ArgumentNullException(nameof(role));

            return Task.FromResult(role.Name);
        }

        public Task SetNormalizedRoleNameAsync(Role role, string normalizedName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role == null) throw new ArgumentNullException(nameof(role));
            if (normalizedName == null) throw new ArgumentNullException(nameof(normalizedName));

            role.NormalizedName = normalizedName;
            return Task.FromResult<object>(null);
        }

        public Task SetRoleNameAsync(Role role, string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role == null) throw new ArgumentNullException(nameof(role));
            if (roleName == null) throw new ArgumentNullException(nameof(roleName));

            role.Name = roleName;
            return Task.FromResult<object>(null);
        }
        public IQueryable<Role> Roles => _context.Roles;
        public void Dispose()
        {

        }
    }
}
