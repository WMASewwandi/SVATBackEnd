namespace DHL.Receipting.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USER_TYPE")]
    public partial class UserTypes
    {
        [Key]
        [Column("TYPE_CODE", Order = 0)]
        [StringLength(20)]
        public string TypeCode { get; set; }

        [Key]
        [Column("TYPE_DESCRIPTION", Order = 1)]
        [StringLength(50)]
        public string TypeDesc { get; set; }
    }
}
