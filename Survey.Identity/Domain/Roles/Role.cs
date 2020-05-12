﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Survey.Identity.Domain.Roles
{
    public class Role : IdentityRole<Guid>
    {
        public virtual CreateInfo CreateInfo { get; private set; }

        public virtual DisabeleInfo DisabeleInfo { get; private set; }

        public virtual DeleteInfo DeleteInfo { get; private set; }

        public byte[] Timestamp { get; private set; }

        private readonly List<RoleFeature> _roleFeatures = new List<RoleFeature>();
        public virtual IReadOnlyList<RoleFeature> RoleFeatures => _roleFeatures.ToList();


        protected Role()
        {

        }

        public Role(string name,CreateInfo creationInfo, List<Guid> features = null)
        {
            Name = name;
            CreateInfo = creationInfo;
            DeleteInfo = DeleteInfo.Create().Value;
            DisabeleInfo = DisabeleInfo.Create().Value;

            LinkFeatures(features);
        }

        public void Deactivate(DisabeleInfo disableInfo)
        {
            DisabeleInfo = disableInfo;
        }

        public void Update( List<Guid> features = null)
        {
            UpdateFeatures(features);
        }
     
        private void UpdateFeatures(List<Guid> features)
        {
            DisconnectFeaturesBasedOnNewOnes(features);
            LinkFeatures(features);

        }

        private void LinkFeatures(List<Guid> features)
        {
            List<Guid> toAdd = features.Where(a => _roleFeatures.Where(b => b.Feature.Id == a).Count() == 0).ToList();

            if (toAdd.Count() != 0)
                toAdd.ForEach(a => _roleFeatures.Add(RoleFeature.Create(this.Id, a)));
        }
        private void DisconnectFeaturesBasedOnNewOnes(List<Guid> features)
        {
            List<RoleFeature> toDelete = _roleFeatures.Where(a => features.Where(b => b == a.Feature.Id).Count() == 0)
                 .ToList();

            if (toDelete.Count() != 0)
                toDelete.ForEach(a => _roleFeatures.Remove(a));
        }

        public void Remove(DeleteInfo deletionInfo)
        {
            MarkAsDeleted(deletionInfo);
        }
        private void MarkAsDeleted(DeleteInfo deletionInfo)
        {
            DeleteInfo = deletionInfo;
        }
    }
}
