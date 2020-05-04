using Remotion.Linq.Parsing.ExpressionVisitors.Transformation.PredefinedTransformations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Contrat.Users.Responses
{
    public class UserRolesResponse
    {
        public Dictionary<Guid, string> Roles { get; set; }
    }
}
