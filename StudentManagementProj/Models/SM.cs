using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace StudentManagementProj.Models
{
    public partial class SM : DbContext
    {
        public SM()
            : base("name=SM")
        {
        }

        public virtual DbSet<batch> batches { get; set; }
        public virtual DbSet<course> courses { get; set; }
        public virtual DbSet<registration> registrations { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<batch>()
                .Property(e => e.batch1)
                .IsUnicode(false);

            modelBuilder.Entity<batch>()
                .Property(e => e.year)
                .IsUnicode(false);

            modelBuilder.Entity<batch>()
                .HasMany(e => e.registrations)
                .WithOptional(e => e.batch)
                .HasForeignKey(e => e.batch_id);

            modelBuilder.Entity<course>()
                .Property(e => e.course1)
                .IsUnicode(false);

            modelBuilder.Entity<course>()
                .Property(e => e.duration)
                .IsUnicode(false);

            modelBuilder.Entity<course>()
                .HasMany(e => e.registrations)
                .WithOptional(e => e.course)
                .HasForeignKey(e => e.course_id);

            modelBuilder.Entity<registration>()
                .Property(e => e.firstName)
                .IsUnicode(false);

            modelBuilder.Entity<registration>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<registration>()
                .Property(e => e.NRC)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.firstName)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}
