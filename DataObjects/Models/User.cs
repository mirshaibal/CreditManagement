using System;
using System.Collections.Generic;

namespace DataObjects.Models
{
    public partial class User
    {
        public User()
        {
            this.CreditFlows = new List<CreditFlow>();
            this.CreditFlows1 = new List<CreditFlow>();
            this.CreditInfoes = new List<CreditInfo>();
            this.CreditInfoes1 = new List<CreditInfo>();
        }

        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> ActionTime { get; set; }
        public virtual ICollection<CreditFlow> CreditFlows { get; set; }
        public virtual ICollection<CreditFlow> CreditFlows1 { get; set; }
        public virtual ICollection<CreditInfo> CreditInfoes { get; set; }
        public virtual ICollection<CreditInfo> CreditInfoes1 { get; set; }
        public virtual Role Role { get; set; }
    }
}
