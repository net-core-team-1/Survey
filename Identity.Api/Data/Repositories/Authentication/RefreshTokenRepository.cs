using Identity.Api.Identity.Domain.Authentication;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Data.Repositories.Authentication
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly TransverseIdentityDbContext _context;
        public RefreshTokenRepository(TransverseIdentityDbContext context)
        {
            _context = context;
        }

        public void Add(RefreshToken refreshToken) => _context.RefreshTokens.Add(refreshToken);


        public RefreshToken Get(string refreshToken) => _context.RefreshTokens.Where(a => a.Token == refreshToken)
                                                                              .Include(a => a.User).FirstOrDefault();


        public bool Save() => _context.SaveChanges() > 0;
    }
}
