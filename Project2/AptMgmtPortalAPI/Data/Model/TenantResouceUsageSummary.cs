using AptMgmtPortalAPI.Types;

namespace AptMgmtPortalAPI.DataModel
{
    public class TenantResourceUsageSummary
    {
        public ResourceType ResourceType { get; set; }
        public double Usage { get; set; }
    }
}
