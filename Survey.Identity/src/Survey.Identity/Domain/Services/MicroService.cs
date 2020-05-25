using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Domain.Services
{
    public class MicroService
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; set; }

        public virtual CreateInfo CreateInfo { get; private set; }
        public virtual DeleteInfo DeleteInfo { get; private set; }
        public byte[] Timestamp { get; private set; }

        #region Ctor
        protected MicroService()
        {

        }
        #endregion
    }
}
