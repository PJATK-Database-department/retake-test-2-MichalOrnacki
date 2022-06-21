using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ApbdTest2.Models
{
    public partial class s22378Context : DbContext
    {
        public s22378Context()
        {
        }

        public s22378Context(DbContextOptions<s22378Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Action> Actions { get; set; }
        public virtual DbSet<Firefighter> Firefighters { get; set; }
        public virtual DbSet<FirefighterAction> FirefighterActions { get; set; }
        public virtual DbSet<Firetruck> Firetrucks { get; set; }
        public virtual DbSet<FiretruckAction> FiretruckActions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s22378;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<Action>(entity =>
            {
                entity.HasKey(e => e.IdAction)
                    .HasName("Action_pk");

                entity.ToTable("Action");

                entity.Property(e => e.IdAction).ValueGeneratedNever();

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Firefighter>(entity =>
            {
                entity.HasKey(e => e.IdFirefighter)
                    .HasName("Firefighter_pk");

                entity.ToTable("Firefighter");

                entity.Property(e => e.IdFirefighter).ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<FirefighterAction>(entity =>
            {
                entity.HasKey(e => new { e.IdFirefighter, e.IdAction })
                    .HasName("Firefighter_Action_pk");

                entity.ToTable("Firefighter_Action");

                entity.HasOne(d => d.IdActionNavigation)
                    .WithMany(p => p.FirefighterActions)
                    .HasForeignKey(d => d.IdAction)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Firefighter_Action_Action");

                entity.HasOne(d => d.IdFirefighterNavigation)
                    .WithMany(p => p.FirefighterActions)
                    .HasForeignKey(d => d.IdFirefighter)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Firefighter_Action_Firefighter");
            });

            modelBuilder.Entity<Firetruck>(entity =>
            {
                entity.HasKey(e => e.IdFireTruck)
                    .HasName("Firetruck_pk");

                entity.ToTable("Firetruck");

                entity.Property(e => e.IdFireTruck).ValueGeneratedNever();

                entity.Property(e => e.OperationalNumber)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<FiretruckAction>(entity =>
            {
                entity.HasKey(e => e.IdFireTruckAction)
                    .HasName("Firetruck_Action_pk");

                entity.ToTable("Firetruck_Action");

                entity.Property(e => e.IdFireTruckAction).ValueGeneratedNever();

                entity.Property(e => e.AssignmentDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdActionNavigation)
                    .WithMany(p => p.FiretruckActions)
                    .HasForeignKey(d => d.IdAction)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Firetruck_Action_Action");

                entity.HasOne(d => d.IdFireTruckNavigation)
                    .WithMany(p => p.FiretruckActions)
                    .HasForeignKey(d => d.IdFireTruck)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Firetruck_Action_Firetruck");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
