using System;
using System.Collections.Generic;

namespace HardwareManagement_.core_.Models.Entity
{
    public partial class TblHistory
    {
        public int Id { get; set; }
        public string AssetNo { get; set; } = null!;
        public string SerialNo { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Model { get; set; } = null!;
        public DateTime? AssignDate { get; set; }
        public DateTime? RecieveDate { get; set; }
        public string? UserSender { get; set; }
        public DateTime? RepairDate { get; set; }
        public DateTime? OutOfDate { get; set; }
        public string? StatusHw { get; set; }
    }
}
