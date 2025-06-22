namespace DHL.Receipting.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOGIN_BRANCH")]
    public partial class LoginBranch
    {
        [Key]
        [Column("USER_ID", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        [Key]
        [Column("BRANCH_CODE", Order = 1)]
        [StringLength(10)]
        public string BranchCode { get; set; }
    }
}
