using Identity.Domain.Users.Events;
using Microsoft.AspNetCore.Identity;
using Survey.CQRS.Events;
using Survey.Identity.Domain.Entities;
using Survey.Identity.Domain.Users.Events;
using Survey.Identity.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Domain.Users
{
    public class User : IdentityUser<Guid>, IEventEntity
    {
        #region Fields 

        public virtual FullName FullName { get; private set; }
        public virtual DeleteInfo DeleteInfo { get; private set; }
        public virtual CreateInfo CreateInfo { get; private set; }

        public byte[] Timestamp { get; private set; }


        public DateTime? LastConnexionOn { get; private set; }


        public virtual Entity Entity { get; private set; }

        private readonly List<UserRole> _userRoles = new List<UserRole>();

        public virtual IReadOnlyList<UserRole> UserRoles => _userRoles.ToList();

        public List<IEvent> Events { get; set; }


        #endregion

        #region Ctro
        public User()
        {
        }

        public User(FullName fullName, string email, Entity entity, List<Guid> roles)
        {

            UserName = email;
            FullName = fullName;
            Email = email;
            Entity = entity;
            CreateInfo = CreateInfo.Create().Value;
            DeleteInfo = DeleteInfo.Create().Value;
            AssignRoles(roles);
            Rise(new UserRegistered(Id, FullName.FirstName, FullName.LastName, Email, CreateInfo.CreatedOn ?? DateTime.Now));
        }

        #endregion 

        #region Methods 

        private void AssignRoles(List<Guid> roles)
        {
            List<Guid> toAdd = roles.Where(a => _userRoles.Where(b => b.RoleId == a).Count() == 0).ToList();

            if (toAdd.Count() != 0)
                toAdd.ForEach(a => _userRoles.Add(UserRole.Create(this.Id, a)));
        }
        private void RemoveRolesBaseOnNewRoles(List<Guid> roles)
        {
            List<UserRole> toRemove = _userRoles.Where(a => roles.Where(b => b == a.RoleId).Count() == 0)
                .ToList();

            if (toRemove.Count() != 0)
                toRemove.ForEach(a => _userRoles.Remove(a));
        }
        public void Unregister(DeleteInfo deleteInfo)
        {
            if (DeleteInfo.Deleted)
                throw new SurveyException("user_already_unregistred");
            this.MarkAsDeleted(deleteInfo);
            Rise(new UserDeleted(Id, DeleteInfo.DeleteReason, DeleteInfo.DeletedOn ?? DateTime.Now));

        }


        public void ChangeEmail(string email)
        {
            Email = email;
            Rise(new UserEmailChanged(Id, Email));
        }
        public void EditUser(FullName fullName, Entity entity, List<Guid> roles = null)
        {
            this.EditPersonalInfo(fullName);
            this.EditRoles(roles);
            SetNewEntity(entity);


        }
        private void SetNewEntity(Entity entity)
        {
            Entity = entity;
        }
        private void EditPersonalInfo(FullName fullName)
        {
            if (FullName != fullName)
            {
                FullName.Update(fullName);
                Rise(new UserNameUpdated(Id, FullName.FirstName, FullName.LastName));
            }
        }
        private void EditRoles(List<Guid> roles)
        {
            RemoveRolesBaseOnNewRoles(roles);

            AssignRoles(roles);
        }


        public void SetLastConnexionDate()
        {
            this.LastConnexionOn = DateTime.Now;
        }

        private void MarkAsDeleted(DeleteInfo deletionObj)
        {
            DeleteInfo = deletionObj;
        }

        public void ClearEvent()
        {
            Events.Clear();
        }

        public void Rise(IEvent @event)
        {
            Events ??= new List<IEvent>();
            Events.Add(@event);
        }




        #endregion

    }
}
