using AptMgmtPortal.Entity;

namespace AptMgmtPortal.DataModel
{
    public class TenantResourceUsageSummary
    {
        public ResourceType ResourceType { get; set; }
        public double Usage { get; set; }
    }
}
