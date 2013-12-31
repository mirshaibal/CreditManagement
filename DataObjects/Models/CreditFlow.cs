using System;
using System.Collections.Generic;

namespace DataObjects.Models
{
    public partial class CreditFlow
    {
        public int CreditFlowId { get; set; }
        public Nullable<int> AssignFromUserId { get; set; }
        public Nullable<int> AssignToUserId { get; set; }
        public Nullable<int> CreditInfoId { get; set; }
        public string Comment { get; set; }
        public Nullable<bool> IsLatestComment { get; set; }
        public Nullable<System.DateTime> ActionTime { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
        public virtual CreditInfo CreditInfo { get; set; }
    }
}
