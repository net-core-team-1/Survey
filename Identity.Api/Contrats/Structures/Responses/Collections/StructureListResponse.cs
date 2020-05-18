using Identity.Api.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Contrats.Structures.Responses
{
    public class StructureListResponse : ResponseBase
    {
        public List<StructureResponse> Items;
        public override long Count => Items.Count;
        public StructureListResponse(List<StructureResponse> items)
        {
            Items = items;
        }
    }
}
