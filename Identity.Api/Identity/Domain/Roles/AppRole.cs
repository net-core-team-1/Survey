using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Identity.Api.Identity.Domain.Roles
{
    public class AppRole : IdentityRole<Guid>
    {
        public virtual string Description { get; set; }

        private List<AppRoleClaim> _roleClaims = new List<AppRoleClaim>();
        public virtual IReadOnlyCollection<AppRoleClaim> RoleClaims => _roleClaims.ToList();

        protected AppRole()
        {
        }

        public AppRole(Guid roleId)
        {
            this.Id = roleId;
        }

        protected AppRole(string description, List<AppRoleClaim> roleClaims)
        {
            Description = description;
        }

        public void EditRoleClaims(List<AppRoleClaim> roleClaims)
        {
            _roleClaims.Clear();
            _roleClaims.AddRange(_roleClaims);
        }
    }
}
