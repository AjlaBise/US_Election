using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace US_Election.Dal.Database
{
    public partial class US_ElectionDbContext : DbContext
    {
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Electorate> Electorates { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Exception> Exceptions { get; set; }


        public US_ElectionDbContext(DbContextOptions<US_ElectionDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Initial Catalog=usElection;Integrated Security = true");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.ToTable("Candidate");

                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            });

            modelBuilder.Entity<Electorate>(entity =>
            {
                entity.ToTable("Electorate");

                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            });

            modelBuilder.Entity<Vote>(entity =>
            {
                entity.ToTable("Vote");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.ElectorateId).HasColumnName("ElectorateId");

                entity.Property(e => e.CandidateId).HasColumnName("CandidateId");

            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
