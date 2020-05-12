using Identity.Api.Identity.Domain.AppServices;
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
        public virtual Guid  ServiceId { get; private set; }
        public virtual AppService Service { get; private set; }
        public virtual AppRoleFeaturesCollection RoleFeatures { get; protected set; }

        protected AppRole()
        {
            RoleFeatures = new AppRoleFeaturesCollection();
        }

        public AppRole(Guid roleId)
            : this()
        {
            this.Id = roleId;
        }

        public AppRole(CreateInfo createInfo, string roleName, string description)
            : this()
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

        public void EditFeatures(AppRoleFeaturesCollection features)
        {
            //_roleAppServiceFeatures.Clear();
            //_roleAppServiceFeatures.AddRange(features);
        }

    }
}
