using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HardwareManagement_.core_.Models.Entity
{
    public partial class TblUser
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; } = null!;
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = null!;

    }
}
