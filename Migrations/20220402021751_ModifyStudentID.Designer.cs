﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using wepAPI.Repositories;

#nullable disable

namespace wepAPI.Migrations
{
    [DbContext(typeof(StudentsContext))]
    [Migration("20220402021751_ModifyStudentID")]
    partial class ModifyStudentID
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("wepAPI.Entities.Course", b =>
                {
                    b.Property<string>("CourseCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CourseInstractor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("StudentID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CourseCode");

                    b.HasIndex("StudentID");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("wepAPI.Entities.Department", b =>
                {
                    b.Property<string>("DepartmentCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DepartmentHead")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentCode");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("wepAPI.Entities.Student", b =>
                {
                    b.Property<Guid>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DepartmentCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("GPA")
                        .HasColumnType("real");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentID");

                    b.HasIndex("DepartmentCode");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("wepAPI.Entities.Course", b =>
                {
                    b.HasOne("wepAPI.Entities.Student", null)
                        .WithMany("RegisteredCourses")
                        .HasForeignKey("StudentID");
                });

            modelBuilder.Entity("wepAPI.Entities.Student", b =>
                {
                    b.HasOne("wepAPI.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("wepAPI.Entities.Student", b =>
                {
                    b.Navigation("RegisteredCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
