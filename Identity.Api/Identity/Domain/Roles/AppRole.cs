using Identity.Api.Identity.Domain.RoleFeatures;
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
        public virtual CreateInfo CreateInfo { get; protected set; }
        public virtual DisabeleInfo DisableInfo { get; protected set; }
        public virtual DeleteInfo DeleteInfo { get; protected set; }

        private List<AppRoleClaim> _roleClaims = new List<AppRoleClaim>();
        public virtual IReadOnlyCollection<AppRoleClaim> RoleClaims => _roleClaims.ToList();

        private readonly List<AppRoleFeatures> _features = new List<AppRoleFeatures>();
        public virtual IReadOnlyList<AppRoleFeatures> Features => _features.ToList();

        protected AppRole()
        {
        }

        public AppRole(Guid roleId)
        {
            this.Id = roleId;
        }

        public AppRole(CreateInfo createInfo, string roleName, string description)
        {
            this.Name = roleName;
            this.NormalizedName = roleName.ToUpper();
            this.Description = description;
            CreateInfo = createInfo;
            DisableInfo = DisabeleInfo.Create().Value;
            DeleteInfo = DeleteInfo.Create().Value;
        }

        internal void Disable(DisabeleInfo disableInfo)
        {
            DisableInfo = disableInfo;
        }

        internal void Unregister(DeleteInfo deleteInfo)
        {
            DeleteInfo = deleteInfo;
        }

        public void EditRoleInfo(string name, string description)
        {
            this.Name = name;
            this.NormalizedName = name.ToUpper();
            this.Description = description;
        }

        public void EditRoleClaims(List<AppRoleClaim> roleClaims)
        {
            _roleClaims.Clear();
            _roleClaims.AddRange(roleClaims);
        }

        public void EditFeatures(List<AppRoleFeatures> features)
        {
            _features.Clear();
            _features.AddRange(features);
        }
        public void AddForTest(AppRoleFeatures features)
        {
          
            _features.Add(features);
        }

        public void ClearAllFeatures()
        {
            _features.Clear();

        }
    }
}
