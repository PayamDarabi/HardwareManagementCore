using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HardwareManagement_.core_.Models.Entity
{
    public partial class TblStore
    {
        [Required]
        public int StoreId { get; set; } 
        [Required]
        public string StLocation { get; set; } = null!;
    }
}
