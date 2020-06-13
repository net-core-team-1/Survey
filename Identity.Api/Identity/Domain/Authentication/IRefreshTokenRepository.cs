using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Authentication
{
    public interface IRefreshTokenRepository
    {
        RefreshToken Get(string refreshToken);

        void Add(RefreshToken refreshToken);
        bool Save();
    }
}
