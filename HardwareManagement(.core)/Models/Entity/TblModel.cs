using System;
using System.Collections.Generic;

namespace HardwareManagement_.core_.Models.Entity
{
    public partial class TblModel
    {
        public int Id { get; set; }
        public string Model { get; set; } = null!;
        public string Title { get; set; } = null!;
    }
}
