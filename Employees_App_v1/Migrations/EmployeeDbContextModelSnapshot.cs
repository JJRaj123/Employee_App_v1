﻿// <auto-generated />
using System;
using Employees_App_v1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Employees_App_v1.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    partial class EmployeeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Employees_App_v1.Models.DepartmentModel", b =>
                {
                    b.Property<int>("Department_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Department_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Department_Id");

                    b.ToTable("tbl_Department");
                });

            modelBuilder.Entity("Employees_App_v1.Models.EmployeeModel", b =>
                {
                    b.Property<int>("Employee_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DepartmentIdDepartment_Id")
                        .HasColumnType("int");

                    b.Property<string>("Email_Id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("First_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Last_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Manager_Id")
                        .HasColumnType("int");

                    b.HasKey("Employee_Id");

                    b.HasIndex("DepartmentIdDepartment_Id");

                    b.ToTable("tbl_Employee");
                });

            modelBuilder.Entity("Employees_App_v1.Models.EmployeeModel", b =>
                {
                    b.HasOne("Employees_App_v1.Models.DepartmentModel", "DepartmentId")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentIdDepartment_Id");
                });
#pragma warning restore 612, 618
        }
    }
}
