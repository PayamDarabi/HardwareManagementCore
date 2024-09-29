using System;
using System.Collections.Generic;

namespace HardwareManagement_.core_.Models.Entity
{
    public partial class TblPerson
    {
        public string PersonId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Phone { get; set; }
        public string Unit { get; set; } = null!;
        public short? RoomNo { get; set; }
        public string Status { get; set; } = null!;
        public string? Note { get; set; }
    }
}
