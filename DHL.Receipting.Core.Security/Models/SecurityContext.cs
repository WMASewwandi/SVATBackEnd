namespace DHL.Receipting.Core.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using DHL.Receipting.Core.Security.Migrations;

    public partial class SecurityContext : DbContext
    {
        public SecurityContext()
            : base("name=SecurityContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SecurityContext, SecurityConfiguration>(true, new DHL.Receipting.Core.Security.Migrations.SecurityConfiguration()));
        }

        public virtual DbSet<AccessRights> AccessRights { get; set; }
        public virtual DbSet<AccessRightsMaster> AccessRightsMaster { get; set; }
        public virtual DbSet<InvoiceAccessRights> InvoiceAccessRights { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<LoginBranch> LoginBranch { get; set; }
        public virtual DbSet<ModuleMaster> ModuleMaster { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<UserTypes> UserType { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessRights>()
                .Property(e => e.TypeCode)
                .IsUnicode(false);

            modelBuilder.Entity<AccessRights>()
                .Property(e => e.PagePath)
                .IsUnicode(false);

            modelBuilder.Entity<AccessRights>()
                .Property(e => e.ACCESS_RIGHTS1)
                .IsUnicode(false);

            modelBuilder.Entity<AccessRightsMaster>()
                .Property(e => e.AccessRightsId)
                .IsUnicode(false);

            modelBuilder.Entity<AccessRightsMaster>()
                .Property(e => e.AccessRightsDesc)
                .IsUnicode(false);

            modelBuilder.Entity<InvoiceAccessRights>()
                .Property(e => e.ModuleId)
                .IsUnicode(false);

            modelBuilder.Entity<InvoiceAccessRights>()
                .Property(e => e.UserType)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.UserType)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.InactiveDate)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Login>()
                .Property(e => e.AddedDate)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LoginBranch>()
                .Property(e => e.BranchCode)
                .IsUnicode(false);

            modelBuilder.Entity<ModuleMaster>()
                .Property(e => e.ModuleDesc)
                .IsUnicode(false);

            modelBuilder.Entity<Page>()
                .Property(e => e.PagePath)
                .IsUnicode(false);

            modelBuilder.Entity<UserTypes>()
                .Property(e => e.TypeCode)
                .IsUnicode(false);

            modelBuilder.Entity<UserTypes>()
                .Property(e => e.TypeDesc)
                .IsUnicode(false);
        }
        
    }
}
