﻿// <auto-generated />
using System;
using KZLBydgoszcz.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KZLBydgoszcz.Migrations
{
    [DbContext(typeof(StudentContext))]
    [Migration("20211203150147_Some_required_added_completed")]
    partial class Some_required_added_completed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KZLBydgoszcz.Models.Class_Name", b =>
                {
                    b.Property<int>("Student_classID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Class_identificator")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("Student_classID");

                    b.ToTable("class_Names");
                });

            modelBuilder.Entity("KZLBydgoszcz.Models.Lessons", b =>
                {
                    b.Property<int>("LessonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LessonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Student_classID")
                        .HasColumnType("int");

                    b.Property<int>("TeachersId")
                        .HasColumnType("int");

                    b.HasKey("LessonID");

                    b.HasIndex("Student_classID");

                    b.HasIndex("TeachersId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("KZLBydgoszcz.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("AvgGrade")
                        .HasColumnType("real");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Student_classID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Student_classID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("KZLBydgoszcz.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("WorkStartDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("full_time")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("KZLBydgoszcz.Models.Lessons", b =>
                {
                    b.HasOne("KZLBydgoszcz.Models.Class_Name", "Student_class")
                        .WithMany("Lessons")
                        .HasForeignKey("Student_classID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KZLBydgoszcz.Models.Teacher", "Teachers")
                        .WithMany("Lessons")
                        .HasForeignKey("TeachersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student_class");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("KZLBydgoszcz.Models.Student", b =>
                {
                    b.HasOne("KZLBydgoszcz.Models.Class_Name", "Student_class")
                        .WithMany("Students")
                        .HasForeignKey("Student_classID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student_class");
                });

            modelBuilder.Entity("KZLBydgoszcz.Models.Class_Name", b =>
                {
                    b.Navigation("Lessons");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("KZLBydgoszcz.Models.Teacher", b =>
                {
                    b.Navigation("Lessons");
                });
#pragma warning restore 612, 618
        }
    }
}