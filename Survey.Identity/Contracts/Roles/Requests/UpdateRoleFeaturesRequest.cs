using Survey.Identity.Contracts.Features;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Identity.Contracts
{
   public sealed class UpdateRoleFeaturesRequest
    {
        public Guid Id { get; set; }

        public List<Guid> Features { get; set; }


        public UpdateRoleFeaturesRequest()
        {
            Features = new List<Guid>();
        }
    }
}
