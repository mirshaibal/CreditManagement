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
        public string BorrowerName { get; set; }
        public Nullable<System.DateTime> ApplicationDate { get; set; }
        public string ProposedFacility { get; set; }
        public string BranchProposalRef { get; set; }
        public string BranchProposalDate { get; set; }
        public string HOReceivedDate { get; set; }
        public string DateOfAccountOpening { get; set; }
        public string ClientName { get; set; }
        public string RegisterAddress { get; set; }
        public string CorporateAddress { get; set; }
        public string FactoryAddress { get; set; }
        public string NatureOfBusiness { get; set; }
        public string Products { get; set; }
        public string CapitalStructure { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<CreditFile> CreditFiles { get; set; }
        public virtual ICollection<CreditFlow> CreditFlows { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
