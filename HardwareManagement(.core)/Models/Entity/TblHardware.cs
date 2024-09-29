using System;
using System.Collections.Generic;

namespace HardwareManagement_.core_.Models.Entity
{
    public partial class TblHardware
    {
        public string AssetNo { get; set; } = null!;
        public string SerialNo { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Model { get; set; } = null!;
        public DateTime? AssignDate { get; set; }
        public DateTime? RecieveDate { get; set; }
        public string? PersonId { get; set; }
        public string? Location { get; set; }
        public string? StatusHw { get; set; }

        internal static int Count()
        {
            throw new NotImplementedException();
        }

        internal static object Skip(int recSkip)
        {
            throw new NotImplementedException();
        }
    }
}
