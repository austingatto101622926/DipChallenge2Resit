namespace DipChallengeResit_Api.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=AzureDB")
        {
        }

        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<Procedure> Procedures { get; set; }
        public virtual DbSet<Treatment> Treatments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>()
                .Property(e => e.GivenName)
                .IsUnicode(false);

            modelBuilder.Entity<Owner>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<Owner>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<Owner>()
                .HasMany(e => e.Pets)
                .WithRequired(e => e.Owner)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pet>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Pet>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Pet>()
                .HasMany(e => e.Treatments)
                .WithRequired(e => e.Pet)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Procedure>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Procedure>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Procedure>()
                .HasMany(e => e.Treatments)
                .WithRequired(e => e.Procedure)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Treatment>()
                .Property(e => e.Notes)
                .IsUnicode(false);

            modelBuilder.Entity<Treatment>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);
        }
    }
}
