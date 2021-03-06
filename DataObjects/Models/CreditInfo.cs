using System;
using System.Collections.Generic;

namespace DataObjects.Models
{
    public partial class CreditInfo
    {
        public CreditInfo()
        {
            this.CreditFiles = new List<CreditFile>();
            this.CreditFlows = new List<CreditFlow>();
            this.FacilityDetails = new List<FacilityDetail>();
            this.RelationshipSummaries = new List<RelationshipSummary>();
        }

        public int CreditInfoId { get; set; }
        public Nullable<int> ClientId { get; set; }
        public Nullable<int> BranchId { get; set; }
        public Nullable<int> CreatedUserId { get; set; }
        public Nullable<int> AssignUserId { get; set; }
        public string Info { get; set; }
        public Nullable<int> Status { get; set; }
        public string Subject { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string SubjectDetails { get; set; }
        public string BorrowerName { get; set; }
        public string ProposedFacility { get; set; }
        public string BranchRef { get; set; }
        public string ApplicationDate { get; set; }
        public string BranchProposalDate { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<CreditFile> CreditFiles { get; set; }
        public virtual ICollection<CreditFlow> CreditFlows { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
        public virtual ICollection<FacilityDetail> FacilityDetails { get; set; }
        public virtual ICollection<RelationshipSummary> RelationshipSummaries { get; set; }
    }
}
