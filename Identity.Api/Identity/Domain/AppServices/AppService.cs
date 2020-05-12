using CSharpFunctionalExtensions;
using Identity.Api.Exceptions;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Manage.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.AppServices
{
    public class AppService
    {
        public virtual Guid Id { get; protected set; }
        public virtual AppServiceInfo ServiceInfo { get; protected set; }
        public virtual CreateInfo CreationInfo { get; protected set; }
        public virtual DeleteInfo DeleteInfo { get; protected set; }
        public virtual DisabeleInfo DisableInfo { get; protected set; }
        public virtual AppServiceFeaturesCollection Features { get; protected set; }
        public virtual AppServiceRolesCollection Roles { get; protected set; }

        protected AppService() { }

        public AppService(AppServiceInfo serviceInfo, CreateInfo creationInfo)
        {
            Id = Guid.NewGuid();
            ServiceInfo = serviceInfo;
            CreationInfo = creationInfo;
            DeleteInfo = DeleteInfo.Create().Value;
            DisableInfo = DisabeleInfo.Create().Value;
        }

        public void DisableService(DisabeleInfo disableInfo)
        {
            DisableInfo = disableInfo;
        }

        internal void EditInfo(AppServiceInfo value)
        {
            ServiceInfo = value;
        }

        public void RemoveService(DeleteInfo deleteInfo)
        {
            DeleteInfo = deleteInfo;
        }
    }
}
