using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AptMgmtPortal.Entity
{
    public class TenantAgreement
    {
        public int TenantAgreementId { get; set; }

        public int TenantId { get; set; }

        public int AgrementId { get; set;  }

        public DateTimeOffset SignedDate { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
    }
}
