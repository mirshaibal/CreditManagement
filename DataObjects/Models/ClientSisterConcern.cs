using System;
using System.Collections.Generic;

namespace DataObjects.Models
{
    public partial class ClientSisterConcern
    {
        public ClientSisterConcern()
        {
        }

        public int SisterConcernId { get; set; }
        public Nullable<int> ClientId { get; set; }
        public string Name { get; set; }        
        public string Address { get; set; }
        public string NationalId { get; set; }
        public string HoldingShares { get; set; }
        public string Percentage { get; set; }
        public string PNW { get; set; }        
        public Nullable<System.DateTime> ActionTime { get; set; }
        public virtual Client Client { get; set; }
    }
}
