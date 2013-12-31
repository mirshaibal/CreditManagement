using System;
using System.Collections.Generic;

namespace DataObjects.Models
{
    public partial class Branch
    {
        public Branch()
        {
            this.Clients = new List<Client>();
            this.CreditInfoes = new List<CreditInfo>();
            this.Users = new List<User>();
        }

        public int BranchId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Nullable<System.DateTime> ActionTime { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<CreditInfo> CreditInfoes { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
