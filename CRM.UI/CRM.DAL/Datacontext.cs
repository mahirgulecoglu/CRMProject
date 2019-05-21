namespace CRM.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Datacontext : DbContext
    {
        public Datacontext()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<EmployeeRoles> EmployeeRoles { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Leads> Leads { get; set; }
        public virtual DbSet<Notes> Notes { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>()
                .HasMany(e => e.Leads)
                .WithRequired(e => e.Customers)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customers>()
                .HasMany(e => e.Notes)
                .WithRequired(e => e.Customers)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employees>()
                .HasMany(e => e.EmployeeRoles)
                .WithRequired(e => e.Employees)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employees>()
                .HasMany(e => e.Leads)
                .WithRequired(e => e.Employees)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Roles>()
                .HasMany(e => e.EmployeeRoles)
                .WithRequired(e => e.Roles)
                .WillCascadeOnDelete(false);
        }
    }
}
