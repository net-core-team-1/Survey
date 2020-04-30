using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Domain.Users
{
    public class UserToken: IdentityUserToken<Guid>
    {
    }
}
