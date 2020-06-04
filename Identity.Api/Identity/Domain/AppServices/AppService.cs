using Common.Types.Types.Events;
using CSharpFunctionalExtensions;
using Identity.Api.Exceptions;
using Identity.Api.Identity.Domain.AppServices.Events;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Manage.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.AppServices
{
    public class AppService : IDomainEntity
    {
        public virtual Guid Id { get; protected set; }
        public virtual AppServiceInfo ServiceInfo { get; protected set; }
        public virtual CreateInfo CreationInfo { get; protected set; }
        public virtual DeleteInfo DeleteInfo { get; protected set; }
        public virtual DisabeleInfo DisableInfo { get; protected set; }
        public virtual AppServiceFeaturesCollection Features { get; protected set; }
        public virtual AppServiceRolesCollection Roles { get; protected set; }
        public List<IEvent> Events { get; set; }

        protected AppService()
        {
            Events = new List<IEvent>();
        }

        public AppService(Guid appServiceId)
            :this()
        {
            Id = appServiceId;
        }

        public AppService(AppServiceInfo serviceInfo, CreateInfo creationInfo)
            : this(Guid.NewGuid())
        {
            ServiceInfo = serviceInfo;
            CreationInfo = creationInfo;
            DeleteInfo = DeleteInfo.Create().Value;
            DisableInfo = DisabeleInfo.Create().Value;
            Events.Add(new AppServiceRegistredEvent(this.Id, serviceInfo.Name,
                serviceInfo.Description, creationInfo.CreatedBy.Value));
        }

        public void DisableService(DisabeleInfo disableInfo)
        {
            DisableInfo = disableInfo;
            Events.Add(new AppServiceDisabledEvent(this.Id, disableInfo.DisabledBy.Value));
        }

        internal void EditInfo(AppServiceInfo appServiceInfo)
        {
            ServiceInfo = appServiceInfo;
            Events.Add(new AppServiceEditedEvent(this.Id, appServiceInfo.Name, appServiceInfo.Description));
        }

        public void RemoveService(DeleteInfo deleteInfo)
        {
            DeleteInfo = deleteInfo;
            Events.Add(new AppServiceDeletedEvent(this.Id, deleteInfo.DeletedBy.Value));
        }
    }
}
