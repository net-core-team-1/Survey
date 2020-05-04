using Identity.Api.Identity.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Data.Stores
{
    public class AppUserStore : IUserStore<AppUser>
    {
        private readonly TransverseIdentityDbContext _context;

        public AppUserStore(TransverseIdentityDbContext context)
            :base()
        {
            _context = context;
            
        }

        public async Task<IdentityResult> CreateAsync(AppUser user,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));

            _context.Attach(user);
            await _context.Users.AddAsync(user);
            return await Task<IdentityResult>.FromResult(IdentityResult.Success);
        }

        public async Task<IdentityResult> DeleteAsync(AppUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));

            _context.Users.Remove(user);
            return await Task<IdentityResult>.FromResult(IdentityResult.Success);
        }

        public void Dispose()
        {
           
        }

        public async Task<AppUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (userId == null) throw new ArgumentNullException(nameof(userId));
            Guid idGuid;
            if (!Guid.TryParse(userId, out idGuid))
            {
                throw new ArgumentException("Not a valid Guid id", nameof(userId));
            }

            return await _context.Users.Include(x => x.UserRoles).FirstOrDefaultAsync(x => x.Id == idGuid);
        }

        public async Task<AppUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (normalizedUserName == null) throw new ArgumentNullException(nameof(normalizedUserName));

            return await _context.Users.FirstOrDefaultAsync(x => x.NormalizedUserName == normalizedUserName);
        }

        public Task<string> GetNormalizedUserNameAsync(AppUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));

            return Task.FromResult(user.NormalizedUserName.ToString());
        }

        public Task<string> GetUserIdAsync(AppUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));

            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(AppUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));

            return Task.FromResult(user.UserName);
        }

        public Task SetNormalizedUserNameAsync(AppUser user, string normalizedName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (normalizedName == null) throw new ArgumentNullException(nameof(normalizedName));

            user.NormalizedUserName = normalizedName;
            return Task.FromResult<object>(null);
        }

        public Task SetUserNameAsync(AppUser user, string userName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (userName == null) throw new ArgumentNullException(nameof(userName));

            user.UserName = userName;
            return Task.FromResult<object>(null);
        }

        public async Task<IdentityResult> UpdateAsync(AppUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            _context.Update(user);
          
            return await Task<IdentityResult>.FromResult(IdentityResult.Success);
        }
    }
}
