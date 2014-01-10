using System;
using System.Collections.Generic;

namespace DataObjects.Models
{
    public partial class CIBStatu
    {
        public int CIBStatusId { get; set; }
        public Nullable<decimal> CustLimit { get; set; }
        public Nullable<decimal> CustOS { get; set; }
        public Nullable<decimal> AlliedLimit { get; set; }
        public Nullable<decimal> AlliedOS { get; set; }
        public Nullable<int> NOF { get; set; }
        public Nullable<System.DateTime> ReportDate { get; set; }
        public Nullable<int> CreditInfoId { get; set; }
        //public virtual CIBStatu CIBStatus1 { get; set; }
        //public virtual CIBStatu CIBStatu1 { get; set; }
    }
}
