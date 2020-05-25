using Microsoft.EntityFrameworkCore;
using Survey.Identity.Domain.Authentication;
using Survey.Identity.Domain.Identity;
using Survey.Identity.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Data.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly SurveyIdentityContext _context;
        public RefreshTokenRepository(SurveyIdentityContext context)
        {
            _context = context;
        }

        public void Add(RefreshToken refreshToken) => _context.RefreshTokens.Add(refreshToken);


        public RefreshToken Get(string refreshToken) => _context.RefreshTokens.Where(a => a.Token == refreshToken)
                                                                              .Include(a => a.User).FirstOrDefault();


        public bool Save() => _context.SaveChanges() > 0;
    }
}
