namespace DHL.Receipting.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ACCESS_RIGHTS_MASTER")]
    public partial class AccessRightsMaster
    {
        [Key]
        [Column("ACCESS_RIGHTS_ID", Order = 0)]
        [StringLength(50)]
        public string AccessRightsId { get; set; }

        [Required]
        [Column("ACCESS_RIGHTS_DESC", Order = 1)]
        [StringLength(50)]
        public string AccessRightsDesc { get; set; }

        [Column("ACC_ORDER", Order = 2)]
        public int AccOrder { get; set; }
    }
}
