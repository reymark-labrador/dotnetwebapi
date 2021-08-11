﻿// <auto-generated />
using System;
using DotnetWebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DotnetWebApi.Migrations
{
    [DbContext(typeof(CrudContext))]
    partial class CrudContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DotnetWebApi.Model.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Designation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CreatedAt = new DateTime(2021, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Tech Team",
                            Designation = "Full Stack Developer",
                            Name = "Ashok"
                        },
                        new
                        {
                            ID = 2,
                            CreatedAt = new DateTime(2021, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Design Team",
                            Designation = "UI/UX Designer",
                            Name = "Jim Doe"
                        });
                });

            modelBuilder.Entity("DotnetWebApi.Model.EmployeeTask", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssignedEmployeeID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AssignedEmployeeID");

                    b.ToTable("EmployeeTasks");
                });

            modelBuilder.Entity("DotnetWebApi.Model.EmployeeTask", b =>
                {
                    b.HasOne("DotnetWebApi.Model.Employee", "AssignedEmployee")
                        .WithMany()
                        .HasForeignKey("AssignedEmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}