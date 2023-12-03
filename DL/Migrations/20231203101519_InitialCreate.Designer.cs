﻿// <auto-generated />
using System;
using DL.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DL.Migrations
{
    [DbContext(typeof(StudentDbContext))]
    [Migration("20231203101519_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DL.DbModels.StudentDbDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RollNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StudentDbDto2");
                });

            modelBuilder.Entity("DL.DbModels.StudentSubjectDbDto", b =>
                {
                    b.Property<int>("SID")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<double>("GPA")
                        .HasColumnType("float");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("StudentDbDtoId")
                        .HasColumnType("int");

                    b.Property<int?>("SubjectDbDtoid")
                        .HasColumnType("int");

                    b.HasKey("SID", "SubjectId");

                    b.HasIndex("StudentDbDtoId");

                    b.HasIndex("SubjectDbDtoid");

                    b.HasIndex("SubjectId");

                    b.ToTable("StudentSubjectDbDto2");
                });

            modelBuilder.Entity("DL.DbModels.SubjectDbDto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("SubjectDbDto2");
                });

            modelBuilder.Entity("DL.DbModels.StudentSubjectDbDto", b =>
                {
                    b.HasOne("DL.DbModels.StudentDbDto", "studentDbDto")
                        .WithMany()
                        .HasForeignKey("SID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DL.DbModels.StudentDbDto", null)
                        .WithMany("studentSubjects")
                        .HasForeignKey("StudentDbDtoId");

                    b.HasOne("DL.DbModels.SubjectDbDto", null)
                        .WithMany("StudentSubjects")
                        .HasForeignKey("SubjectDbDtoid");

                    b.HasOne("DL.DbModels.SubjectDbDto", "SubjectDbDto")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubjectDbDto");

                    b.Navigation("studentDbDto");
                });

            modelBuilder.Entity("DL.DbModels.StudentDbDto", b =>
                {
                    b.Navigation("studentSubjects");
                });

            modelBuilder.Entity("DL.DbModels.SubjectDbDto", b =>
                {
                    b.Navigation("StudentSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}
