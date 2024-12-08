﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniversityStats.Infrastructure.Data;

#nullable disable

namespace UniversityStats.Infrastructure.Migrations
{
    [DbContext(typeof(UniversityStatsContext))]
    [Migration("20241208073218_SeedInitialData")]
    partial class SeedInitialData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("UniversityStats.Infrastructure.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("UniversityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UniversityId");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Факультет информационных технологий",
                            UniversityId = 1
                        });
                });

            modelBuilder.Entity("UniversityStats.Infrastructure.Entities.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Faculties");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DepartmentId = 1,
                            Name = "Кафедра программной инженерии"
                        });
                });

            modelBuilder.Entity("UniversityStats.Infrastructure.Entities.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("SpecialtyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SpecialtyId");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "ПИ-21",
                            SpecialtyId = 1
                        });
                });

            modelBuilder.Entity("UniversityStats.Infrastructure.Entities.Specialty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("FacultyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("Specialties");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FacultyId = 1,
                            Name = "Программная инженерия"
                        });
                });

            modelBuilder.Entity("UniversityStats.Infrastructure.Entities.University", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Universities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Ведущий технический университет",
                            Name = "Технический университет"
                        });
                });

            modelBuilder.Entity("UniversityStats.Infrastructure.Entities.Department", b =>
                {
                    b.HasOne("UniversityStats.Infrastructure.Entities.University", "University")
                        .WithMany("Departments")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("UniversityStats.Infrastructure.Entities.Faculty", b =>
                {
                    b.HasOne("UniversityStats.Infrastructure.Entities.Department", "Department")
                        .WithMany("Faculties")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("UniversityStats.Infrastructure.Entities.Group", b =>
                {
                    b.HasOne("UniversityStats.Infrastructure.Entities.Specialty", "Specialty")
                        .WithMany("Groups")
                        .HasForeignKey("SpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Specialty");
                });

            modelBuilder.Entity("UniversityStats.Infrastructure.Entities.Specialty", b =>
                {
                    b.HasOne("UniversityStats.Infrastructure.Entities.Faculty", "Faculty")
                        .WithMany("Specialties")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("UniversityStats.Infrastructure.Entities.Department", b =>
                {
                    b.Navigation("Faculties");
                });

            modelBuilder.Entity("UniversityStats.Infrastructure.Entities.Faculty", b =>
                {
                    b.Navigation("Specialties");
                });

            modelBuilder.Entity("UniversityStats.Infrastructure.Entities.Specialty", b =>
                {
                    b.Navigation("Groups");
                });

            modelBuilder.Entity("UniversityStats.Infrastructure.Entities.University", b =>
                {
                    b.Navigation("Departments");
                });
#pragma warning restore 612, 618
        }
    }
}
