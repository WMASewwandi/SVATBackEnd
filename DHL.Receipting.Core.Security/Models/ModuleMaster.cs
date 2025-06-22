namespace DHL.Receipting.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MODULE_MASTER")]
    public partial class ModuleMaster
    {
        [Key]
        [Column("MODULE_ID", Order = 0)]
        public int ModuleId { get; set; }

        [Required]
        [Column("MODULE_DESC", Order = 1)]
        [StringLength(1024)]
        public string ModuleDesc { get; set; }
    }
}
