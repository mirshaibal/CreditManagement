using System;
using System.Collections.Generic;

namespace DataObjects.Models
{
    public partial class Client
    {
        public Client()
        {
            this.ClientAdministrations = new List<ClientAdministration>();
            this.ClientSisterConcerns = new List<ClientSisterConcern>();
            this.CreditInfoes = new List<CreditInfo>();
        }

        public int ClientId { get; set; }
        public int BranchId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Nullable<System.DateTime> ActionTime { get; set; }
        public string Address { get; set; }
        public string CorporateAddress { get; set; }
        public string FactoryAddress { get; set; }
        public string AuthorizedCapital { get; set; }
        public string PaidupCapital { get; set; }
        public string Products { get; set; }
        public Nullable<System.DateTime> IncorporationDate { get; set; }
        public string BusinessNature { get; set; }
        public string ConstitutionNature { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual ICollection<ClientAdministration> ClientAdministrations { get; set; }
        public virtual ICollection<ClientSisterConcern> ClientSisterConcerns { get; set; }
        public virtual ICollection<CreditInfo> CreditInfoes { get; set; }
    }
}
