namespace DHL.Receipting.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PAGES")]
    public partial class Page
    {
        [Key]
        [Column("PAGE_PATH", Order = 0)]
        [StringLength(100)]
        public string PagePath { get; set; }

        [Key]
        [Column("PAGE_NAME", Order = 1)]
        [StringLength(100)]
        public string PageName { get; set; }
    }
}
