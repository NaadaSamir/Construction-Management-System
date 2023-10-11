using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    /// <inheritdoc />
    public partial class Finaaaal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Dnumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MGRSSN = table.Column<int>(type: "int", nullable: true),
                    employeeSSN = table.Column<int>(type: "int", nullable: true),
                    MGRStartDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Dnumber);
                });

            migrationBuilder.CreateTable(
                name: "DEPT_LOCATIONs",
                columns: table => new
                {
                    Dnumber = table.Column<int>(type: "int", nullable: false),
                    DLocation = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    departmentDnumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPT_LOCATIONs", x => new { x.Dnumber, x.DLocation });
                    table.ForeignKey(
                        name: "FK_DEPT_LOCATIONs_Departments_departmentDnumber",
                        column: x => x.departmentDnumber,
                        principalTable: "Departments",
                        principalColumn: "Dnumber");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    SSN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Minit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Lname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BDATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Salary = table.Column<int>(type: "int", nullable: true),
                    SuperSSN = table.Column<int>(type: "int", nullable: true),
                    employeeSSN = table.Column<int>(type: "int", nullable: true),
                    DNO = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.SSN);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DNO",
                        column: x => x.DNO,
                        principalTable: "Departments",
                        principalColumn: "Dnumber");
                    table.ForeignKey(
                        name: "FK_Employees_Employees_employeeSSN",
                        column: x => x.employeeSSN,
                        principalTable: "Employees",
                        principalColumn: "SSN");
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Pnumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Plocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dnum = table.Column<int>(type: "int", nullable: true),
                    departmentDnumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Pnumber);
                    table.ForeignKey(
                        name: "FK_Projects_Departments_departmentDnumber",
                        column: x => x.departmentDnumber,
                        principalTable: "Departments",
                        principalColumn: "Dnumber");
                });

            migrationBuilder.CreateTable(
                name: "Dependents",
                columns: table => new
                {
                    Essn = table.Column<int>(type: "int", nullable: false),
                    Dependent_Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    employeeSSN = table.Column<int>(type: "int", nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Bdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependents", x => new { x.Essn, x.Dependent_Name });
                    table.ForeignKey(
                        name: "FK_Dependents_Employees_employeeSSN",
                        column: x => x.employeeSSN,
                        principalTable: "Employees",
                        principalColumn: "SSN");
                });

            migrationBuilder.CreateTable(
                name: "WorksOns",
                columns: table => new
                {
                    ESSN = table.Column<int>(type: "int", nullable: false),
                    Pno = table.Column<int>(type: "int", nullable: false),
                    employeeSSN = table.Column<int>(type: "int", nullable: true),
                    projectPnumber = table.Column<int>(type: "int", nullable: true),
                    Hours = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorksOns", x => new { x.ESSN, x.Pno });
                    table.ForeignKey(
                        name: "FK_WorksOns_Employees_employeeSSN",
                        column: x => x.employeeSSN,
                        principalTable: "Employees",
                        principalColumn: "SSN");
                    table.ForeignKey(
                        name: "FK_WorksOns_Projects_projectPnumber",
                        column: x => x.projectPnumber,
                        principalTable: "Projects",
                        principalColumn: "Pnumber");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_employeeSSN",
                table: "Departments",
                column: "employeeSSN");

            migrationBuilder.CreateIndex(
                name: "IX_Dependents_employeeSSN",
                table: "Dependents",
                column: "employeeSSN");

            migrationBuilder.CreateIndex(
                name: "IX_DEPT_LOCATIONs_departmentDnumber",
                table: "DEPT_LOCATIONs",
                column: "departmentDnumber");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DNO",
                table: "Employees",
                column: "DNO");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_employeeSSN",
                table: "Employees",
                column: "employeeSSN");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_departmentDnumber",
                table: "Projects",
                column: "departmentDnumber");

            migrationBuilder.CreateIndex(
                name: "IX_WorksOns_employeeSSN",
                table: "WorksOns",
                column: "employeeSSN");

            migrationBuilder.CreateIndex(
                name: "IX_WorksOns_projectPnumber",
                table: "WorksOns",
                column: "projectPnumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Employees_employeeSSN",
                table: "Departments",
                column: "employeeSSN",
                principalTable: "Employees",
                principalColumn: "SSN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Employees_employeeSSN",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "Dependents");

            migrationBuilder.DropTable(
                name: "DEPT_LOCATIONs");

            migrationBuilder.DropTable(
                name: "WorksOns");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
