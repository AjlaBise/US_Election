﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using US_Election.Dal.Database;

namespace US_Election.Dal.Migrations
{
    [DbContext(typeof(US_ElectionDbContext))]
    [Migration("20211119125502_test")]
    partial class test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("US_Election.Dal.Database.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Candidate");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "DT",
                            Name = "Donald Trump"
                        },
                        new
                        {
                            Id = 2,
                            Code = "HC",
                            Name = "Hillary Clinton"
                        },
                        new
                        {
                            Id = 3,
                            Code = "JB",
                            Name = " Joe Biden"
                        },
                        new
                        {
                            Id = 4,
                            Code = "JFK",
                            Name = "  John F. Kennedy"
                        },
                        new
                        {
                            Id = 5,
                            Code = "JR",
                            Name = "Jack Randall"
                        });
                });

            modelBuilder.Entity("US_Election.Dal.Database.Electorate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Electorate");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "New York"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Washington"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Texas"
                        });
                });

            modelBuilder.Entity("US_Election.Dal.Database.Vote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CandidateId")
                        .HasColumnName("CandidateId")
                        .HasColumnType("int");

                    b.Property<int>("ElectorateId")
                        .HasColumnName("ElectorateId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfVotes")
                        .HasColumnType("int");

                    b.Property<bool?>("OverrideFile")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("ElectorateId");

                    b.ToTable("Vote");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CandidateId = 1,
                            ElectorateId = 1,
                            NumberOfVotes = 4287
                        },
                        new
                        {
                            Id = 2,
                            CandidateId = 2,
                            ElectorateId = 2,
                            NumberOfVotes = 7287
                        },
                        new
                        {
                            Id = 3,
                            CandidateId = 3,
                            ElectorateId = 3,
                            NumberOfVotes = 12547
                        },
                        new
                        {
                            Id = 4,
                            CandidateId = 4,
                            ElectorateId = 1,
                            NumberOfVotes = 74287
                        },
                        new
                        {
                            Id = 5,
                            CandidateId = 1,
                            ElectorateId = 2,
                            NumberOfVotes = 11287
                        });
                });

            modelBuilder.Entity("US_Election.Dal.Database.Vote", b =>
                {
                    b.HasOne("US_Election.Dal.Database.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("US_Election.Dal.Database.Electorate", "Electorate")
                        .WithMany()
                        .HasForeignKey("ElectorateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
