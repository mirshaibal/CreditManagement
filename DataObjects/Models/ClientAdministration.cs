using System;
using System.Collections.Generic;

namespace DataObjects.Models
{
    public partial class ClientAdministration
    {
        public int AdminId { get; set; }
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Address { get; set; }
        public string Age { get; set; }
        public string Education { get; set; }
        public string BackgroundDetails { get; set; }
        public string BusinessExperience { get; set; }
        public string Position { get; set; }
        public Nullable<System.DateTime> ActionTime { get; set; }
        public virtual Client Client { get; set; }
    }
}
