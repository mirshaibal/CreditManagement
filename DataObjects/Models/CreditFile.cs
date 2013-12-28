using System;
using System.Collections.Generic;

namespace DataObjects.Models
{
    public partial class CreditFile
    {
        public int CreditFileId { get; set; }
        public Nullable<int> CreditInfoId { get; set; }
        public string Title { get; set; }
        public string FilePath { get; set; }
        public Nullable<System.DateTime> ActionTime { get; set; }
        public virtual CreditInfo CreditInfo { get; set; }
    }
}
