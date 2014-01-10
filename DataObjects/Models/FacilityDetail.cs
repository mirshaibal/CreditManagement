using System;
using System.Collections.Generic;

namespace DataObjects.Models
{
    public partial class FacilityDetail
    {
        public int FacilityDetailId { get; set; }
        public int CreditInfoId { get; set; }
        public Nullable<int> NatureOfFacility { get; set; }
        public Nullable<decimal> ELFunded { get; set; }
        public Nullable<decimal> ELNonFunded { get; set; }
        public Nullable<decimal> OSFunded { get; set; }
        public Nullable<decimal> OSNonFunded { get; set; }
        public Nullable<System.DateTime> Validity { get; set; }
        public string LYTurnOver { get; set; }
        public Nullable<decimal> EOL { get; set; }
        public string OverdueInstNo { get; set; }
        public Nullable<decimal> OverdueInstAmount { get; set; }
        public string CLStatus { get; set; }
        public Nullable<decimal> APFFunded { get; set; }
        public Nullable<decimal> APFNonFunded { get; set; }
        public Nullable<int> FaiclityFor { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public virtual CreditInfo CreditInfo { get; set; }
    }
}
