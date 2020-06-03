using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Extensions
{
    public static class Extensions
    {
        public static bool IsChanged(this EntityEntry entry) =>
            entry.State == EntityState.Added ||
            entry.State == EntityState.Deleted ||
            entry.State == EntityState.Modified ||
            entry.References.Any(r => r.TargetEntry != null && r.TargetEntry.Metadata.IsOwned() && IsChanged(r.TargetEntry));
    }
}
