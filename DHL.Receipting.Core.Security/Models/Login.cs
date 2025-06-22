namespace DHL.Receipting.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOGIN")]
    public partial class Login
    {
        [Key]
        [Column("USER_ID", Order = 0)]
        public int UserId { get; set; }

        [Required]
        [Column("USERNAME", Order = 1)]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [Column("PASSWORD", Order = 2)]
        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(100)]
        [Column("NAME", Order = 3)]
        public string Name { get; set; }

        [StringLength(50)]
        [Column("USER_TYPE", Order = 4)]
        public string UserType { get; set; }

        [Column("INACTIVE", Order = 5)]
        public bool? Inactive { get; set; }

        [Column("INACTIVE_USER", Order = 6)]
        public int? InactiveUser { get; set; }

        [Column("INACTIVE_DATE", Order = 7)]
        public decimal? InactiveDate { get; set; }

        [Column("INACTIVE_DATETIME", Order = 8)]
        public DateTime? InactiveDateTime { get; set; }

        [Column("ADDED_USER", Order = 9)]
        public int? AddedUser { get; set; }

        [Column("ADDED_DATE", Order = 10)]
        public decimal? AddedDate { get; set; }

        [Column("ADDED_DATETIME", Order = 11)]
        public DateTime? AddedDateTime { get; set; }
    }
}
