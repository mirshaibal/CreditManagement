using System;
using System.Collections.Generic;

namespace DataObjects.Models
{
    public partial class Client
    {
        public Client()
        {
            this.CreditInfoes = new List<CreditInfo>();
        }

        public int ClientId { get; set; }
        public int BranchId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Nullable<System.DateTime> ActionTime { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual ICollection<CreditInfo> CreditInfoes { get; set; }
    }
}
