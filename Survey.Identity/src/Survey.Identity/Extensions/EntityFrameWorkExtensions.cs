using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Extensions
{


    public static class EntityFrameWorkExtensions
    {
        public static bool HasChanged(this EntityEntry entry) =>
            entry.State == EntityState.Added ||
            entry.State == EntityState.Deleted ||
            entry.State == EntityState.Modified ||
            entry.References.Any(r => r.TargetEntry != null && r.TargetEntry.Metadata.IsOwned() && HasChanged(r.TargetEntry));
    }
}
