using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Identity.Contracts
{
    public class EditFeatureRequest
    {
        public Guid Id { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }

    }
}
