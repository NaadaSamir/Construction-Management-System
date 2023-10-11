﻿// <auto-generated />
using System;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinalProject.Migrations
{
    [DbContext(typeof(CompanyContext))]
    [Migration("20230806201659_Finaaaal")]
    partial class Finaaaal
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FinalProject.Models.DEPT_LOCATION", b =>
                {
                    b.Property<int?>("Dnumber")
                        .HasColumnType("int");

                    b.Property<string>("DLocation")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("departmentDnumber")
                        .HasColumnType("int");

                    b.HasKey("Dnumber", "DLocation");

                    b.HasIndex("departmentDnumber");

                    b.ToTable("DEPT_LOCATIONs");
                });

            modelBuilder.Entity("FinalProject.Models.Department", b =>
                {
                    b.Property<int?>("Dnumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Dnumber"));

                    b.Property<string>("Dname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MGRSSN")
                        .HasColumnType("int");

                    b.Property<DateTime?>("MGRStartDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("employeeSSN")
                        .HasColumnType("int");

                    b.HasKey("Dnumber");

                    b.HasIndex("employeeSSN");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("FinalProject.Models.Dependent", b =>
                {
                    b.Property<int?>("Essn")
                        .HasColumnType("int");

                    b.Property<string>("Dependent_Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("Bdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Relationship")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(1)");

                    b.Property<int?>("employeeSSN")
                        .HasColumnType("int");

                    b.HasKey("Essn", "Dependent_Name");

                    b.HasIndex("employeeSSN");

                    b.ToTable("Dependents");
                });

            modelBuilder.Entity("FinalProject.Models.Employee", b =>
                {
                    b.Property<int>("SSN")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SSN"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BDATE")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DNO")
                        .HasColumnType("int");

                    b.Property<string>("Fname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lname")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Minit")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("Salary")
                        .HasColumnType("int");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(1)");

                    b.Property<int?>("SuperSSN")
                        .HasColumnType("int");

                    b.Property<int?>("employeeSSN")
                        .HasColumnType("int");

                    b.HasKey("SSN");

                    b.HasIndex("DNO");

                    b.HasIndex("employeeSSN");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("FinalProject.Models.Project", b =>
                {
                    b.Property<int?>("Pnumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Pnumber"));

                    b.Property<int?>("Dnum")
                        .HasColumnType("int");

                    b.Property<string>("Plocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("departmentDnumber")
                        .HasColumnType("int");

                    b.HasKey("Pnumber");

                    b.HasIndex("departmentDnumber");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("FinalProject.Models.WorksOn", b =>
                {
                    b.Property<int?>("ESSN")
                        .HasColumnType("int");

                    b.Property<int?>("Pno")
                        .HasColumnType("int");

                    b.Property<int?>("Hours")
                        .HasColumnType("int");

                    b.Property<int?>("employeeSSN")
                        .HasColumnType("int");

                    b.Property<int?>("projectPnumber")
                        .HasColumnType("int");

                    b.HasKey("ESSN", "Pno");

                    b.HasIndex("employeeSSN");

                    b.HasIndex("projectPnumber");

                    b.ToTable("WorksOns");
                });

            modelBuilder.Entity("FinalProject.Models.DEPT_LOCATION", b =>
                {
                    b.HasOne("FinalProject.Models.Department", "department")
                        .WithMany("DEPT_LOCATIONs")
                        .HasForeignKey("departmentDnumber");

                    b.Navigation("department");
                });

            modelBuilder.Entity("FinalProject.Models.Department", b =>
                {
                    b.HasOne("FinalProject.Models.Employee", "employee")
                        .WithMany("Departments")
                        .HasForeignKey("employeeSSN");

                    b.Navigation("employee");
                });

            modelBuilder.Entity("FinalProject.Models.Dependent", b =>
                {
                    b.HasOne("FinalProject.Models.Employee", "employee")
                        .WithMany("Dependents")
                        .HasForeignKey("employeeSSN");

                    b.Navigation("employee");
                });

            modelBuilder.Entity("FinalProject.Models.Employee", b =>
                {
                    b.HasOne("FinalProject.Models.Department", "department")
                        .WithMany("Employees")
                        .HasForeignKey("DNO");

                    b.HasOne("FinalProject.Models.Employee", "employee")
                        .WithMany()
                        .HasForeignKey("employeeSSN");

                    b.Navigation("department");

                    b.Navigation("employee");
                });

            modelBuilder.Entity("FinalProject.Models.Project", b =>
                {
                    b.HasOne("FinalProject.Models.Department", "department")
                        .WithMany("Projects")
                        .HasForeignKey("departmentDnumber");

                    b.Navigation("department");
                });

            modelBuilder.Entity("FinalProject.Models.WorksOn", b =>
                {
                    b.HasOne("FinalProject.Models.Employee", "employee")
                        .WithMany("WorkOns")
                        .HasForeignKey("employeeSSN");

                    b.HasOne("FinalProject.Models.Project", "project")
                        .WithMany("WorkOns")
                        .HasForeignKey("projectPnumber");

                    b.Navigation("employee");

                    b.Navigation("project");
                });

            modelBuilder.Entity("FinalProject.Models.Department", b =>
                {
                    b.Navigation("DEPT_LOCATIONs");

                    b.Navigation("Employees");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("FinalProject.Models.Employee", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("Dependents");

                    b.Navigation("WorkOns");
                });

            modelBuilder.Entity("FinalProject.Models.Project", b =>
                {
                    b.Navigation("WorkOns");
                });
#pragma warning restore 612, 618
        }
    }
}
