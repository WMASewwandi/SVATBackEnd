namespace DHL.Receipting.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("INVOICE_ACCESS_RIGHTS")]
    public partial class InvoiceAccessRights
    {
        [Key]
        [Column("MODULE_ID", Order = 0)]
        [StringLength(20)]
        public string ModuleId { get; set; }

        [Key]
        [Column("USER_TYPE", Order = 1)]
        [StringLength(50)]
        public string UserType { get; set; }
    }
}
