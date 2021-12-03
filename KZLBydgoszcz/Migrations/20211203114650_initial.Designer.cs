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
    [Migration("20211203114650_initial")]
    partial class initial
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
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Student_classID");

                    b.ToTable("class_Names");
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("WorkStartDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("full_time")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
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
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
