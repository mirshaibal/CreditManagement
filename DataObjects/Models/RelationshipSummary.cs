using System;
using System.Collections.Generic;

namespace DataObjects.Models
{
    public partial class RelationshipSummary
    {
        public int RelationshipId { get; set; }
        public Nullable<int> CreditInfoId { get; set; }
        public string FacilityNature { get; set; }
        public Nullable<System.DateTime> SanctionDate { get; set; }
        public string FundedLimit { get; set; }
        public string NonFundedLimit { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public string RescheduleTime { get; set; }
        public string RescheduleAmount { get; set; }
        public string ApprovalAuthority { get; set; }
        public virtual CreditInfo CreditInfo { get; set; }
    }
}
